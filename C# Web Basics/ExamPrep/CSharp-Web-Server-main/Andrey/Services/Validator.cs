using System.Collections.Generic;
using System.Text.RegularExpressions;
using Andrey.ViewModels.Products;
using Andrey.ViewModels.Users;

namespace Andrey.Services
{
    using static Data.DataConstants;

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

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 4 || model.Name.Length > 20)
            {
                errors.Add($"Name '{model.Name}' is not valid. It must be between {4} and {20} characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 10)
            {
                errors.Add($"Name '{model.Description}' is not valid. It must be less than {10} characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.ImageUrl))
            {
                errors.Add($"ImageUrl is required");
            }

            return errors;
        }
    }
}
