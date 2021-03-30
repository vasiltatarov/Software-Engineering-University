using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name) && x.Games.Any(g => g.Purchases.Any()))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                            Players = g.Purchases.Count,
                        })
                        .Where(g => g.Players > 0)
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id),
                    TotalPlayers = x.Games.Sum(g => g.Purchases.Count),
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id);

            var json = JsonConvert.SerializeObject(games, Formatting.Indented);

            return json;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var sb = new StringBuilder();

            var users = context.Users
                .ToArray()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(x => new ExportUserPurchasesDto
                {
                    Username = x.Username,
                    Purchases = x.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type.ToString() == storeType)
                        .Select(p => new ExportPurchaseDto
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToArray(),
                    TotalSpent = x.Cards.Sum(c => c.Purchases
                        .Where(p => p.Type.ToString() == storeType)
                        .Sum(p => p.Game.Price)),
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserPurchasesDto[]), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
	}
}