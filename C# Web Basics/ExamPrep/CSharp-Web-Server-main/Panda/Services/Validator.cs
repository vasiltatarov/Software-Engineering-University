using System.Collections.Generic;
using System.Text.RegularExpressions;
using Panda.Data;
using Panda.ViewModels.Packages;
using Panda.ViewModels.Users;

namespace Panda.Services
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

        public ICollection<string> ValidatePackage(PackageInputModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length < 5 || model.Description.Length > 20)
            {
                errors.Add($"Name '{model.Description}' is not valid. It must be more than {5} and less than {20} characters long.");
            }

            return errors;
        }
    }
}
