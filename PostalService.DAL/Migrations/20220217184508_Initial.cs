using Microsoft.EntityFrameworkCore.Migrations;

namespace PostalService.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    DateOfDeparture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CityOfDeparture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsReceived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "Email", "Gender", "Name", "Phone" },
                values: new object[,]
                {
                    { 0, "909 Box Street, Worton, Indiana, 637", 33, "richmondmccarty@accufarm.com", "male", "Richmond Mccarty", "+1 (894) 437-2065" },
                    { 17, "356 Vine Street, Lorraine, Arizona, 2095", 20, "lavernerichards@accufarm.com", "female", "Laverne Richards", "+1 (844) 424-3526" },
                    { 16, "705 Arion Place, Spokane, West Virginia, 9127", 25, "maddenmunoz@accufarm.com", "male", "Madden Munoz", "+1 (994) 469-3467" },
                    { 15, "237 Hubbard Place, Mappsville, Pennsylvania, 5516", 23, "tamerabrown@accufarm.com", "female", "Tamera Brown", "+1 (958) 413-3631" },
                    { 14, "416 Bush Street, Kempton, Federated States Of Micronesia, 5660", 29, "calliebryan@accufarm.com", "female", "Callie Bryan", "+1 (992) 503-3878" },
                    { 13, "706 Pineapple Street, Beaulieu, New Jersey, 3592", 27, "kellycharles@accufarm.com", "female", "Kelly Charles", "+1 (947) 514-2550" },
                    { 12, "323 Chester Street, Dola, South Carolina, 1712", 31, "gentrybaxter@accufarm.com", "male", "Gentry Baxter", "+1 (818) 425-2850" },
                    { 11, "758 Amboy Street, Glendale, Texas, 1933", 31, "louisaclayton@accufarm.com", "female", "Louisa Clayton", "+1 (826) 483-3284" },
                    { 10, "617 Maujer Street, Camas, Northern Mariana Islands, 8294", 21, "glasspuckett@accufarm.com", "male", "Glass Puckett", "+1 (887) 549-3708" },
                    { 9, "455 Calyer Street, Hegins, Michigan, 8471", 30, "adelapennington@accufarm.com", "female", "Adela Pennington", "+1 (901) 474-2632" },
                    { 8, "892 Jefferson Street, Sutton, Florida, 7400", 33, "kristinsims@accufarm.com", "female", "Kristin Sims", "+1 (841) 587-2856" },
                    { 7, "564 Balfour Place, Gorham, Maine, 4205", 25, "newtonhaley@accufarm.com", "male", "Newton Haley", "+1 (938) 495-3273" },
                    { 6, "791 Oakland Place, Franklin, Louisiana, 5163", 37, "lynettemartinez@accufarm.com", "female", "Lynette Martinez", "+1 (954) 486-3738" },
                    { 5, "438 Manor Court, Wauhillau, Virginia, 4427", 31, "florencehoover@accufarm.com", "female", "Florence Hoover", "+1 (921) 493-3196" },
                    { 4, "271 Delmonico Place, Garnet, Connecticut, 862", 39, "bertiemccullough@accufarm.com", "female", "Bertie Mccullough", "+1 (834) 546-2323" },
                    { 3, "617 Paerdegat Avenue, Sanford, Palau, 2782", 39, "dunlapblanchard@accufarm.com", "male", "Dunlap Blanchard", "+1 (995) 442-3546" },
                    { 2, "714 Church Lane, Cloverdale, North Carolina, 545", 21, "tammibarber@accufarm.com", "female", "Tammi Barber", "+1 (851) 522-2432" },
                    { 1, "187 Hull Street, Hannasville, Wisconsin, 3600", 25, "savannahjordan@accufarm.com", "female", "Savannah Jordan", "+1 (803) 424-2419" },
                    { 18, "649 Bedell Lane, Kula, Marshall Islands, 4887", 25, "esperanzagarrett@accufarm.com", "female", "Esperanza Garrett", "+1 (969) 477-2466" },
                    { 19, "669 Holt Court, Riner, Wyoming, 8151", 28, "robinsonhowe@accufarm.com", "male", "Robinson Howe", "+1 (979) 491-3145" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CityOfDeparture", "DateOfDeparture", "IsReceived", "Sender", "UserId", "Weight" },
                values: new object[,]
                {
                    { 27, "Blairstown, Maryland", "19-12-2020", false, "Wendy Curtis", 0, 33 },
                    { 4, "Hegins, Texas", "18-12-2016", false, "Oneill Fitzpatrick", 12, 91 },
                    { 20, "Celeryville, Michigan", "17-03-2015", false, "Myers Gentry", 12, 43 },
                    { 38, "Warren, Washington", "23-09-2019", true, "Chaney Obrien", 12, 76 },
                    { 2, "Corinne, Connecticut", "14-06-2019", true, "Russo Howe", 13, 15 },
                    { 33, "Ferney, Nevada", "24-02-2015", true, "Murray Stuart", 13, 8 },
                    { 34, "Nogal, Ohio", "26-10-2021", true, "Morton Dickerson", 13, 28 },
                    { 6, "Edinburg, Palau", "13-12-2016", false, "Valarie Aguilar", 14, 85 },
                    { 14, "Riegelwood, Kansas", "30-05-2014", false, "Marlene Foster", 14, 91 },
                    { 23, "Kimmell, Oklahoma", "09-05-2019", false, "Abby Sawyer", 14, 24 },
                    { 31, "Madrid, Virginia", "26-06-2015", true, "Weaver Long", 15, 14 },
                    { 1, "Blanford, Georgia", "05-07-2019", false, "Bailey Dunn", 16, 26 },
                    { 3, "Balm, Idaho", "14-07-2014", false, "Stuart Powell", 16, 76 },
                    { 17, "Rivera, American Samoa", "29-02-2020", true, "Nina Carver", 16, 63 },
                    { 19, "Baker, Alaska", "18-01-2018", true, "Tonya Aguirre", 16, 70 },
                    { 28, "Day, Rhode Island", "11-01-2020", false, "Chris Moran", 17, 31 },
                    { 37, "Lutsen, North Dakota", "05-02-2015", true, "Mills Gonzalez", 17, 83 },
                    { 5, "Tilden, Mississippi", "05-09-2014", true, "Haney Patterson", 18, 4 },
                    { 15, "Dunlo, District Of Columbia", "16-11-2019", true, "Garrison Best", 18, 52 },
                    { 22, "Wildwood, Hawaii", "24-03-2015", true, "Evans Parsons", 18, 22 },
                    { 40, "Dante, Arizona", "23-03-2021", false, "Yesenia Gay", 10, 39 },
                    { 44, "Evergreen, Louisiana", "13-05-2016", false, "Blanca Mills", 18, 23 },
                    { 24, "Brooktrails, Arkansas", "14-05-2021", true, "Compton Beasley", 10, 60 },
                    { 11, "Sunriver, Utah", "06-07-2017", true, "Maxine Hardy", 10, 71 },
                    { 32, "Gerton, Tennessee", "21-06-2019", true, "Lorie Jimenez", 0, 1 },
                    { 0, "Coloma, Colorado", "02-01-2021", true, "Ramsey Fuller", 1, 100 },
                    { 7, "Ironton, Marshall Islands", "29-07-2016", true, "Staci Black", 1, 34 },
                    { 35, "Brandermill, Illinois", "08-09-2020", true, "Justine Byrd", 1, 81 },
                    { 25, "Advance, North Carolina", "05-06-2019", true, "Marcia Herrera", 3, 23 },
                    { 18, "Eggertsville, Wisconsin", "19-06-2014", true, "Anderson Kirk", 4, 25 },
                    { 41, "Gila, Northern Mariana Islands", "23-04-2016", false, "Laura Branch", 4, 42 },
                    { 29, "Heil, Kentucky", "17-09-2020", true, "Sophia Mcmillan", 5, 1 },
                    { 8, "Waikele, California", "09-10-2015", true, "Berta Watkins", 6, 88 },
                    { 10, "Gordon, Guam", "06-11-2018", true, "Laurie Heath", 6, 39 },
                    { 13, "Lopezo, South Carolina", "17-12-2019", false, "Kirsten Bradford", 6, 86 },
                    { 16, "Freeburn, New Mexico", "10-12-2017", false, "Rena Wheeler", 6, 20 },
                    { 26, "Welda, Massachusetts", "29-08-2017", false, "Jodi Barrera", 6, 60 },
                    { 39, "Rosedale, Florida", "01-01-2022", false, "Knapp Odom", 7, 97 },
                    { 43, "Gloucester, Delaware", "23-10-2018", true, "Everett Reid", 7, 38 },
                    { 36, "Callaghan, Indiana", "20-06-2021", true, "Jeanne Wilkins", 8, 28 },
                    { 21, "Chicopee, New Hampshire", "28-05-2015", false, "Melba Mcmahon", 9, 84 },
                    { 30, "Norvelt, West Virginia", "23-09-2017", false, "Floyd Meyer", 9, 53 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CityOfDeparture", "DateOfDeparture", "IsReceived", "Sender", "UserId", "Weight" },
                values: new object[] { 9, "Southview, Pennsylvania", "27-11-2015", true, "Wells Nielsen", 10, 92 });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CityOfDeparture", "DateOfDeparture", "IsReceived", "Sender", "UserId", "Weight" },
                values: new object[] { 12, "Southmont, Montana", "17-12-2016", false, "Kristy Berry", 10, 88 });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CityOfDeparture", "DateOfDeparture", "IsReceived", "Sender", "UserId", "Weight" },
                values: new object[] { 42, "Oley, Wyoming", "07-04-2015", false, "Dean Burt", 19, 40 });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_UserId",
                table: "Packages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
