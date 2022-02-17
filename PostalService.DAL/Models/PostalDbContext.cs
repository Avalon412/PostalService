using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.DAL.Models
{
    public class PostalDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PackageModel> Packages { get; set; }

        public PostalDbContext(DbContextOptions<PostalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = new UserModel[]
            {
                new UserModel {Id = 0, Name = "Richmond Mccarty", Age = 33, Gender = "male", Email = "richmondmccarty@accufarm.com", Phone = "+1 (894) 437-2065", Address = "909 Box Street, Worton, Indiana, 637"},
                new UserModel {Id = 1, Name = "Savannah Jordan", Age = 25, Gender = "female", Email = "savannahjordan@accufarm.com", Phone = "+1 (803) 424-2419", Address = "187 Hull Street, Hannasville, Wisconsin, 3600"},
                new UserModel {Id = 2, Name = "Tammi Barber", Age = 21, Gender = "female", Email = "tammibarber@accufarm.com", Phone = "+1 (851) 522-2432", Address = "714 Church Lane, Cloverdale, North Carolina, 545"},
                new UserModel {Id = 3, Name = "Dunlap Blanchard", Age = 39, Gender = "male", Email = "dunlapblanchard@accufarm.com", Phone = "+1 (995) 442-3546", Address = "617 Paerdegat Avenue, Sanford, Palau, 2782"},
                new UserModel {Id = 4, Name = "Bertie Mccullough", Age = 39, Gender = "female", Email = "bertiemccullough@accufarm.com", Phone = "+1 (834) 546-2323", Address = "271 Delmonico Place, Garnet, Connecticut, 862"},
                new UserModel {Id = 5, Name = "Florence Hoover", Age = 31, Gender = "female", Email = "florencehoover@accufarm.com", Phone = "+1 (921) 493-3196", Address = "438 Manor Court, Wauhillau, Virginia, 4427"},
                new UserModel {Id = 6, Name = "Lynette Martinez", Age = 37, Gender = "female", Email = "lynettemartinez@accufarm.com", Phone = "+1 (954) 486-3738", Address = "791 Oakland Place, Franklin, Louisiana, 5163"},
                new UserModel {Id = 7, Name = "Newton Haley", Age = 25, Gender = "male", Email = "newtonhaley@accufarm.com", Phone = "+1 (938) 495-3273", Address = "564 Balfour Place, Gorham, Maine, 4205"},
                new UserModel {Id = 8, Name = "Kristin Sims", Age = 33, Gender = "female", Email = "kristinsims@accufarm.com", Phone = "+1 (841) 587-2856", Address = "892 Jefferson Street, Sutton, Florida, 7400"},
                new UserModel {Id = 9, Name = "Adela Pennington", Age = 30, Gender = "female", Email = "adelapennington@accufarm.com", Phone = "+1 (901) 474-2632", Address = "455 Calyer Street, Hegins, Michigan, 8471"},
                new UserModel {Id = 10, Name = "Glass Puckett", Age = 21, Gender = "male", Email = "glasspuckett@accufarm.com", Phone = "+1 (887) 549-3708", Address = "617 Maujer Street, Camas, Northern Mariana Islands, 8294"},
                new UserModel {Id = 11, Name = "Louisa Clayton", Age = 31, Gender = "female", Email = "louisaclayton@accufarm.com", Phone = "+1 (826) 483-3284", Address = "758 Amboy Street, Glendale, Texas, 1933"},
                new UserModel {Id = 12, Name = "Gentry Baxter", Age = 31, Gender = "male", Email = "gentrybaxter@accufarm.com", Phone = "+1 (818) 425-2850", Address = "323 Chester Street, Dola, South Carolina, 1712"},
                new UserModel {Id = 13, Name = "Kelly Charles", Age = 27, Gender = "female", Email = "kellycharles@accufarm.com", Phone = "+1 (947) 514-2550", Address = "706 Pineapple Street, Beaulieu, New Jersey, 3592"},
                new UserModel {Id = 14, Name = "Callie Bryan", Age = 29, Gender = "female", Email = "calliebryan@accufarm.com", Phone = "+1 (992) 503-3878", Address = "416 Bush Street, Kempton, Federated States Of Micronesia, 5660"},
                new UserModel {Id = 15, Name = "Tamera Brown", Age = 23, Gender = "female", Email = "tamerabrown@accufarm.com", Phone = "+1 (958) 413-3631", Address = "237 Hubbard Place, Mappsville, Pennsylvania, 5516"},
                new UserModel {Id = 16, Name = "Madden Munoz", Age = 25, Gender = "male", Email = "maddenmunoz@accufarm.com", Phone = "+1 (994) 469-3467", Address = "705 Arion Place, Spokane, West Virginia, 9127"},
                new UserModel {Id = 17, Name = "Laverne Richards", Age = 20, Gender = "female", Email = "lavernerichards@accufarm.com", Phone = "+1 (844) 424-3526", Address = "356 Vine Street, Lorraine, Arizona, 2095"},
                new UserModel {Id = 18, Name = "Esperanza Garrett", Age = 25, Gender = "female", Email = "esperanzagarrett@accufarm.com", Phone = "+1 (969) 477-2466", Address = "649 Bedell Lane, Kula, Marshall Islands, 4887"},
                new UserModel {Id = 19, Name = "Robinson Howe", Age = 28, Gender = "male", Email = "robinsonhowe@accufarm.com", Phone = "+1 (979) 491-3145", Address = "669 Holt Court, Riner, Wyoming, 8151"}
            };

            var packages = new PackageModel[]
            {
                new PackageModel {Id = 0, UserId = 1, Weight = 100, DateOfDeparture = "02-01-2021", Sender = "Ramsey Fuller", CityOfDeparture = "Coloma, Colorado", IsReceived = true},
                new PackageModel {Id = 1, UserId = 16, Weight = 26, DateOfDeparture = "05-07-2019", Sender = "Bailey Dunn", CityOfDeparture = "Blanford, Georgia", IsReceived = false},
                new PackageModel {Id = 2, UserId = 13, Weight = 15, DateOfDeparture = "14-06-2019", Sender = "Russo Howe", CityOfDeparture = "Corinne, Connecticut", IsReceived = true},
                new PackageModel {Id = 3, UserId = 16, Weight = 76, DateOfDeparture = "14-07-2014", Sender = "Stuart Powell", CityOfDeparture = "Balm, Idaho", IsReceived = false},
                new PackageModel {Id = 4, UserId = 12, Weight = 91, DateOfDeparture = "18-12-2016", Sender = "Oneill Fitzpatrick", CityOfDeparture = "Hegins, Texas", IsReceived = false},
                new PackageModel {Id = 5, UserId = 18, Weight = 4, DateOfDeparture = "05-09-2014", Sender = "Haney Patterson", CityOfDeparture = "Tilden, Mississippi", IsReceived = true},
                new PackageModel {Id = 6, UserId = 14, Weight = 85, DateOfDeparture = "13-12-2016", Sender = "Valarie Aguilar", CityOfDeparture = "Edinburg, Palau", IsReceived = false},
                new PackageModel {Id = 7, UserId = 1, Weight = 34, DateOfDeparture = "29-07-2016", Sender = "Staci Black", CityOfDeparture = "Ironton, Marshall Islands", IsReceived = true},
                new PackageModel {Id = 8, UserId = 6, Weight = 88, DateOfDeparture = "09-10-2015", Sender = "Berta Watkins", CityOfDeparture = "Waikele, California", IsReceived = true},
                new PackageModel {Id = 9, UserId = 10, Weight = 92, DateOfDeparture = "27-11-2015", Sender = "Wells Nielsen", CityOfDeparture = "Southview, Pennsylvania", IsReceived = true},
                new PackageModel {Id = 10, UserId = 6, Weight = 39, DateOfDeparture = "06-11-2018", Sender = "Laurie Heath", CityOfDeparture = "Gordon, Guam", IsReceived = true},
                new PackageModel {Id = 11, UserId = 10, Weight = 71, DateOfDeparture = "06-07-2017", Sender = "Maxine Hardy", CityOfDeparture = "Sunriver, Utah", IsReceived = true},
                new PackageModel {Id = 12, UserId = 10, Weight = 88, DateOfDeparture = "17-12-2016", Sender = "Kristy Berry", CityOfDeparture = "Southmont, Montana", IsReceived = false},
                new PackageModel {Id = 13, UserId = 6, Weight = 86, DateOfDeparture = "17-12-2019", Sender = "Kirsten Bradford", CityOfDeparture = "Lopezo, South Carolina", IsReceived = false},
                new PackageModel {Id = 14, UserId = 14, Weight = 91, DateOfDeparture = "30-05-2014", Sender = "Marlene Foster", CityOfDeparture = "Riegelwood, Kansas", IsReceived = false},
                new PackageModel {Id = 15, UserId = 18, Weight = 52, DateOfDeparture = "16-11-2019", Sender = "Garrison Best", CityOfDeparture = "Dunlo, District Of Columbia", IsReceived = true},
                new PackageModel {Id = 16, UserId = 6, Weight = 20, DateOfDeparture = "10-12-2017", Sender = "Rena Wheeler", CityOfDeparture = "Freeburn, New Mexico", IsReceived = false},
                new PackageModel {Id = 17, UserId = 16, Weight = 63, DateOfDeparture = "29-02-2020", Sender = "Nina Carver", CityOfDeparture = "Rivera, American Samoa", IsReceived = true},
                new PackageModel {Id = 18, UserId = 4, Weight = 25, DateOfDeparture = "19-06-2014", Sender = "Anderson Kirk", CityOfDeparture = "Eggertsville, Wisconsin", IsReceived = true},
                new PackageModel {Id = 19, UserId = 16, Weight = 70, DateOfDeparture = "18-01-2018", Sender = "Tonya Aguirre", CityOfDeparture = "Baker, Alaska", IsReceived = true},
                new PackageModel {Id = 20, UserId = 12, Weight = 43, DateOfDeparture = "17-03-2015", Sender = "Myers Gentry", CityOfDeparture = "Celeryville, Michigan", IsReceived = false},
                new PackageModel {Id = 21, UserId = 9, Weight = 84, DateOfDeparture = "28-05-2015", Sender = "Melba Mcmahon", CityOfDeparture = "Chicopee, New Hampshire", IsReceived = false},
                new PackageModel {Id = 22, UserId = 18, Weight = 22, DateOfDeparture = "24-03-2015", Sender = "Evans Parsons", CityOfDeparture = "Wildwood, Hawaii", IsReceived = true},
                new PackageModel {Id = 23, UserId = 14, Weight = 24, DateOfDeparture = "09-05-2019", Sender = "Abby Sawyer", CityOfDeparture = "Kimmell, Oklahoma", IsReceived = false},
                new PackageModel {Id = 24, UserId = 10, Weight = 60, DateOfDeparture = "14-05-2021", Sender = "Compton Beasley", CityOfDeparture = "Brooktrails, Arkansas", IsReceived = true},
                new PackageModel {Id = 25, UserId = 3, Weight = 23, DateOfDeparture = "05-06-2019", Sender = "Marcia Herrera", CityOfDeparture = "Advance, North Carolina", IsReceived = true},
                new PackageModel {Id = 26, UserId = 6, Weight = 60, DateOfDeparture = "29-08-2017", Sender = "Jodi Barrera", CityOfDeparture = "Welda, Massachusetts", IsReceived = false},
                new PackageModel {Id = 27, UserId = 0, Weight = 33, DateOfDeparture = "19-12-2020", Sender = "Wendy Curtis", CityOfDeparture = "Blairstown, Maryland", IsReceived = false},
                new PackageModel {Id = 28, UserId = 17, Weight = 31, DateOfDeparture = "11-01-2020", Sender = "Chris Moran", CityOfDeparture = "Day, Rhode Island", IsReceived = false},
                new PackageModel {Id = 29, UserId = 5, Weight = 1, DateOfDeparture = "17-09-2020", Sender = "Sophia Mcmillan", CityOfDeparture = "Heil, Kentucky", IsReceived = true},
                new PackageModel {Id = 30, UserId = 9, Weight = 53, DateOfDeparture = "23-09-2017", Sender = "Floyd Meyer", CityOfDeparture = "Norvelt, West Virginia", IsReceived = false},
                new PackageModel {Id = 31, UserId = 15, Weight = 14, DateOfDeparture = "26-06-2015", Sender = "Weaver Long", CityOfDeparture = "Madrid, Virginia", IsReceived = true},
                new PackageModel {Id = 32, UserId = 0, Weight = 1, DateOfDeparture = "21-06-2019", Sender = "Lorie Jimenez", CityOfDeparture = "Gerton, Tennessee", IsReceived = true},
                new PackageModel {Id = 33, UserId = 13, Weight = 8, DateOfDeparture = "24-02-2015", Sender = "Murray Stuart", CityOfDeparture = "Ferney, Nevada", IsReceived = true},
                new PackageModel {Id = 34, UserId = 13, Weight = 28, DateOfDeparture = "26-10-2021", Sender = "Morton Dickerson", CityOfDeparture = "Nogal, Ohio", IsReceived = true},
                new PackageModel {Id = 35, UserId = 1, Weight = 81, DateOfDeparture = "08-09-2020", Sender = "Justine Byrd", CityOfDeparture = "Brandermill, Illinois", IsReceived = true},
                new PackageModel {Id = 36, UserId = 8, Weight = 28, DateOfDeparture = "20-06-2021", Sender = "Jeanne Wilkins", CityOfDeparture = "Callaghan, Indiana", IsReceived = true},
                new PackageModel {Id = 37, UserId = 17, Weight = 83, DateOfDeparture = "05-02-2015", Sender = "Mills Gonzalez", CityOfDeparture = "Lutsen, North Dakota", IsReceived = true},
                new PackageModel {Id = 38, UserId = 12, Weight = 76, DateOfDeparture = "23-09-2019", Sender = "Chaney Obrien", CityOfDeparture = "Warren, Washington", IsReceived = true},
                new PackageModel {Id = 39, UserId = 7, Weight = 97, DateOfDeparture = "01-01-2022", Sender = "Knapp Odom", CityOfDeparture = "Rosedale, Florida", IsReceived = false},
                new PackageModel {Id = 40, UserId = 10, Weight = 39, DateOfDeparture = "23-03-2021", Sender = "Yesenia Gay", CityOfDeparture = "Dante, Arizona", IsReceived = false},
                new PackageModel {Id = 41, UserId = 4, Weight = 42, DateOfDeparture = "23-04-2016", Sender = "Laura Branch", CityOfDeparture = "Gila, Northern Mariana Islands", IsReceived = false},
                new PackageModel {Id = 42, UserId = 19, Weight = 40, DateOfDeparture = "07-04-2015", Sender = "Dean Burt", CityOfDeparture = "Oley, Wyoming", IsReceived = false},
                new PackageModel {Id = 43, UserId = 7, Weight = 38, DateOfDeparture = "23-10-2018", Sender = "Everett Reid", CityOfDeparture = "Gloucester, Delaware", IsReceived = true},
                new PackageModel {Id = 44, UserId = 18, Weight = 23, DateOfDeparture = "13-05-2016", Sender = "Blanca Mills", CityOfDeparture = "Evergreen, Louisiana", IsReceived = false}
            };
            modelBuilder.Entity<UserModel>().HasData(users);
            modelBuilder.Entity<PackageModel>().HasData(packages);
            base.OnModelCreating(modelBuilder);
        }
    }
}
