using System.Globalization;
using System.Linq;
using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Producers
                .FirstOrDefault(p => p.Id == producerId)
                .Albums
                .Select(album => new
                {
                    AlbumName = album.Name,
                    ReleaseDate = album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = album.Producer.Name,
                    AlbumSongs = album.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price,
                        SongWriterName = s.Writer.Name,
                    })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName)
                        .ToList(),
                    TotalAlbumPrice = album.Price,
                })
                .OrderByDescending(x => x.TotalAlbumPrice)
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                var counter = 1;
                foreach (var albumSong in album.AlbumSongs)
                {
                    sb
                        .AppendLine($"---#{counter++}")
                        .AppendLine($"---SongName: {albumSong.SongName}")
                        .AppendLine($"---Price: {albumSong.Price:F2}")
                        .AppendLine($"---Writer: {albumSong.SongWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .AsEnumerable()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    Name = x.Name,
                    PerformerFullName = x.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();
            var counter = 1;
            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{counter++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
