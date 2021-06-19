using System.Collections.Generic;
using System.Text.RegularExpressions;
using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using BattleCards.ViewModels.Users;

namespace BattleCards.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > UserMaxPassword)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateCard(CardInputModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < CardMinName || model.Name.Length > CardMaxName)
            {
                errors.Add($"Name '{model.Name}' is not valid. It must be between {CardMinName} and {CardMaxName} characters long.");
            }

            if (model.Attack < DefaultMinLength)
            {
                errors.Add($"Attack cannot be negative!");
            }

            if (model.Health < DefaultMinLength)
            {
                errors.Add($"Health cannot be negative!");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > CardMaxDescription)
            {
                errors.Add($"Name '{model.Description}' is not valid. It must be less than {CardMaxDescription} characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Image))
            {
                errors.Add($"Image is required");
            }

            if (string.IsNullOrWhiteSpace(model.Keyword))
            {
                errors.Add($"Keyword is required");
            }

            return errors;
        }
    }
}
