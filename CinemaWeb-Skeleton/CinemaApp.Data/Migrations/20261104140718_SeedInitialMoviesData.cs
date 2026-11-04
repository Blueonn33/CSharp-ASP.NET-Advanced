using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialMoviesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ImageUrl", "IsDeleted", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("25163666-81d7-4829-9931-b6bd44eb2b23"), "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much more.", "David Fincher", 139, "Drama", "https://www.movieposters.com/cdn/shop/files/FightClub.mpw.125100_480x.progressive.jpg?v=1707497058", false, new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club" },
                    { new Guid("2f22c0dd-f7b9-46c3-a753-0d076dafb489"), "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", "Christopher Nolan", 169, "Adventure", "https://www.movieposters.com/cdn/shop/files/interstellar-139399_480x.progressive.jpg?v=1708527823", false, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { new Guid("3fcdb107-dc27-45a0-8514-e2b40714100e"), "A young FBI trainee seeks the help of an imprisoned cannibalistic serial killer to catch another serial killer.", "Jonathan Demme", 118, "Thriller", "https://www.movieposters.com/cdn/shop/files/silencelambs.C.17449.mpw_480x.progressive.jpg?v=1727097024", false, new DateTime(1991, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Silence of the Lambs" },
                    { new Guid("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"), "A skilled thief is given a chance at redemption if he can successfully perform an inception on a target's mind.", "Christopher Nolan", 148, "Sci-Fi", "https://cdn.shopify.com/s/files/1/0057/3728/3618/files/inception.mpw.123395_9e0000d1-bc7f-400a-b488-15fa9e60a10c_500x749.jpg?v=1708527589", false, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { new Guid("4b760743-8d49-48d5-bca6-15f5236e3f7b"), "A betrayed Roman general seeks revenge against the corrupt emperor who murdered his family and sent him into slavery.", "Ridley Scott", 155, "Action", "https://www.movieposters.com/cdn/shop/files/Gladiator.mpw.102813_480x.progressive.jpg?v=1707500493", false, new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladiator" },
                    { new Guid("75fb6394-ab90-4b78-9802-7ff3c9afdbc0"), "A businessman saves the lives of hundreds of Jews during the Holocaust by employing them in his factories.", "Steven Spielberg", 195, "Drama", "https://www.movieposters.com/cdn/shop/products/9a1f9ea4a27071481cc1263e3ea11f7b_7bdb2deb-dd50-41b5-beab-8fc1cb3c895d_480x.progressive.jpg?v=1573651233", false, new DateTime(1993, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List" },
                    { new Guid("7dd82b97-1eb2-4c37-9c3d-e26dd84878a0"), "The lives of guards on Death Row are affected by one of their charges, a black man accused of child murder and rape, yet who has a mysterious gift.", "Frank Darabont", 189, "Drama", "https://www.movieposters.com/cdn/shop/products/033152cb8ba4518411a359686f4a194e_e51d49fa-d8b2-4aaf-82dd-9779f297352c_480x.progressive.jpg?v=1573585373", false, new DateTime(1999, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Green Mile" },
                    { new Guid("8c5904a9-bfab-4b0f-b12b-b5fc795e6231"), "The story of Forrest Gump, a man with a low IQ, whose kind heart shapes the lives of those around him.", "Robert Zemeckis", 142, "Drama", "https://www.movieposters.com/cdn/shop/products/forrest-gump---24x36_480x.progressive.jpg?v=1645558337", false, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { new Guid("94e73f37-e260-4c6f-930b-8bd65c9c8a11"), "The lives of two mob hitmen, a boxer, and others intertwine in a series of unexpected incidents.", "Quentin Tarantino", 154, "Crime", "https://www.movieposters.com/cdn/shop/products/pulpfiction.2436_480x.progressive.jpg?v=1620048742", false, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("96fcb0c2-807e-4f7d-a28b-14ba6f9cb9b4"), "A computer hacker learns the shocking truth about the reality he lives in and joins a rebellion.", "The Wachowskis", 136, "Sci-Fi", "https://www.movieposters.com/cdn/shop/files/Matrix.mpw.102176_bb2f6cc5-4a16-4512-881b-f855ead3c8ec_480x.progressive.jpg?v=1708703624", false, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("9912f515-b2aa-4d19-9d2f-c2c94cb1212e"), "Earth's mightiest heroes must come together to stop a mischievous Loki and his alien army.", "Joss Whedon", 143, "Action", "https://www.movieposters.com/cdn/shop/files/avengers.24x36_480x.progressive.jpg?v=1707410714", false, new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Avengers" },
                    { new Guid("b0c21023-aa37-49cb-ad91-3ba005d8550d"), "With the help of a German bounty hunter, a freed slave sets out to rescue his wife from a brutal Mississippi plantation owner.", "Quentin Tarantino", 165, "Western", "https://www.movieposters.com/cdn/shop/products/ff35c38cb67f47a5f4cbec6c92a5d5a8_acb37f4c-8110-4bc9-b597-01e75e565a60_480x.progressive.jpg?v=1573587558", false, new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Django Unchained" },
                    { new Guid("bec8f441-5b73-4f11-87b8-a47fbc1d140f"), "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.", "Steven Spielberg", 127, "Adventure", "https://www.movieposters.com/cdn/shop/files/jurassicpark.mpw_480x.progressive.jpg?v=1713805481", false, new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" },
                    { new Guid("c994999b-02dd-46c2-abc4-00c4787e629f"), "A paraplegic Marine dispatched to the moon Pandora becomes torn between following orders and protecting his home.", "James Cameron", 162, "Sci-Fi", "https://www.movieposters.com/cdn/shop/files/avatar.adv.24x36_480x.progressive.jpg?v=1707410703", false, new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar" },
                    { new Guid("e0d85412-0717-4648-a972-f393a6aafaa8"), "A lion prince flees his kingdom after the death of his father, only to learn the true meaning of responsibility and bravery.", "Roger Allers, Rob Minkoff", 88, "Animation", "https://www.movieposters.com/cdn/shop/files/the-lion-king_273b54a5_480x.progressive.jpg?v=1725905168", false, new DateTime(1994, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lion King" },
                    { new Guid("e673a37c-8ffc-46bf-a66d-18b8078d7c94"), "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.", "Francis Ford Coppola", 175, "Crime", "https://www.movieposters.com/cdn/shop/products/b5282f72126e4919911509e034a61f66_6ce2486d-e0da-4b7a-9148-722cdde610b8_480x.progressive.jpg?v=1573616025", false, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("eb13b5e6-b8fd-4e11-99ef-446e9e752558"), "Batman faces the Joker, a criminal mastermind bent on causing chaos in Gotham City.", "Christopher Nolan", 152, "Action", "https://www.movieposters.com/cdn/shop/files/darkknight.building.24x36_20e90057-f673-4cc3-9ce7-7b0d3eeb7d83_480x.progressive.jpg?v=1707491191", false, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { new Guid("f1342f7d-ff72-4bfb-8a36-8368dec7b088"), "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of decency.", "Frank Darabont", 142, "Drama", "https://www.movieposters.com/cdn/shop/files/shawshank_eb84716b-efa9-44dc-a19d-c17924a3f7df_480x.progressive.jpg?v=1709821984", false, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("25163666-81d7-4829-9931-b6bd44eb2b23"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("2f22c0dd-f7b9-46c3-a753-0d076dafb489"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("3fcdb107-dc27-45a0-8514-e2b40714100e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4b760743-8d49-48d5-bca6-15f5236e3f7b"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("75fb6394-ab90-4b78-9802-7ff3c9afdbc0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7dd82b97-1eb2-4c37-9c3d-e26dd84878a0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8c5904a9-bfab-4b0f-b12b-b5fc795e6231"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("94e73f37-e260-4c6f-930b-8bd65c9c8a11"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("96fcb0c2-807e-4f7d-a28b-14ba6f9cb9b4"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9912f515-b2aa-4d19-9d2f-c2c94cb1212e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b0c21023-aa37-49cb-ad91-3ba005d8550d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bec8f441-5b73-4f11-87b8-a47fbc1d140f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c994999b-02dd-46c2-abc4-00c4787e629f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e0d85412-0717-4648-a972-f393a6aafaa8"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e673a37c-8ffc-46bf-a66d-18b8078d7c94"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("eb13b5e6-b8fd-4e11-99ef-446e9e752558"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f1342f7d-ff72-4bfb-8a36-8368dec7b088"));
        }
    }
}
