using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MusicHub.Data.Models;
using MusicHub.Data.Models.Enums;
using MusicHub.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDtos = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);
            var sb = new StringBuilder();
            foreach (var writerDto in writersDtos)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym,
                };

                context.Writers.Add(writer);
                sb.AppendLine($"Imported {writer.Name}");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var producersDtos = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            foreach (var producerDto in producersDtos)
            {
                if (!IsValid(producerDto) ||
                    !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber,
                    Albums = producerDto.Albums
                        .Select(x => new Album
                        {
                            Name = x.Name,
                            ReleaseDate = DateTime.ParseExact(x.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        })
                        .ToArray()
                };

                context.Producers.Add(producer);
                context.SaveChanges();

                _ = producer.PhoneNumber != null ?
                    sb.AppendLine($"Imported {producer.Name} with phone: {producer.PhoneNumber} produces {producer.Albums.Count} albums") :
                    sb.AppendLine($"Imported {producer.Name} with no phone number produces {producer.Albums.Count} albums");
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));
            var songsDtos = (ImportSongDto[])xml.Deserialize(new StringReader(xmlString));

            foreach (var songDto in songsDtos)
            {
                if (!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = context.Writers.FirstOrDefault(x => x.Id == songDto.WriterId);
                var isValidGenre = Enum.TryParse(songDto.Genre, true, out Genre genre);

                if (!isValidGenre || writer == null || songDto.AlbumId == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var album = context.Albums.FirstOrDefault(x => x.Id == songDto.AlbumId);
                if (album == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Price = songDto.Price,
                    Writer = writer,
                    Album = album,
                    Genre = genre,
                };

                context.Songs.Add(song);
                context.SaveChanges();

                sb.AppendLine($"Imported {song.Name} ({song.Genre} genre) with duration {song.Duration}");
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ImportSongPerformerDto[]), new XmlRootAttribute("Performers"));
            var performersDtos = (ImportSongPerformerDto[])xml.Deserialize(new StringReader(xmlString));

            foreach (var performerDto in performersDtos)
            {
                if (!IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,
                };

                var isInvalid = false;

                foreach (var perfomerSongsDto in performerDto.PerformersSongs)
                {
                    var song = context.Songs.FirstOrDefault(x => x.Id == perfomerSongsDto.Id);
                    if (song == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        isInvalid = true;
                        break;
                    }

                    performer.PerformerSongs.Add(new SongPerformer
                    {
                        Song = song,
                    });
                }

                if (isInvalid)
                {
                    continue;
                }

                context.Performers.Add(performer);
                context.SaveChanges();

                sb.AppendLine($"Imported {performer.FirstName} ({performer.PerformerSongs.Count} songs)");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}