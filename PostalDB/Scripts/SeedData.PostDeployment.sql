/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE PostalDB
IF NOT EXISTS (SELECT * FROM dbo.Users)
BEGIN
	DBCC CHECKIDENT('[dbo].[Users]', RESEED, 0)
    INSERT INTO dbo.Users([Name], [Age], [Gender], [Email], [Phone], [Address])
    VALUES ('Richmond Mccarty', 33, 'male', 'richmondmccarty@accufarm.com', '+1 (894) 437-2065', '909 Box Street, Worton, Indiana, 637'),
           ('Savannah Jordan', 25, 'female', 'savannahjordan@accufarm.com', '+1 (803) 424-2419', '187 Hull Street, Hannasville, Wisconsin, 3600'),
           ('Tammi Barber', 21, 'female', 'tammibarber@accufarm.com', '+1 (851) 522-2432', '714 Church Lane, Cloverdale, North Carolina, 545'),
           ('Dunlap Blanchard', 39, 'male', 'dunlapblanchard@accufarm.com', '+1 (995) 442-3546', '617 Paerdegat Avenue, Sanford, Palau, 2782'),
           ('Bertie Mccullough', 39, 'female', 'bertiemccullough@accufarm.com', '+1 (834) 546-2323', '271 Delmonico Place, Garnet, Connecticut, 862'),
           ('Florence Hoover', 31, 'female', 'florencehoover@accufarm.com', '+1 (921) 493-3196', '438 Manor Court, Wauhillau, Virginia, 4427'),
           ('Lynette Martinez', 37, 'female', 'lynettemartinez@accufarm.com', '+1 (954) 486-3738', '791 Oakland Place, Franklin, Louisiana, 5163'),
           ('Newton Haley', 25, 'male', 'newtonhaley@accufarm.com', '+1 (938) 495-3273', '564 Balfour Place, Gorham, Maine, 4205'),
           ('Kristin Sims', 33, 'female', 'kristinsims@accufarm.com', '+1 (841) 587-2856', '892 Jefferson Street, Sutton, Florida, 7400'),
           ('Adela Pennington', 30, 'female', 'adelapennington@accufarm.com', '+1 (901) 474-2632', '455 Calyer Street, Hegins, Michigan, 8471'),
           ('Glass Puckett', 21, 'male', 'glasspuckett@accufarm.com', '+1 (887) 549-3708', '617 Maujer Street, Camas, Northern Mariana Islands, 8294'),
           ('Louisa Clayton', 31, 'female', 'louisaclayton@accufarm.com', '+1 (826) 483-3284', '758 Amboy Street, Glendale, Texas, 1933'),
           ('Gentry Baxter', 31, 'male', 'gentrybaxter@accufarm.com', '+1 (818) 425-2850', '323 Chester Street, Dola, South Carolina, 1712'),
           ('Kelly Charles', 27, 'female', 'kellycharles@accufarm.com', '+1 (947) 514-2550', '706 Pineapple Street, Beaulieu, New Jersey, 3592'),
           ('Callie Bryan', 29, 'female', 'calliebryan@accufarm.com', '+1 (992) 503-3878', '416 Bush Street, Kempton, Federated States Of Micronesia, 5660'),
           ('Tamera Brown', 23, 'female', 'tamerabrown@accufarm.com', '+1 (958) 413-3631', '237 Hubbard Place, Mappsville, Pennsylvania, 5516'),
           ('Madden Munoz', 25, 'male', 'maddenmunoz@accufarm.com', '+1 (994) 469-3467', '705 Arion Place, Spokane, West Virginia, 9127'),
           ('Laverne Richards', 20, 'female', 'lavernerichards@accufarm.com', '+1 (844) 424-3526', '356 Vine Street, Lorraine, Arizona, 2095'),
           ('Esperanza Garrett', 25, 'female', 'esperanzagarrett@accufarm.com', '+1 (969) 477-2466', '649 Bedell Lane, Kula, Marshall Islands, 4887'),
           ('Robinson Howe', 28, 'male', 'robinsonhowe@accufarm.com', '+1 (979) 491-3145', '669 Holt Court, Riner, Wyoming, 8151')
END
IF NOT EXISTS (SELECT * FROM dbo.Packages)
BEGIN
	DBCC CHECKIDENT('[dbo].[Packages]', RESEED, 0)
    INSERT INTO dbo.Packages([UserId], [Weight], [DateOfDeparture], [Sender], [CityOfDeparture], [IsReceived])
    VALUES (2, 100, CONVERT(DATETIME, '02-01-2021', 103), 'Ramsey Fuller', 'Coloma, Colorado', 1),
           (17, 26, CONVERT(DATETIME, '05-07-2019', 103), 'Bailey Dunn', 'Blanford, Georgia', 0),
           (14, 15, CONVERT(DATETIME, '14-06-2019', 103), 'Russo Howe', 'Corinne, Connecticut', 1),
           (17, 76, CONVERT(DATETIME, '14-07-2014', 103), 'Stuart Powell', 'Balm, Idaho', 0),
           (13, 91, CONVERT(DATETIME, '18-12-2016', 103), 'Oneill Fitzpatrick', 'Hegins, Texas', 0),
           (19, 4, CONVERT(DATETIME, '05-09-2014', 103), 'Haney Patterson', 'Tilden, Mississippi', 1),
           (15, 85, CONVERT(DATETIME, '13-12-2016', 103), 'Valarie Aguilar', 'Edinburg, Palau', 0),
           (2, 34, CONVERT(DATETIME, '29-07-2016', 103), 'Staci Black', 'Ironton, Marshall Islands', 1),
           (7, 88, CONVERT(DATETIME, '09-10-2015', 103), 'Berta Watkins', 'Waikele, California', 1),
           (11, 92, CONVERT(DATETIME, '27-11-2015', 103), 'Wells Nielsen', 'Southview, Pennsylvania', 1),
           (7, 39, CONVERT(DATETIME, '06-11-2018', 103), 'Laurie Heath', 'Gordon, Guam', 1),
           (11, 71, CONVERT(DATETIME, '06-07-2017', 103), 'Maxine Hardy', 'Sunriver, Utah', 1),
           (11, 88, CONVERT(DATETIME, '17-12-2016', 103), 'Kristy Berry', 'Southmont, Montana', 0),
           (7, 86, CONVERT(DATETIME, '17-12-2019', 103), 'Kirsten Bradford', 'Lopezo, South Carolina', 0),
           (15, 91, CONVERT(DATETIME, '30-05-2014', 103), 'Marlene Foster', 'Riegelwood, Kansas', 0),
           (19, 52, CONVERT(DATETIME, '16-11-2019', 103), 'Garrison Best', 'Dunlo, District Of Columbia', 1),
           (7, 20, CONVERT(DATETIME, '10-12-2017', 103), 'Rena Wheeler', 'Freeburn, New Mexico', 0),
           (17, 63, CONVERT(DATETIME, '29-02-2020', 103), 'Nina Carver', 'Rivera, American Samoa', 1),
           (5, 25, CONVERT(DATETIME, '19-06-2014', 103), 'Anderson Kirk', 'Eggertsville, Wisconsin', 1),
           (17, 70, CONVERT(DATETIME, '18-01-2018', 103), 'Tonya Aguirre', 'Baker, Alaska', 1),
           (13, 43, CONVERT(DATETIME, '17-03-2015', 103), 'Myers Gentry', 'Celeryville, Michigan', 0),
           (10, 84, CONVERT(DATETIME, '28-05-2015', 103), 'Melba Mcmahon', 'Chicopee, New Hampshire', 0),
           (19, 22, CONVERT(DATETIME, '24-03-2015', 103), 'Evans Parsons', 'Wildwood, Hawaii', 1),
           (15, 24, CONVERT(DATETIME, '09-05-2019', 103), 'Abby Sawyer', 'Kimmell, Oklahoma', 0),
           (11, 60, CONVERT(DATETIME, '14-05-2021', 103), 'Compton Beasley', 'Brooktrails, Arkansas', 1),
           (4, 23, CONVERT(DATETIME, '05-06-2019', 103), 'Marcia Herrera', 'Advance, North Carolina', 1),
           (7, 60, CONVERT(DATETIME, '29-08-2017', 103), 'Jodi Barrera', 'Welda, Massachusetts', 0),
           (1, 33, CONVERT(DATETIME, '19-12-2020', 103), 'Wendy Curtis', 'Blairstown, Maryland', 0),
           (18, 31, CONVERT(DATETIME, '11-01-2020', 103), 'Chris Moran', 'Day, Rhode Island', 0),
           (6, 1, CONVERT(DATETIME, '17-09-2020', 103), 'Sophia Mcmillan', 'Heil, Kentucky', 1),
           (10, 53, CONVERT(DATETIME, '23-09-2017', 103), 'Floyd Meyer', 'Norvelt, West Virginia', 0),
           (16, 14, CONVERT(DATETIME, '26-06-2015', 103), 'Weaver Long', 'Madrid, Virginia', 1),
           (1, 1, CONVERT(DATETIME, '21-06-2019', 103), 'Lorie Jimenez', 'Gerton, Tennessee', 1),
           (14, 8, CONVERT(DATETIME, '24-02-2015', 103), 'Murray Stuart', 'Ferney, Nevada', 1),
           (14, 28, CONVERT(DATETIME, '26-10-2021', 103), 'Morton Dickerson', 'Nogal, Ohio', 1),
           (2, 81, CONVERT(DATETIME, '08-09-2020', 103), 'Justine Byrd', 'Brandermill, Illinois', 1),
           (9, 28, CONVERT(DATETIME, '20-06-2021', 103), 'Jeanne Wilkins', 'Callaghan, Indiana', 1),
           (18, 83, CONVERT(DATETIME, '05-02-2015', 103), 'Mills Gonzalez', 'Lutsen, North Dakota', 1),
           (13, 76, CONVERT(DATETIME, '23-09-2019', 103), 'Chaney Obrien', 'Warren, Washington', 1),
           (8, 97, CONVERT(DATETIME, '01-01-2022', 103), 'Knapp Odom', 'Rosedale, Florida', 0),
           (11, 39, CONVERT(DATETIME, '23-03-2021', 103), 'Yesenia Gay', 'Dante, Arizona', 0),
           (5, 42, CONVERT(DATETIME, '23-04-2016', 103), 'Laura Branch', 'Gila, Northern Mariana Islands', 0),
           (20, 40, CONVERT(DATETIME, '07-04-2015', 103), 'Dean Burt', 'Oley, Wyoming', 0),
           (8, 38, CONVERT(DATETIME, '23-10-2018', 103), 'Everett Reid', 'Gloucester, Delaware', 1),
           (19, 23, CONVERT(DATETIME, '13-05-2016', 103), 'Blanca Mills', 'Evergreen, Louisiana', 0)
END