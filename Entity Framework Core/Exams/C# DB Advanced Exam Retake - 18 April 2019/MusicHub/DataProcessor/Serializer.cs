using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MusicHub.DataProcessor.ExportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToArray()
                .Where(x => x.ProducerId.HasValue && x.ProducerId == producerId)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("F2"),
                            Writer = s.Writer.Name,
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    AlbumPrice = x.Price.ToString("F2"),
                })
                .OrderByDescending(x => x.AlbumPrice);

            return JsonConvert.SerializeObject(albums, Formatting.Indented);
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new ExportSongDto
                {
                    SongName = x.Name,
                    Performer = x.SongPerformers.FirstOrDefault().Performer.FirstName + " " +
                                x.SongPerformers.FirstOrDefault().Performer.LastName,
                    Writer = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c"),
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToArray();

            var xml = new XmlSerializer(typeof(ExportSongDto[]), new XmlRootAttribute("Songs"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var sb = new StringBuilder();

            xml.Serialize(new StringWriter(sb), songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}