namespace Panda.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int DefaultMaxLength = 10;
        public const int DefaultMinLength = 0;

        public const int UserMinUsername = 5;
        public const int UserMaxUsername = 20;

        public const int UserMinPassword = 6;
        public const int UserMaxPassword = 20;

        public const int UserMinEmail = 5;
        public const int UserMaxEmail = 20;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int CardMinName = 5;
        public const int CardMaxName = 15;

        public const int PackageMinDescription = 5;
        public const int PackageMaxDescription = 20;
    }
}
