namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateTrip(TripFormModel model);
    }
}
