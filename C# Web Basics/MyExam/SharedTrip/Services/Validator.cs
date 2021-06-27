namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;

    using static SharedTrip.Data.DataConstants;

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

        public ICollection<string> ValidateTrip(TripFormModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                errors.Add($"Start Point is required");
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                errors.Add($"End Point is required");
            }

            if (string.IsNullOrWhiteSpace(model.DepartureTime))
            {
                errors.Add($"Departure Time is required");
            }

            var isDateCorrect = DateTime.TryParse(model.DepartureTime, out var _);
            if (!isDateCorrect)
            {
                errors.Add($"Date must be in Format 'dd.MM.yyyy HH:mm'.");
            }

            if (model.Seats < TripMinSeats || model.Seats > TripMaxSeats)
            {
                errors.Add($"Seats must be between {TripMinSeats} and {TripMaxSeats}.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > TripMaxDescription)
            {
                errors.Add($"Description must be less than {TripMaxDescription} characters long.");
            }

            return errors;
        }
    }
}
