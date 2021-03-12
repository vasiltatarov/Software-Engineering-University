using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
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
            var sb = new StringBuilder();

            var gamesdtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var games = new List<Game>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();

            foreach (var gameDto in gamesdtos)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                DateTime releaseDate;
                bool isDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out releaseDate);

                if (!isDateValid)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var developer = developers.FirstOrDefault(x => x.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer()
                    {
                        Name = gameDto.Developer,
                    };
                    developers.Add(developer);
                }

                var genre = genres.FirstOrDefault(x => x.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = gameDto.Genre,
                    };
                    genres.Add(genre);
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate,
                    Genre = genre,
                    Developer = developer,
                };

                var gameTags = new List<GameTag>();

                foreach (var tagName in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    var tag = tags.FirstOrDefault(x => x.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag()
                        {
                            Name = tagName,
                        };
                        tags.Add(tag);
                    }

                    var gameTag = new GameTag()
                    {
                        Game = game,
                        Tag = tag,
                    };

                    gameTags.Add(gameTag);
                }

                if (gameTags.Count == 0)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                game.GameTags = gameTags;
                games.Add(game);

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto) || userDto.Cards.Length == 0)
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
                };

                var cards = new List<Card>();

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        cards = new List<Card>();
                        sb.AppendLine(InvalidMessage);
                        break;
                    }

                    CardType cardType;
                    var isValidCardType = Enum.TryParse(cardDto.Type, out cardType);
                    if (isValidCardType == false)
                    {
                        cards = new List<Card>();
                        sb.AppendLine(InvalidMessage);
                        break;
                    }

                    var card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType,
                    };

                    cards.Add(card);
                }

                if (cards.Count == 0)
                {
                    continue;
                }

                user.Cards = cards;

                users.Add(user);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            var purchasesDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                PurchaseType cardType;
                var isValidCardType = Enum.TryParse(purchaseDto.Type, out cardType);
                if (isValidCardType == false)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);
                if (card == null)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);
                if (game == null)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var purchase = new Purchase()
                {
                    Type = cardType,
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Game = game,
                };

                purchases.Add(purchase);

                sb.AppendLine($"Imported {game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
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