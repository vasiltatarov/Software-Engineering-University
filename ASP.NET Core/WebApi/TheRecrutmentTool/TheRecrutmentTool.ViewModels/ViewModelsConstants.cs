namespace TheRecrutmentTool.ViewModels
{
    public class ViewModelsConstants
    {
        public class CreateCandidate
        {
            public const int FirstNameMaxLength = 40;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 40;
            public const int LastNameMinLength = 2;

            public const int BiographyMaxLength = 1000;
            public const int BiographyMinLength = 10;

            public const int SkillNameMaxLength = 20;
            public const int SkillNameMinLength = 1;
        }

        public class CreateJob
        {
            public const int TitleMaxLength = 100;
            public const int TitleMinLength = 5;

            public const int DescriptionMinLength = 10;

            public const int SkillNameMaxLength = 20;
            public const int SkillNameMinLength = 1;
        }
    }
}
