using System.Collections.Generic;
using System.Text.RegularExpressions;
using Musaca.Data;
using Musaca.ViewModels.Products;
using Musaca.ViewModels.Users;

namespace Musaca.Services
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

        public ICollection<string> ValidateProduct(ProductInputModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < ProductMinName || model.Name.Length > ProductMaxName)
            {
                errors.Add($"Name '{model.Name}' is not valid. It must be more than {ProductMinName} and less than {ProductMaxName} characters long.");
            }

            if (model.Price < ProductMinPrice)
            {
                errors.Add($"Price cannot be less than 0.01.");
            }

            return errors;
        }
    }
}
