using Git.Data;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Git.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        private readonly IUserService userService;

        public Validator(IUserService userService) => this.userService = userService;

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (this.userService.IsUsernameExist(model.Username))
            {
                errors.Add($"Username '{model.Username}' is already exist.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateRepository(RepositoryInputModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < RepositoryMinName || model.Name.Length > RepositoryMaxName)
            {
                errors.Add($"Model '{model.Name}' is not valid. It must be between {RepositoryMinName} and {RepositoryMaxName} characters long.");
            }

            if (model.RepositoryType != "Public" && model.RepositoryType != "Private")
            {
                errors.Add($"Repository type {model.RepositoryType} is invalid! It can be only 'Public' or 'Private'.");
            }

            return errors;
        }

        public ICollection<string> ValidateCommit(CommitInputModel model)
        {
            var errors = new List<string>();

            if (model.Description.Length < CommitMinDescription)
            {
                errors.Add($"Model '{model.Description}' is not valid. It must be greater than {CommitMinDescription} characters long.");
            }

            return errors;
        }
    }
}
