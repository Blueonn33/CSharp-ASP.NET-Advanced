namespace CinemaApp.Data.Common
{
    public static class EntityValidation
    {
        public static class Movie
        {
            public const int TitleMaxLength = 100;
            public const int GenreMaxLength = 50;
            public const int DirectorMaxLength = 100;
            public const int DescriptionMaxLength = 1000;
            public const int ImageUrlMaxLength = 2048;

            public const string ReleaseDateColumnType = "smalldatetime";
        }
    }
}
