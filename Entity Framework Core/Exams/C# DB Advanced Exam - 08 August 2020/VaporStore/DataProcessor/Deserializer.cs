using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

    public static class Deserializer
    {
        private const string InvalidMessage = "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDtos = JsonConvert.DeserializeObject<ImportGamesDto[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto) ||
                    !gameDto.Tags.Any())
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var genre = context.Genres.FirstOrDefault(x => x.Name == gameDto.Genre)
                    ?? new Genre() { Name = gameDto.Genre };

                var developer = context.Developers.FirstOrDefault(x => x.Name == gameDto.Developer)
                    ?? new Developer() { Name = gameDto.Developer };

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Genre = genre,
                    Developer = developer,
                };

                foreach (var tagName in gameDto.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == tagName)
                        ?? new Tag() { Name = tagName };

                    game.GameTags.Add(new GameTag()
                    {
                        Tag = tag,
                    });
                }

                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto) ||
                    !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Age = userDto.Age,
                    Email = userDto.Email,
                    Cards = userDto.Cards
                        .Select(x => new Card
                        {
                            Cvc = x.CVC,
                            Number = x.Number,
                            Type = x.Type.Value,
                        })
                        .ToList(),
                };

                context.Users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));
            var data = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var purchaseDto in data)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var isParsed = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);
                if (!isParsed)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseDto.Type.Value,
                    ProductKey = purchaseDto.Key,
                    Card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card),
                    Game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title),
                    Date = date,
                };

                context.Purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}