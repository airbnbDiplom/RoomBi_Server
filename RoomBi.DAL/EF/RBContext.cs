using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.EF
{
    public class RBContext : DbContext
    {
        public static readonly String SchemaName = "RoomBiSchemaName";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //схема - як спосіб розділення проєктів в одній БД
            modelBuilder.HasDefaultSchema(SchemaName);
        }
        public RBContext(DbContextOptions<RBContext> options)
          : base(options)
        {
            if (Database.EnsureCreated())
            {
                #region Сontinent
                Сontinent.Add(new Сontinent { Name = "Європа" });
                Сontinent.Add(new Сontinent { Name = "Африка" });
                Сontinent.Add(new Сontinent { Name = "Північна Америка" });
                Сontinent.Add(new Сontinent { Name = "Південна Америка" });
                Сontinent.Add(new Сontinent { Name = "Австралія" });
                #endregion
                #region Languages
                Languages.Add(new Language { Name = "Англійська" }); // English
                Languages.Add(new Language { Name = "Українська" });
                Languages.Add(new Language { Name = "Французька" });
                Languages.Add(new Language { Name = "Німецька" });
                Languages.Add(new Language { Name = "Італійська" });
                Languages.Add(new Language { Name = "Португальська" });
                Languages.Add(new Language { Name = "Польська" });
                Languages.Add(new Language { Name = "Японська" });
                Languages.Add(new Language { Name = "Іспанська" });
                Languages.Add(new Language { Name = "Арабська" });
                Languages.Add(new Language { Name = "Турецька" });
                Languages.Add(new Language { Name = "Фінська" });
                #endregion
                #region Countries
                Countries.Add(new Country { Name = "Україна", PhoneCode = "+380" });
                Countries.Add(new Country { Name = "Велика Британія", PhoneCode = "+44" });
                Countries.Add(new Country { Name = "Румунія", PhoneCode = "+40" });
                Countries.Add(new Country { Name = "Німеччина", PhoneCode = "+49" });
                Countries.Add(new Country { Name = "Італія", PhoneCode = "+39" });
                Countries.Add(new Country { Name = "Польша", PhoneCode = "+48" });
                #endregion
                #region Locations
                Locations.Add(new Location { Name = "На пляжі" }); //OnBeach
                Locations.Add(new Location { Name = "Арктика" }); // Arctic
                Locations.Add(new Location { Name = "Поряд є озеро" }); // ThereIsLakeNearby
                Locations.Add(new Location { Name = "Острови" }); // islands
                Locations.Add(new Location { Name = "Тропіки" }); // Tropics
                Locations.Add(new Location { Name = "Національні парки" }); // NationalParks
                Locations.Add(new Location { Name = "Місто мрії" }); // CityOfDreams
                Locations.Add(new Location { Name = "Пустеля" }); // Desert
                Locations.Add(new Location { Name = "Біля пляжу" }); // NearTheBeach

                #endregion
                #region Houses
                Houses.Add(new House { Name = "Особняки" }); // Mansions
                Houses.Add(new House { Name = "Будинки" }); // Houses
                Houses.Add(new House { Name = "Купольні будинки" }); // DomeHouses
                Houses.Add(new House { Name = "Мікро будинки" }); // MicroHouses
                Houses.Add(new House { Name = "Заміські будинки" }); // CountryHouses
                Houses.Add(new House { Name = "Кемпінги" }); // Campsites
                Houses.Add(new House { Name = "Будиночки на дереві" }); // HousesOnTree
                Houses.Add(new House { Name = "Автономні будинки" }); // AutonomousHous
                Houses.Add(new House { Name = "Ферми" }); // Farms
                Houses.Add(new House { Name = "Халупи" }); // Shacks
                Houses.Add(new House { Name = "Апартаменти" }); // Rooms
                Houses.Add(new House { Name = "Будинок на колесах" }); // HouseWheels
                Houses.Add(new House { Name = "Печери" }); // Caves
                Houses.Add(new House { Name = "Земляні будинки" }); // EarthenHouses
                Houses.Add(new House { Name = "Замки" }); // Castles
                Houses.Add(new House { Name = "Будинки з історією" }); // HousesWithHistory
                Houses.Add(new House { Name = "Люкс" }); // Luxe
                Houses.Add(new House { Name = "Ханоки" }); // Hanokah
                Houses.Add(new House { Name = "Кікладські будинки" }); // CycladicHouses
                Houses.Add(new House { Name = "Вітряні млини" }); // Windmills
                Houses.Add(new House { Name = "Вівчарські вози" }); // ShepherdWagons
                Houses.Add(new House { Name = "Рьокани" }); // Ryokans
                Houses.Add(new House { Name = "Юрти" }); // Yurts
                Houses.Add(new House { Name = "Мінсу" }); // Minsu
                Houses.Add(new House { Name = "Сараї" }); // Barns
                Houses.Add(new House { Name = "Вежі" }); // Towers
                Houses.Add(new House { Name = "Плавучі будинки" }); // FloatingHouses
                Houses.Add(new House { Name = "Човни" }); // Boats
                Houses.Add(new House { Name = "Ріади" }); // Riads
                Houses.Add(new House { Name = "Даммузо" }); // Dammuso
                Houses.Add(new House { Name = "Контейнери" }); // Containers
                #endregion
                #region Sports
                Sports.Add(new Sport { Name = "Серфінг" }); // Surfing
                Sports.Add(new Sport { Name = "Катання на лижах" }); // Skiing
                Sports.Add(new Sport { Name = "Виноградники" }); // Vineyards
                Sports.Add(new Sport { Name = "Гольф" }); // Golf
                Sports.Add(new Sport { Name = "B&B" }); // B&B
                SaveChanges();
                #endregion
                #region Users
                Users.Add(new User
                {
                    Name = "Jane Smith",
                    Password = "123",
                    Email = "jane.smith@example.com",
                    Address = "456 Oak St",
                    PhoneNumber = "+987654321",
                    LanguageId = 1,
                    CountryId = 1,
                    DateOfBirth = new DateTime(1985, 8, 22),
                    AirbnbRegistrationYear = new DateTime(2018, 6, 5),
                    ProfilePicture = "avatar1.jpg",
                    CurrentStatus = true,
                    UserStatus = true
                });
                Users.Add(new User
                {
                    Name = "John Doe",
                    Password = "123",
                    Email = "john.doe@example.com",
                    Address = "123 Main St",
                    PhoneNumber = "+123456789",
                    LanguageId = 2,
                    CountryId = 2,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    AirbnbRegistrationYear = new DateTime(2015, 3, 10),
                    ProfilePicture = "avatar2.jpg",
                    CurrentStatus = true,
                    UserStatus = true
                });
                Users.Add(new User
                {
                    Name = "Alice Johnson",
                    Password = "123",
                    Email = "alice.johnson@example.com",
                    Address = "789 Elm St",
                    PhoneNumber = "+987654321",
                    LanguageId = 2,
                    CountryId = 3,
                    DateOfBirth = new DateTime(1988, 11, 8),
                    AirbnbRegistrationYear = new DateTime(2016, 2, 22),
                    ProfilePicture = "avatar3.jpg",
                    CurrentStatus = true,
                    UserStatus = true
                });
                Users.Add(new User
                {
                    Name = "Bob Williams",
                    Password = "123",
                    Email = "bob.williams@example.com",
                    Address = "567 Pine St",
                    PhoneNumber = "+345678901",
                    LanguageId = 2,
                    CountryId = 4,
                    DateOfBirth = new DateTime(1995, 4, 20),
                    AirbnbRegistrationYear = new DateTime(2019, 7, 15),
                    ProfilePicture = "avatar4.jpg",
                    CurrentStatus = true,
                    UserStatus = true
                });
                Users.Add(new User
                {
                    Name = "Eva Brown",
                    Password = "123",
                    Email = "eva.brown@example.com",
                    Address = "321 Cedar St",
                    PhoneNumber = "+789012345",
                    LanguageId = 2,
                    CountryId = 5,
                    DateOfBirth = new DateTime(1982, 9, 18),
                    AirbnbRegistrationYear = new DateTime(2017, 11, 30),
                    ProfilePicture = "avatar5.jpg",
                    CurrentStatus = true,
                    UserStatus = true
                });
                Users.Add(new User
                {
                    Name = "Michael Green",
                    Password = "123",
                    Email = "michael.green@example.com",
                    Address = "876 Maple St",
                    PhoneNumber = "+234567890",
                    LanguageId = 1,
                    CountryId = 1,
                    DateOfBirth = new DateTime(1993, 6, 25),
                    AirbnbRegistrationYear = new DateTime(2020, 4, 12),
                    ProfilePicture = "avatar6.jpg",
                    CurrentStatus = true,
                    UserStatus = true
                });
                Users.Add(new User
                {
                    Name = "Sophia White",
                    Password = "123",
                    Email = "sophia.white@example.com",
                    Address = "654 Birch St",
                    PhoneNumber = "+456789012",
                    LanguageId = 2,
                    CountryId = 2,
                    DateOfBirth = new DateTime(1987, 3, 12),
                    AirbnbRegistrationYear = new DateTime(2014, 8, 8),
                    ProfilePicture = "avatar7.jpg",
                    CurrentStatus = true,
                    UserStatus = true
                });
                Users.Add(new User
                {
                    Name = "Cersei Lannister",
                    Password = "123",
                    Email = "cersei@example.com",
                    Address = "King's Landing",
                    PhoneNumber = "+4455667788",
                    DateOfBirth = new DateTime(1977, 12, 10),
                    AirbnbRegistrationYear = new DateTime(2017, 6, 18),
                    ProfilePicture = "cersei.jpg",
                    LanguageId = 2,
                    CountryId = 2,
                    CurrentStatus = true,
                    UserStatus = true,
                });
                Users.Add(new User
                {
                    Name = "Jon Snow",
                    Password = "123",
                    Email = "jon.snow@example.com",
                    Address = "Castle Black",
                    PhoneNumber = "+123456789",
                    ProfilePicture = "jon_snow.jpg",
                    DateOfBirth = new DateTime(2000, 5, 4),
                    AirbnbRegistrationYear = new DateTime(2022, 6, 10),
                    LanguageId = 2,
                    CountryId = 2,
                    CurrentStatus = true,
                    UserStatus = true,
                });
                Users.Add(new User
                {
                    Name = "Daenerys Targaryen",
                    Password = "123",
                    Email = "daenerys@example.com",
                    Address = "Dragonstone",
                    PhoneNumber = "+987654321",
                    ProfilePicture = "daenerys.jpg",
                    DateOfBirth = new DateTime(2001, 1, 1),
                    AirbnbRegistrationYear = new DateTime(2017, 3, 10),
                    LanguageId = 2,
                    CountryId = 2,
                    CurrentStatus = true,
                    UserStatus = true,
                });
                Users.Add(new User
                {
                    Name = "Arya Stark",
                    Password = "123",
                    Email = "arya@example.com",
                    Address = "Winterfell",
                    PhoneNumber = "+9988776655",
                    ProfilePicture = "arya.jpg",
                    DateOfBirth = new DateTime(1999, 7, 7),
                    AirbnbRegistrationYear = new DateTime(2018, 7, 7),
                    LanguageId = 2,
                    CountryId = 2,
                    CurrentStatus = true,
                    UserStatus = true,
                });
                Users.Add(new User
                {
                    Name = "Sansa Stark",
                    Password = "123",
                    Email = "sansa@example.com",
                    Address = "Winterfell",
                    PhoneNumber = "+2233445566",
                    ProfilePicture = "sansa.jpg",
                    DateOfBirth = new DateTime(1989, 3, 7),
                    AirbnbRegistrationYear = new DateTime(2008, 3, 7),
                    LanguageId = 2,
                    CountryId = 2,
                    CurrentStatus = true,
                    UserStatus = true,
                });
                Users.Add(new User
                {
                    Name = "Jaime Lannister",
                    Password = "123",
                    Email = "jaime@example.com",
                    Address = "Casterly Rock",
                    PhoneNumber = "+9988776655",
                    DateOfBirth = new DateTime(1979, 11, 30),
                    AirbnbRegistrationYear = new DateTime(2004, 7, 12),
                    ProfilePicture = "jaime.jpg",
                    LanguageId = 1,
                    CountryId = 1,
                    CurrentStatus = true,
                    UserStatus = true,
                });
                Users.Add(new User
                {
                    Name = "Maksim Dubovyi",
                    Password = "L1Lm6Mo+jJM5wqBRJSAuIrl2EwidaLZj/wMkx1IRb9ZPUhIn",
                    Email = "max@x.com",
                    Address = "Odessa",
                    PhoneNumber = "+380969774697",
                    DateOfBirth = new DateTime(1989, 08, 30),
                    AirbnbRegistrationYear = new DateTime(2004, 7, 12),
                    ProfilePicture = "max.jpg",
                    LanguageId = 2,
                    CountryId = 1,
                    CurrentStatus = true,
                    UserStatus = true,
                });
                SaveChanges();

                #endregion
                #region GuestPaymentMethods
                GuestPaymentMethods.Add(new GuestPaymentMethod
                {

                    CardNumber = "**** **** **** 1234",
                    ExpirationDate = "12/25",
                    CVV = "123",
                    CardType = "Visa",
                    IdUser = 14
                });
                GuestPaymentMethods.Add(new GuestPaymentMethod
                {

                    CardNumber = "**** **** **** 8989",
                    ExpirationDate = "11/28",
                    CVV = "303",
                    CardType = "MasterCard",
                    IdUser = 14
                });
                GuestPaymentMethods.Add(new GuestPaymentMethod
                {
                    CardNumber = "**** **** **** 5678",
                    ExpirationDate = "06/24",
                    CVV = "456",
                    CardType = "MasterCard",
                    IdUser = 2
                });
                GuestPaymentMethods.Add(new GuestPaymentMethod
                {
                    CardNumber = "**** **** **** 3412",
                    ExpirationDate = "10/25",
                    CVV = "767",
                    CardType = "Visa",
                    IdUser = 2
                });
                #endregion
                #region EmergencyContactPersons
                EmergencyContactPersons.Add(new EmergencyContactPerson
                {

                    Name = "Contact 1",
                    Сonnection = "Family",
                    PhoneNumber = "+1234567",
                    CountryId = 2,
                    IdUser = 1
                });
                EmergencyContactPersons.Add(new EmergencyContactPerson
                {

                    Name = "Emergency Contact 2",
                    Сonnection = "Friend",
                    PhoneNumber = "7654321",
                    CountryId = 1,
                    IdUser = 2
                });
                SaveChanges();
                #endregion 
                #region Profiles
                Profiles.Add(new Profile
                {
                    SchoolYears = "I spent my school years in a small town, surrounded by friendly faces and memorable experiences.",
                    Pets = "Currently, I have a mischievous but lovable cat named Whiskers who always keeps me on my toes.",
                    Job = "I work as a software engineer, crafting code that brings ideas to life and solving complex puzzles daily.",
                    MyLocation = "Currently, I call the vibrant city of [City Name] my home, where every day feels like a new adventure.",
                    MyLanguages = "Fluent in English and Spanish, I love connecting with people from different linguistic backgrounds.",
                    Generation = "Being a proud member of the millennial generation, I find joy in blending nostalgia with modern experiences.",
                    FavoriteSchoolSong = "One of my fondest memories from school is dancing to 'Don't Stop Believin'' by Journey with friends during prom.",
                    Passion = "My deep passion lies in photography, capturing moments that tell stories and evoke emotions.",
                    InterestingFact = "An interesting fact about me is that I once hiked to the top of a mountain just to watch the sunrise.",
                    UselessSkill = "My most useless skill is being able to recite the entire script of my favorite movie from start to finish.",
                    BiographyTitle = "If I had to title my biography, it would be 'Journey of Dreams: Embracing the Uncharted.'",
                    DailyActivity = "I spend hours exploring new books, trying out new recipes, and occasionally strumming my guitar to unwind."
                ,
                    IdUser = 1
                });
                Profiles.Add(new Profile
                {

                    SchoolYears = "Growing up in a bustling city, my school years were filled with diverse experiences and lifelong friendships.",
                    Pets = "At home, I share my space with a playful Golden Retriever named Max, who brings boundless joy into my life.",
                    Job = "I am a graphic designer, transforming ideas into visually captivating designs that resonate with people.",
                    MyLocation = "I currently reside in a cozy apartment in the heart of [City Name], where the city lights create a magical atmosphere.",
                    MyLanguages = "Fluent in French and English, I enjoy conversing in multiple languages to connect with people globally.",
                    Generation = "As a Gen Z individual, I embrace the fusion of technology and creativity that defines our era.",
                    FavoriteSchoolSong = "My favorite school song is 'Wonderwall' by Oasis, which never fails to bring back fond memories.",
                    Passion = "My immense love for nature fuels my passion for hiking, photography, and environmental conservation.",
                    InterestingFact = "An interesting fact about me is that I once participated in a national art competition and won first place.",
                    UselessSkill = "My most useless skill is my ability to recite the lyrics of countless '90s pop songs with uncanny accuracy.",
                    BiographyTitle = "'Canvas of Dreams: Navigating Life's Palette' would be an apt title for my biography.",
                    DailyActivity = "I spend hours sketching, experimenting with new art techniques, and immersing myself in the world of creativity."
                ,
                    IdUser = 2
                });
                SaveChanges();
                #endregion
                #region OfferedAmenities
                OfferedAmenities.Add(new OfferedAmenities
                {
                    WiFi = true,
                    TV = true,
                    Kitchen = true,
                    WashingMachine = true,
                    FreeParking = true,
                    PaidParking = false,
                    AirConditioner = true,
                    Workspace = false,
                    SpecialFeatures = "Розташований на південному березі річки Темзи, зазнав чудової трансформації з промислової зони в процвітаючий і сучасний район. Він швидко набув популярності, ставши одним із найпопулярніших передмість міста. Горизонт тепер урізаний високими висотними будинками, звідки відкривається захоплюючий вид на міський пейзаж і річку.",
                    Pool = true,
                    Jacuzzi = false,
                    InnerYard = true,
                    BBQArea = false,
                    OutdoorDiningArea = true,
                    FirePit = false,
                    PoolTable = true,
                    Fireplace = false,
                    Piano = true,
                    GymEquipment = false,
                    LakeAccess = true,
                    BeachAccess = false,
                    SkiInOut = true,
                    OutdoorShower = false,
                    SmokeDetector = true,
                    FirstAidKit = true,
                    FireExtinguisher = true,
                    CarbonMonoxideDetector = false,
                    Description = "Відкрийте для себе цю чудову квартиру-студію в нещодавно відремонтованій будівлі, зручно розташованій між станцією метро Willesden Green і станцією Cricklewood Overground. Студія з легким доступом до центру Лондона має власний вхід і замок, забезпечуючи повну конфіденційність без спільного користування помешканням. Ця студія може похвалитися власною міні-кухнею, душовою кімнатою, безкоштовним Wi-Fi та двоспальним ліжком"
                });
                OfferedAmenities.Add(new OfferedAmenities
                {
                    WiFi = true,
                    TV = true,
                    Kitchen = true,
                    WashingMachine = true,
                    FreeParking = true,
                    PaidParking = false,
                    AirConditioner = true,
                    Workspace = false,
                    SpecialFeatures = "Цей апартамент розташований в самому серці міста, в якому завжди пульсує життя. Він ідеально підходить для тих, хто хоче бути посеред усього - від ресторанів та кафе до музеїв та торгових центрів. В цьому помешканні ви знайдете всі необхідні зручності для комфортного перебування. Сучасно обладнані кухні дозволять вам приготувати власні страви, а затишні вітальні створять атмосферу затишку та комфорту. Після насиченого дня ви зможете розслабитися у затишному інтер'єрі своєї спальні та насолодитися тишею центральної локації.",
                    Pool = true,
                    Jacuzzi = false,
                    InnerYard = true,
                    BBQArea = false,
                    OutdoorDiningArea = true,
                    FirePit = false,
                    PoolTable = true,
                    Fireplace = false,
                    Piano = true,
                    GymEquipment = false,
                    LakeAccess = true,
                    BeachAccess = false,
                    SkiInOut = true,
                    OutdoorShower = false,
                    SmokeDetector = true,
                    FirstAidKit = true,
                    FireExtinguisher = true,
                    CarbonMonoxideDetector = false,
                    Description = "Ця квартира може похвалитися власною міні-кухнею, душовою кімнатою, безкоштовним Wi-Fi та двоспальним ліжком."
                });
                OfferedAmenities.Add(new OfferedAmenities
                {
                    WiFi = true,
                    TV = true,
                    Kitchen = true,
                    WashingMachine = true,
                    FreeParking = true,
                    PaidParking = false,
                    AirConditioner = true,
                    Workspace = false,
                    SpecialFeatures = "Цей апартамент розташований в самому серці міста, в якому завжди пульсує життя. Він ідеально підходить для тих, хто хоче бути посеред усього - від ресторанів та кафе до музеїв та торгових центрів. В цьому помешканні ви знайдете всі необхідні зручності для комфортного перебування. Сучасно обладнані кухні дозволять вам приготувати власні страви, а затишні вітальні створять атмосферу затишку та комфорту. Після насиченого дня ви зможете розслабитися у затишному інтер'єрі своєї спальні та насолодитися тишею центральної локації.",
                    Pool = true,
                    Jacuzzi = false,
                    InnerYard = true,
                    BBQArea = false,
                    OutdoorDiningArea = true,
                    FirePit = false,
                    PoolTable = true,
                    Fireplace = false,
                    Piano = true,
                    GymEquipment = false,
                    LakeAccess = true,
                    BeachAccess = false,
                    SkiInOut = true,
                    OutdoorShower = false,
                    SmokeDetector = true,
                    FirstAidKit = true,
                    FireExtinguisher = true,
                    CarbonMonoxideDetector = false,
                    Description = "Ця квартира може похвалитися власною міні-кухнею, душовою кімнатою, безкоштовним Wi-Fi та двоспальним ліжком."
                });
                OfferedAmenities.Add(new OfferedAmenities
                {
                    WiFi = true,
                    TV = true,
                    Kitchen = true,
                    WashingMachine = true,
                    FreeParking = true,
                    PaidParking = false,
                    AirConditioner = true,
                    Workspace = false,
                    SpecialFeatures = "Розташований в самому центрі міста, ці апартаменти стануть ідеальним вибором для тих, хто цінує комфорт та зручність. Він розташований у непосредній близькості від основних туристичних визначних місць, торгових центрів та ресторанів, що робить його ідеальним варіантом для тих, хто хоче насолодитися всіма перевагами міського життя. У цьому помешканні передбачено всі необхідні зручності для комфортного перебування, включаючи сучасно обладнані кухні, просторі вітальні та затишні спальні. Тут ви знайдете все необхідне для того, щоб ваше перебування було незабутнім та зручним.",
                    Pool = true,
                    Jacuzzi = false,
                    InnerYard = true,
                    BBQArea = false,
                    OutdoorDiningArea = true,
                    FirePit = false,
                    PoolTable = true,
                    Fireplace = false,
                    Piano = true,
                    GymEquipment = false,
                    LakeAccess = true,
                    BeachAccess = false,
                    SkiInOut = true,
                    OutdoorShower = false,
                    SmokeDetector = true,
                    FirstAidKit = true,
                    FireExtinguisher = true,
                    CarbonMonoxideDetector = false,
                    Description = "Ця квартира має власну кухню, простору вітальню та спальню з двоспальним ліжком."
                });
                OfferedAmenities.Add(new OfferedAmenities
                {
                    WiFi = true,
                    TV = true,
                    Kitchen = true,
                    WashingMachine = true,
                    FreeParking = true,
                    PaidParking = false,
                    AirConditioner = true,
                    Workspace = false,
                    SpecialFeatures = "Цей апартамент розташований в тихому та затишному районі міста, що створює ідеальні умови для відпочинку та релаксації після насиченого дня відвідування місцевих визначних місць. Він знаходиться вдалині від шумних вулиць та туристичних масовок, що дозволяє вам насолоджуватися тишею та спокоєм під час вашого перебування. У цьому помешканні ви знайдете.",
                    Pool = true,
                    Jacuzzi = false,
                    InnerYard = true,
                    BBQArea = false,
                    OutdoorDiningArea = true,
                    FirePit = false,
                    PoolTable = true,
                    Fireplace = false,
                    Piano = true,
                    GymEquipment = false,
                    LakeAccess = true,
                    BeachAccess = false,
                    SkiInOut = true,
                    OutdoorShower = false,
                    SmokeDetector = true,
                    FirstAidKit = true,
                    FireExtinguisher = true,
                    CarbonMonoxideDetector = false,
                    Description = "Цей апартамент має власну кухню та просторий вітальний куточок, де можна відпочити після дня відкриття міста."
                });
                OfferedAmenities.Add(new OfferedAmenities
                {
                    WiFi = true,
                    TV = true,
                    Kitchen = true,
                    WashingMachine = true,
                    FreeParking = true,
                    PaidParking = false,
                    AirConditioner = true,
                    Workspace = false,
                    SpecialFeatures = "Розташований в зручному місці, що недалеко від центру міста, цей апартамент ідеально підходить як для відпочинку, так і для відвідування місцевих визначних місць. Зручна локація дозволить вам легко дістатися до всіх центральних атракцій та популярних визначних місць міста, забезпечуючи неповторне і відмінне враження від вашої подорожі. Після цікавих екскурсій ви зможете повернутися до цього затишного апартаменту, щоб розслабитися та насолодитися спокоєм і комфортом. Зручно обладнані кухні та просторі вітальні створять атмосферу домашнього затишку, а затишні спальні забезпечать вам гарний сон та відновлення сил для нових пригод.",
                    Pool = true,
                    Jacuzzi = false,
                    InnerYard = true,
                    BBQArea = false,
                    OutdoorDiningArea = true,
                    FirePit = false,
                    PoolTable = true,
                    Fireplace = false,
                    Piano = true,
                    GymEquipment = false,
                    LakeAccess = true,
                    BeachAccess = false,
                    SkiInOut = true,
                    OutdoorShower = false,
                    SmokeDetector = true,
                    FirstAidKit = true,
                    FireExtinguisher = true,
                    CarbonMonoxideDetector = false,
                    Description = "Цей апартамент надає всі зручності для приємного перебування у місті та легкого доступу до всіх місцевих визначних місць."
                });
                SaveChanges();
                #endregion
                #region RentalApartments
                RentalApartments.Add(new RentalApartment
                {
                    UserId = 1,
                    Title = "The Cromwell Collection",
                    Address = "Лондон, Кенсингтон и Челси",
                    City = "Лондон",
                    PlaceId = 243408926,

                    CountryCode = "gb",  IngMap = "51.51029749292652",
                    LatMap = "-0.2052512847809161",
                    NumberOfGuests = 4,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    Beds = 2,
                    PricePerNight = 150.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 6,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {
                    UserId = 2,
                    Title = "Tulse Hill Luxury Cosy Rooms",
                    Address = "Лондон, Ламбет, SW2 3JW ",
                    CountryCode = "gb",  IngMap = "51.51806759859402",
                    LatMap = "-0.2347715452732212",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 4,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    Beds = 2,
                    PricePerNight = 110.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 2,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 3,
                    Title = "Camden House",
                    Address = "Лондон, Камден, NW1 0ST",
                    CountryCode = "gb",  IngMap = "51.53977037914003",
                    LatMap = "-0.21791123310160962",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 45.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.8,
                    OfferedAmenitiesId = 3,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 6,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 4,
                    Title = "The Beaufort",
                    Address = "Лондон, Кенсингтон и Челси, SW3 1PP",
                    CountryCode = "gb",  IngMap = "51.55279426489078",
                    LatMap = "-0.17310761269111705",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 200.0,
                    ObjectState = "Вільний",
                    ObjectRating = 2.7,
                    OfferedAmenitiesId = 4,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 5,
                    Title = "D8 House",
                    Address = "Лондон,  Тауэр-Хэмлетс, E2 6DG",
                    CountryCode = "gb",  IngMap = "51.486354843938244",
                    LatMap = "-0.06684922054184217",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 65.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.2,
                    OfferedAmenitiesId = 5,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 6,
                    SportId = 4,
                    CountryId = 2
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 6,
                    Title = "Fashionable Brick Lane",
                    Address = "Лондон, Тауэр-Хэмлетс",
                    CountryCode = "gb",  IngMap = "51.52018621096843",
                    LatMap = "-0.06105365363315668",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 99.0,
                    ObjectState = "Вільний",
                    ObjectRating = 2.7,
                    OfferedAmenitiesId = 6,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 7,
                    Title = "Flat 17",
                    Address = "Лондон, Кенсингтон и Челси, SW3 3E",
                    CountryCode = "gb",  IngMap = "51.527865159086794",
                    LatMap = "-0.03608120108259954",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 59.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 6,
                    SportId = 4,
                    CountryId = 2
                });
                RentalApartments.Add(new RentalApartment
                {
                    UserId = 8,
                    Title = "Avari Apartments",
                    Address = "Лондон, Вестминстер, SW1V 4PA",
                    CountryCode = "gb",  IngMap = "51.539341254721634",
                    LatMap = "-0.012962606372573467",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 4,
                    Bedrooms = 2,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 75.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.6,
                    OfferedAmenitiesId = 3,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 9,
                    Title = "Stunning duplex with terrace",
                    Address = "Лондон, Саламандровий суд, N7 9LG,",
                    CountryCode = "gb",  IngMap = "51.55787209292902",
                    LatMap = "-0.020973879864129772",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 6,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    Beds = 3,
                    PricePerNight = 169.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 4,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 4,
                    SportId = 4,
                    CountryId = 2
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 10,
                    Title = "Paddington by CAPITAL",
                    Address = "Лондон, Вестминстер, W2 3DN,",
                    CountryCode = "gb",  IngMap = "51.56382495384703",
                    LatMap = "-0.04439308988407374",
                    City = "Лондон",
                    PlaceId = 243408926,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 55.0,
                    ObjectState = "Вільний",
                    ObjectRating = 2.9,
                    OfferedAmenitiesId = 5,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2
                });

                RentalApartments.Add(new RentalApartment
                {

                    UserId = 11,
                    Title = "Мінібудинок",
                    Address = "Шенек, Хемниц",
                    CountryCode = "de",  IngMap = "50.21540706044495",
                    LatMap = "8.839970711377223",
                    City = "Шенек",
                    PlaceId = 121107681,
                    NumberOfGuests = 3,
                    Bedrooms = 3,
                    Bathrooms = 1,
                    Beds = 3,
                    PricePerNight = 123.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.8,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 4,
                    LocationId = 4,
                    SportId = 4,
                    CountryId = 4
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 12,
                    Title = "Мінібудинок",
                    Address = "Миттельштрімміг, Рейнланд-Пфальц",
                    CountryCode = "de",  IngMap = "50.056124592755054",
                    LatMap = "7.290073935617933",
                    City = "Миттельштрімміг",
                    PlaceId = 134400637,
                    NumberOfGuests = 3,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 99.0,
                    ObjectState = "Вільний",
                    ObjectRating = 2.7,
                    OfferedAmenitiesId = 2,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 7,
                    LocationId = 4,
                    SportId = 4,
                    CountryId = 4
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 13,
                    Title = "Транспортний контейнер",
                    Address = "Меттман, Півничний Рейн-Вестфалія",
                    City = "Меттман",
                    PlaceId = 129095530,
                    CountryCode = "de",  IngMap = "51.256633974493575",
                    LatMap = "6.987379914237928",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 92.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.2,
                    OfferedAmenitiesId = 3,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 4,
                    SportId = 4,
                    CountryId = 4
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 1,
                    Title = "Мінібудинок",
                    Address = "Шенек, Хемниц",
                    CountryCode = "de",  IngMap = "50.39453445353583",
                    LatMap = "12.308584985733727",
                    City = "Шенек",
                    PlaceId = 121107681,
                    NumberOfGuests = 3,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 3,
                    PricePerNight = 138.0,
                    ObjectState = "Вільний",
                    ObjectRating = 2.7,
                    OfferedAmenitiesId = 4,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 4,
                    LocationId = 4,
                    SportId = 4,
                    CountryId = 4
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 2,
                    Title = "Мінібудинок",
                    Address = "Райсбах, Нижня Баварія",
                    CountryCode = "de",  IngMap = "48.56736875688296",
                    LatMap = "12.639491565044615",
                    City = "Райсбах",
                    PlaceId = 111641451,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 93.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 5,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 4,
                    SportId = 4,
                    CountryId = 4
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 3,
                    Title = "Мінібудинок",
                    Address = "Вельзов, Бранденбург",
                    CountryCode = "de",  IngMap = "51.56784406958916",
                    LatMap = "14.217600638333618",
                    City = "Вельзов",
                    PlaceId = 149784038,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 66.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.6,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 4,
                    SportId = 4,
                    CountryId = 4
                });

                RentalApartments.Add(new RentalApartment
                {

                    UserId = 4,
                    Title = "Будинок на дереві",
                    Address = "Порумбаку-де-Жос, 557190",
                    CountryCode = "ro",  IngMap = "45.7563527607495",
                    LatMap = "24.456252776586187",
                    City = "Порумбаку-де-Жос",
                    PlaceId = 83757127,
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 166.0,
                    ObjectState = "Вільний",
                    ObjectRating = 2.7,
                    OfferedAmenitiesId = 2,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 7,
                    LocationId = 4,
                    SportId = 3,
                    CountryId = 3
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 4,
                    Title = "Будинок на дереві",
                    Address = "Мойсей, 437195",
                    CountryCode = "ro",  IngMap = "47.15331481926964",
                    LatMap = "24.452562042435115",
                    City = "Мойсей",
                    PlaceId = 85594312,
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 87.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.2,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 7,
                    LocationId = 4,
                    SportId = 3,
                    CountryId = 3
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 5,
                    Title = "Будинок на дереві",
                    Address = "Пештяна (Хунедоара), 437188",
                    CountryCode = "ro",  IngMap = "47.01578222685503",
                    LatMap = "25.94023108034595",
                    City = "Peșteana",
                    PlaceId = 85486102,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 87.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 7,
                    LocationId = 4,
                    SportId = 3,
                    CountryId = 3
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 6,
                    Title = "Будинок на дереві",
                    Address = "Ришнов, 437199",
                    CountryCode = "ro",  IngMap = "45.66978588709117",
                    LatMap = "23.912650825021004",
                    City = "Ришнов",
                    PlaceId = 84296604,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 77.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 7,
                    LocationId = 4,
                    SportId = 3,
                    CountryId = 3
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 7,
                    Title = "Будинок на дереві",
                    Address = "Селарі, 437199",
                    CountryCode = "ro",  IngMap = "44.9376291557003",
                    LatMap = "26.02180040096247",
                    City = "Șelari",
                    PlaceId = 84144308,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 45.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 7,
                    LocationId = 4,
                    SportId = 3,
                    CountryId = 3
                }); 

                RentalApartments.Add(new RentalApartment
                {

                    UserId = 1,
                    Title = "Квартира з видом на море та терасою",
                    Address = "Равелло, 84010 Салерно",
                    CountryCode = "it",  IngMap = "40.64899845014291",
                    LatMap = "14.612799019421358",
                    City = "Ravello",
                    PlaceId = 107537659,
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 3,
                    PricePerNight = 185.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 4,
                    SportId = 5,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 2,
                    Title = "Трулло",
                    Address = "Чистернино, 72014 Бриндизи",
                    CountryCode = "it",  IngMap = "40.75229164917796",
                    LatMap = "17.44248314955592",
                    City = "Cisternino",
                    PlaceId = 87948430,
                    NumberOfGuests = 16,
                    Bedrooms = 10,
                    Bathrooms = 5,
                    Beds = 11,
                    PricePerNight = 396.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 4,
                    SportId = 5,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 3,
                    Title = "Антральний лофт",
                    Address = "Четара, 84010 Салерно",
                    CountryCode = "it",  IngMap = "40.6490857043599",
                    LatMap = "14.699735501025845",
                    City = "Salerno",
                    PlaceId = 103013293,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 140.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 4,
                    SportId = 5,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 4,
                    Title = "Сассі Матери",
                    Address = "Матера, 63095 Асколи-Пичено",
                    CountryCode = "it",  IngMap = "40.672932196749265",
                    LatMap = "16.59806772753433",
                    City = "Матера",
                    PlaceId = 81260500,
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 183.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 4,
                    SportId = 5,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 5,
                    Title = "Білий дім у центрі",
                    Address = "Остуни, 72017 Бриндизи",
                    CountryCode = "it",  IngMap = "40.724716051729665",
                    LatMap = "17.574271551078237",
                    City = "Ostuni",
                    PlaceId = 80978170,
                    NumberOfGuests = 3,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 31.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 4,
                    SportId = 5,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 6,
                    Title = "Бутик Dominic",
                    Address = "Клоаштерф, Муреш",
                    CountryCode = "ro",  IngMap = "46.14515682803763",
                    LatMap = "24.996128071119085",
                    City = "Cloașterf",
                    PlaceId = 85136635,
                    NumberOfGuests = 4,
                    Bedrooms = 2,
                    Bathrooms = 1,
                    Beds = 4,
                    PricePerNight = 70.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 4,
                    SportId = 2,
                    CountryId = 3,
                });

                RentalApartments.Add(new RentalApartment
                {

                    UserId = 7,
                    Title = "Cabana Colt Verde 2",
                    Address = "Славута, 864578",
                    CountryCode = "ro",  IngMap = "44.68556472236807",
                    LatMap = "23.67982429770622",
                    City = "Slăvuța",
                    PlaceId = 86843965,
                    NumberOfGuests = 4,
                    Bedrooms = 2,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 72.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 1,
                    Title = "AdyBeca - Forest Nook",
                    Address = "Бихор, Кришана, 417565",
                    CountryCode = "ro",  IngMap = "46.94738833574938",
                    LatMap = "22.534889842947774",
                    City = "Șuncuiuș",
                    PlaceId = 85598489,
                    NumberOfGuests = 5,
                    Bedrooms = 2,
                    Bathrooms = 1,
                    Beds = 3,
                    PricePerNight = 169.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 2,
                    Title = "Трансильванська ферма",
                    Address = "Арджеш, 417565",
                    CountryCode = "ro",  IngMap = "45.0446478100272",
                    LatMap = "24.751723559815666",
                    City = "Aluniș",
                    PlaceId = 85139495,
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 128.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 3,
                    Title = "Сучасний зруб з каміном і сауною",
                    Address = "Деалу Негру, 407137",
                    CountryCode = "ro",  IngMap = "46.721914349650774",
                    LatMap = "23.06439914180859",
                    City = "Dealu Negru",
                    PlaceId = 87682205,
                    NumberOfGuests = 4,
                    Bedrooms = 2,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 138.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 4,
                    Title = "Дерев 'яний будинок",
                    Address = "Булзештій-де-Сус, 337150",
                    CountryCode = "ro",  IngMap = "46.28753332303139",
                    LatMap = "22.74658064272575",
                    City = "ulzeștii de Sus",
                    PlaceId = 86662922,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 60.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 13,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 5,
                    Title = "Замок Ґалбіно",
                    Address = "Ангьяри, 52031 Ареццо",
                    CountryCode = "it",  IngMap = "43.54125869737415",
                    LatMap = "12.054268151354552",
                    City = "Anghiari",
                    PlaceId = 67428918,
                    NumberOfGuests = 16,
                    Bedrooms = 10,
                    Bathrooms = 9,
                    Beds = 15,
                    PricePerNight = 587.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 15,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 6,
                    Title = "Середньовічний замок",
                    Address = "Вітторіо-Венето, 31029 Тревизо",
                    CountryCode = "it",  IngMap = "45.98655459436066",
                    LatMap = "12.303306745022443",
                    City = "Вітторіо-Венето",
                    PlaceId = 66008440,
                    NumberOfGuests = 8,
                    Bedrooms = 4,
                    Bathrooms = 4,
                    Beds = 4,
                    PricePerNight = 498.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 15,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });




                RentalApartments.Add(new RentalApartment
                {

                    UserId = 7,
                    Title = "Середньовічний замок",
                    Address = "Гуальдо-Каттанео, 06035 Перуджа",
                    CountryCode = "it",  IngMap = "42.91269825483277",
                    LatMap = "12.557486689710865",
                    City = "Gualdo Cattaneo",
                    PlaceId = 67718249,
                    NumberOfGuests = 16,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    Beds = 4,
                    PricePerNight = 2365.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 15,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 1,
                    Title = "Дімора - приголомшливий старовинний замок",
                    Address = "Монселиче, 35043 Падуя",
                    CountryCode = "it",  IngMap = "45.24033738866952",
                    LatMap = "11.754828669810815",
                    City = "Monselice",
                    PlaceId = 61959664,
                    NumberOfGuests = 6,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    Beds = 6,
                    PricePerNight = 282.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 15,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 2,
                    Title = "Абатство Сан-Джусто",
                    Address = "Тускания, 01017 Витербо",
                    CountryCode = "it",  IngMap = "42.417741941778814",
                    LatMap = "11.867198509315804",
                    City = "Tuscania",
                    PlaceId = 67947736,
                    NumberOfGuests = 16,
                    Bedrooms = 16,
                    Bathrooms = 11,
                    Beds = 22,
                    PricePerNight = 2707.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 15,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 3,
                    Title = "Torre Trasita",
                    Address = "Позитано, 84017 Салерно",
                    CountryCode = "it",  IngMap = "40.63120562112401",
                    LatMap = "14.48258812283489",
                    City = "Positano",
                    PlaceId = 67703618,
                    NumberOfGuests = 6,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    Beds = 3,
                    PricePerNight = 2093.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 15,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 4,
                    Title = "Вежа замку",
                    Address = "Ронкаде, 31056 Тревизо",
                    CountryCode = "it",  IngMap = "45.630447227866135",
                    LatMap = "12.373660952518671",
                    City = "Roncade",
                    PlaceId = 66409758,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 162.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 15,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });



                RentalApartments.Add(new RentalApartment
                {

                    UserId = 5,
                    Title = "Pathfinder",
                    Address = "Моакша, 527120",
                    CountryCode = "ro",  IngMap = "45.87236287756109",
                    LatMap = "25.969769705436246",
                    City = "Moacșa",
                    PlaceId = 51451832,
                    NumberOfGuests = 3,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 5,
                    PricePerNight = 37.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 12,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 6,
                    Title = "Затишний будинок-фургон",
                    Address = "Урлаці, повіт Прахова",
                    CountryCode = "ro",  IngMap = "44.991300737454374",
                    LatMap = "26.226746799270053",
                    City = "Urlați",
                    PlaceId = 51436891,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 44.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 12,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 3,
                });



                RentalApartments.Add(new RentalApartment
                {

                    UserId = 7,
                    Title = "ферма Habitat",
                    Address = "Сорренто, 80067 Неаполь",
                    CountryCode = "it",  IngMap = "40.618899622977395",
                    LatMap = "14.385404890771284",
                    City = "Сорренто",
                    PlaceId = 100169920,
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 3,
                    PricePerNight = 87.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 12,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 1,
                    Title = "Літл-Парадайс",
                    Address = "Граньєрі, 95041 Катания",
                    CountryCode = "it",  IngMap = "37.128294268964524",
                    LatMap = "14.578187056639104",
                    City = "Granieri",
                    PlaceId = 78406019,
                    NumberOfGuests = 3,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 38.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 12,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 2,
                    Title = "Караваном",
                    Address = "Альгеро, 07041 Сассари",
                    CountryCode = "it",  IngMap = "40.562707957434654",
                    LatMap = "8.323292003065456",
                    City = "Альгеро",
                    PlaceId = 101108166,
                    NumberOfGuests = 3,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 32.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 12,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    UserId = 3,
                    Title = "Флоріан - вогнище!",
                    Address = "Лакона, 57031 Ливорно",
                    CountryCode = "it",  IngMap = "42.76369359649195",
                    LatMap = "10.309195169607786",
                    City = "Lacona",
                    PlaceId = 68011038,
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 50.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 12,
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 5,
                });
                SaveChanges();
                #endregion
                #region Booking
                Bookings.Add(new Booking
                {

                    OwnerId = 1,
                    ApartmentId = 1,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now.AddDays(7),
                    NumberOfGuests = 2,
                    TotalPrice = 200.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {

                    OwnerId = 1,
                    ApartmentId = 1,
                    CheckInDate = DateTime.Now.AddDays(10),
                    CheckOutDate = DateTime.Now.AddDays(17),
                    NumberOfGuests = 2,
                    TotalPrice = 200.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {

                    OwnerId = 1,
                    ApartmentId = 1,
                    CheckInDate = DateTime.Now.AddDays(25),
                    CheckOutDate = DateTime.Now.AddDays(32),
                    NumberOfGuests = 2,
                    TotalPrice = 200.0,
                    PaymentStatus = true
                });
            
          
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 2,
                    CheckInDate = DateTime.Now.AddDays(10),
                    CheckOutDate = DateTime.Now.AddDays(14),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });

                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 3,
                    CheckInDate = DateTime.Now.AddDays(2),
                    CheckOutDate = DateTime.Now.AddDays(14),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });

                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 4,
                    CheckInDate = DateTime.Now.AddDays(5),
                    CheckOutDate = DateTime.Now.AddDays(10),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 4,
                    CheckInDate = DateTime.Now.AddDays(12),
                    CheckOutDate = DateTime.Now.AddDays(15),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 5,
                    CheckInDate = DateTime.Now.AddDays(32),
                    CheckOutDate = DateTime.Now.AddDays(39),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 6,
                    CheckInDate = DateTime.Now.AddDays(2),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 7,
                    CheckInDate = DateTime.Now.AddDays(2),
                    CheckOutDate = DateTime.Now.AddDays(99),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 8,
                    CheckInDate = DateTime.Now.AddDays(20),
                    CheckOutDate = DateTime.Now.AddDays(29),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 9,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 10,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 10,
                    CheckInDate = DateTime.Now.AddDays(12),
                    CheckOutDate = DateTime.Now.AddDays(29),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 11,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(3),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 11,
                    CheckInDate = DateTime.Now.AddDays(10),
                    CheckOutDate = DateTime.Now.AddDays(22),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 12,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(5),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 12,
                    CheckInDate = DateTime.Now.AddDays(13),
                    CheckOutDate = DateTime.Now.AddDays(19),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 13,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 14,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(7),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 15,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(4),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 15,
                    CheckInDate = DateTime.Now.AddDays(9),
                    CheckOutDate = DateTime.Now.AddDays(13),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 16,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(5),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 17,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(22),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 18,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(2),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 19,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(12),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 20,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(15),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 21,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 22,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(18),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 23,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(6),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 24,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(3),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 25,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(13),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 26,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(21),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 27,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(6),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 28,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(23),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 29,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(11),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 30,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(3),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 31,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(14),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 32,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 32,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(2),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 33,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(31),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 34,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(5),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 35,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(7),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 36,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 37,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(4),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 38,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(15),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 39,
                    CheckInDate = DateTime.Now.AddDays(11),
                    CheckOutDate = DateTime.Now.AddDays(23),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 40,
                    CheckInDate = DateTime.Now.AddDays(2),
                    CheckOutDate = DateTime.Now.AddDays(4),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 41,
                    CheckInDate = DateTime.Now.AddDays(5),
                    CheckOutDate = DateTime.Now.AddDays(8),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 42,
                    CheckInDate = DateTime.Now.AddDays(10),
                    CheckOutDate = DateTime.Now.AddDays(32),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 43,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(10),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 44,
                    CheckInDate = DateTime.Now.AddDays(9),
                    CheckOutDate = DateTime.Now.AddDays(12),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 45,
                    CheckInDate = DateTime.Now.AddDays(5),
                    CheckOutDate = DateTime.Now.AddDays(15),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = true
                });




                //переписка
                Bookings.Add(new Booking
                {
                    OwnerId = 14,
                    ApartmentId = 1,
                    CheckInDate = DateTime.Now.AddDays(8),
                    CheckOutDate = DateTime.Now.AddDays(10),
                    NumberOfGuests = 2,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 14,
                    ApartmentId = 2,
                    CheckInDate = DateTime.Now.AddDays(0),
                    CheckOutDate = DateTime.Now.AddDays(5),
                    NumberOfGuests = 3,
                    TotalPrice = 550.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 14,
                    ApartmentId = 3,
                    CheckInDate = DateTime.Now.AddDays(15),
                    CheckOutDate = DateTime.Now.AddDays(19),
                    NumberOfGuests = 3,
                    TotalPrice = 180.0,
                    PaymentStatus = false
                });

                #endregion
                #region Wishlists
                Wishlists.Add(new Wishlist
                {
                    UserId = 1,
                    ApartmentId = 1,
                });
                Wishlists.Add(new Wishlist
                {
                    UserId = 1,
                    ApartmentId = 2,
                });
                #endregion  
                #region CommentsAboutGuests
                CommentsAboutGuests.Add(new CommentsAboutGuest
                {
                    Comment = "Мав можливість приймати Дмитро Золкин. Чудовий гість, який був поважним і залишив місце в бездоганному стані.",
                    DateComments = DateTime.Now.AddDays(-7),
                    MasterIdUser = 2,
                    GuestIdUser = 1
                });

                CommentsAboutGuests.Add(new CommentsAboutGuest
                {
                    Comment = "Джейн Сміт залишалася у нас і принесла позитивну енергію в будинок. Велика комунікація і залишила теплі враження.",
                    DateComments = DateTime.Now.AddDays(-14),
                    MasterIdUser = 1,
                    GuestIdUser = 2
                });
                #endregion  
                #region GuestСomments
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 1,
                    ApartmentId = 1,
                    Comment = "Відмінно!",
                    DateTime = DateTime.Now.AddDays(-1),
                    Rating = 4.5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 2,
                    ApartmentId = 1,
                    Comment = "Сподобалося!",
                    DateTime = DateTime.Now.AddDays(-3),
                    Rating = 5.0
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 3,
                    ApartmentId = 1,
                    Comment = "Чудове місце!",
                    DateTime = DateTime.Now.AddDays(-5),
                    Rating = 4.8
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 4,
                    ApartmentId = 1,
                    Comment = "Ця квартира перевершила всі мої очікування! Вона виглядає абсолютно чудово, ідеально чиста та затишна. Всі зручності працюють на відмінно. Обов'язково прийду ще!",
                    DateTime = new DateTime(2024, 02, 10, 15, 28, 06),
                    Rating = 5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 5,
                    ApartmentId = 1,
                    Comment = "Я надзвичайно задоволений цим помешканням! Все виглядає абсолютно новим та організованим. Господарі дуже привітні та гостинні. Обов'язково порекомендую друзям!",
                    DateTime = new DateTime(2024, 02, 12, 15, 28, 06),
                    Rating = 5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 6,
                    ApartmentId = 1,
                    Comment = "Відмінне місце для проживання! Квартира чиста, комфортна та добре обладнана. Розташування ідеальне - зручно до всіх визначних місць. Обов'язково зупинюся тут ще раз!",
                    DateTime = new DateTime(2024, 02, 14, 15, 28, 06),
                    Rating = 5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 7,
                    ApartmentId = 1,
                    Comment = "Моє перебування було просто чудове! Квартира чиста, простора та затишна. Всі необхідні зручності на місці. Господарі дуже привітні та готові допомогти. Рекомендую!",
                    DateTime = new DateTime(2024, 02, 16, 15, 28, 06),
                    Rating = 5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 8,
                    ApartmentId = 1,
                    Comment = "Враження від перебування просто неймовірні! Квартира простора, затишна та чиста. Розташування прекрасне - поруч з усіма визначними пам'ятками міста. Обов'язково прийду ще!",
                    DateTime = new DateTime(2024, 02, 18, 15, 28, 06),
                    Rating = 5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 11,
                    ApartmentId = 1,
                    Comment = "Відмінно!",
                    DateTime = new DateTime(2024, 02, 21, 15, 28, 06),
                    Rating = 4.7
                });


                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 8,
                    ApartmentId = 2,
                    Comment = "Місце було чудовим, але обстановка трохи зіпсована недбалістю власника.",
                    DateTime = new DateTime(2024, 02, 06, 15, 28, 06),
                    Rating = 3.2
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 9,
                    ApartmentId = 2,
                    Comment = "Враження були змішані. Квартира була чистою, але більшість речей вже були застарілими та потребували ремонту.",
                    DateTime = new DateTime(2024, 02, 05, 15, 28, 06),
                    Rating = 3
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 2,
                    ApartmentId = 12,
                    Comment = "Місце мало потенціал, але потребує покращень. Знайшов деякі проблеми зі сантехнікою. Сподіваюся, що власник виправить їх.",
                    DateTime = new DateTime(2024, 02, 04, 15, 28, 06),
                    Rating = 2.5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 4,
                    ApartmentId = 2,
                    Comment = "Не можу сказати, що залишився задоволений. Квартира була не такою, як очікував. Багато шуму з вулиці, а також бруд на підлозі. Можна знайти краще за ціною.",
                    DateTime = new DateTime(2024, 02, 02, 15, 28, 06),
                    Rating = 2
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 5,
                    ApartmentId = 2,
                    Comment = "Загалом, перебування було середнім. Квартира була досить зручною, але потребувала більшого прибирання. Непоганий варіант за ціною, але не ідеальний.",
                    DateTime = new DateTime(2024, 01, 31, 15, 28, 06),
                    Rating = 3
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 6,
                    ApartmentId = 2,
                    Comment = "Не зовсім задоволений своїм перебуванням. Квартира була занадто шумна, а також виявились деякі проблеми з опаленням. Не порадив би це місце.",
                    DateTime = new DateTime(2024, 01, 29, 15, 28, 06),
                    Rating = 2.8
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 7,
                    ApartmentId = 2,
                    Comment = "Місце було прийнятним, але трохи застарілого вигляду. Також, ванна кімната потребує ремонту.",
                    DateTime = new DateTime(2024, 01, 27, 15, 28, 06),
                    Rating = 3.5
                });

                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 13,
                    ApartmentId = 3,
                    Comment = "Неймовірна квартира з прекрасними видами! Все було на вищому рівні. Дякую за чудовий відпочинок!",
                    DateTime = new DateTime(2024, 02, 04, 15, 28, 06),
                    Rating = 4.9
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 12,
                    ApartmentId = 3,
                    Comment = "Чудове помешкання з комфортною атмосферою! Все було чисто та охайно. Власник був дуже привітний та відзначив усі мої побажання. Рекомендую!",
                    DateTime = new DateTime(2024, 02, 02, 15, 28, 06),
                    Rating = 4.8
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 11,
                    ApartmentId = 3,
                    Comment = "Приємна квартира з усім необхідним для комфортного перебування. Місце розташування дуже зручне, багато кафе та ресторанів поруч. Я задоволений своїм відпочинком!",
                    DateTime = new DateTime(2024, 01, 31, 15, 28, 06),
                    Rating = 4.2
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 10,
                    ApartmentId = 3,
                    Comment = "Дуже приємна квартира з чистим та сучасним дизайном. Всі зручності працюють на відмінно. Місце розташування також дуже зручне. Рекомендую!",
                    DateTime = new DateTime(2024, 01, 29, 15, 28, 06),
                    Rating = 4.7
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 9,
                    ApartmentId = 3,
                    Comment = "Враження від перебування перевищили мої очікування! Квартира була чистою та затишною, а розташування близько до всіх головних визначних місць. Обов'язково повернусь сюди знову!",
                    DateTime = new DateTime(2024, 01, 27, 15, 28, 06),
                    Rating = 4.8
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 8,
                    ApartmentId = 3,
                    Comment = "Прекрасна квартира зі стильним інтер'єром та відмінним розташуванням. Все було на вищому рівні, ідеальне місце для відпочинку. Дуже задоволений!",
                    DateTime = new DateTime(2024, 01, 25, 15, 28, 06),
                    Rating = 4.9
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 1,
                    ApartmentId = 3,
                    Comment = "Відмінно!",
                    DateTime = new DateTime(2024, 02, 21, 15, 28, 06),
                    Rating = 4.5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 5,
                    ApartmentId = 3,
                    Comment = "Прекрасне місце!",
                    DateTime = new DateTime(2024, 02, 17, 15, 28, 06),
                    Rating = 4.9
                });

                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 4,
                    ApartmentId = 4,
                    Comment = "Квартира була дуже шумною та запахло курінням, що не дуже приємно.",
                    DateTime = new DateTime(2024, 02, 03, 15, 28, 06),
                    Rating = 2.5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 5,
                    ApartmentId = 4,
                    Comment = "Місце мало потенціал, але потребує покращень. Знайшов деякі проблеми зі сантехнікою. Сподіваюся, що власник виправить їх.",
                    DateTime = new DateTime(2024, 02, 04, 15, 28, 06),
                    Rating = 2.5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 6,
                    ApartmentId = 4,
                    Comment = "Не можу сказати, що залишився задоволений. Квартира була не такою, як очікував. Багато шуму з вулиці, а також бруд на підлозі. Можна знайти краще за ціною.",
                    DateTime = new DateTime(2024, 02, 02, 15, 28, 06),
                    Rating = 2
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 7,
                    ApartmentId = 4,
                    Comment = "Загалом, перебування було середнім. Квартира була досить зручною, але потребувала більшого прибирання. Непоганий варіант за ціною, але не ідеальний.",
                    DateTime = new DateTime(2024, 01, 31, 15, 28, 06),
                    Rating = 3
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 8,
                    ApartmentId = 4,
                    Comment = "Не зовсім задоволений своїм перебуванням. Квартира була занадто шумна, а також виявились деякі проблеми з опаленням. Не порадив би це місце.",
                    DateTime = new DateTime(2024, 01, 29, 15, 28, 06),
                    Rating = 2.8
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 9,
                    ApartmentId = 4,
                    Comment = "Місце було прийнятним, але трохи застарілого вигляду. Також, ванна кімната потребує ремонту.",
                    DateTime = new DateTime(2024, 01, 27, 15, 28, 06),
                    Rating = 3.5
                });

                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 5,
                    ApartmentId = 5,
                    Comment = "Незважаючи на деякі недоліки, місце було досить зручним та приємним для проживання.",
                    DateTime = new DateTime(2024, 02, 02, 15, 28, 06),
                    Rating = 3.7
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 2,
                    ApartmentId = 5,
                    Comment = "Дуже задоволений!",
                    DateTime = new DateTime(2024, 02, 19, 15, 28, 06),
                    Rating = 5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 4,
                    ApartmentId = 5, 
                    Comment = "Чудово!",
                    DateTime = new DateTime(2024, 02, 18, 15, 28, 06),
                    Rating = 4.7
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 4,
                    ApartmentId =6,
                    Comment = "Нажаль, не дуже задоволений. Квартира була брудною, інтернет не працював, а крісла були зламані.",
                    DateTime = new DateTime(2024, 02, 10, 15, 28, 06),
                    Rating = 2
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 6,
                    ApartmentId = 6,
                    Comment = "Квартира була прийнятною, але трохи застарілого вигляду. Також, ванна кімната потребує ремонту.",
                    DateTime = new DateTime(2024, 02, 08, 15, 28, 06),
                    Rating = 3.5
                });

                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 9,
                    ApartmentId = 7,
                    Comment = "Велике спасибі за чудовий відпочинок! Квартира була дуже зручна та чиста, а вид з вікна просто чарівний!",
                    DateTime = new DateTime(2024, 02, 11, 15, 28, 06),
                    Rating = 4.8
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 5,
                    ApartmentId = 7,
                    Comment = "Вражаюча квартира з прекрасним видом на місто. Чисто та затишно. Обов'язково прийдемо ще!",
                    DateTime = new DateTime(2024, 02, 09, 15, 28, 06),
                    Rating = 4.9
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 6,
                    ApartmentId = 7,
                    Comment = "Відмінне місце для проживання! Квартира чиста, комфортна та добре обладнана. Розташування ідеальне - зручно до всіх визначних місць. Обов'язково зупинюся тут ще раз!",
                    DateTime = new DateTime(2024, 02, 14, 15, 28, 06),
                    Rating = 5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 11,
                    ApartmentId = 7,
                    Comment = "Моє перебування було просто чудове! Квартира чиста, простора та затишна. Всі необхідні зручності на місці. Господарі дуже привітні та готові допомогти. Рекомендую!",
                    DateTime = new DateTime(2024, 02, 16, 15, 28, 06),
                    Rating = 5
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 13,
                    ApartmentId = 7,
                    Comment = "Враження від перебування просто неймовірні! Квартира простора, затишна та чиста. Розташування прекрасне - поруч з усіма визначними пам'ятками міста. Обов'язково прийду ще!",
                    DateTime = new DateTime(2024, 02, 18, 15, 28, 06),
                    Rating = 5
                });

                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 10,
                    ApartmentId = 8,
                    Comment = "Прекрасне розташування та чудова квартира. Чисто, зручно, все працює. Дякую за гарний відпочинок!",
                    DateTime = new DateTime(2024, 02, 07, 15, 28, 06),
                    Rating = 4.7
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 6,
                    ApartmentId = 8,
                    Comment = "Дуже хороше місце, але трохи шумно вночі.",
                    DateTime = new DateTime(2024, 02, 15, 15, 28, 06),
                    Rating = 4.2
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 2,
                    ApartmentId = 8,
                    Comment = "Все було чудово, окрім того, що кондиціонер не працював.",
                    DateTime = new DateTime(2024, 02, 14, 15, 28, 06),
                    Rating = 3.8
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 9,
                    ApartmentId = 8,
                    Comment = "Затишно та комфортно. Рекомендую!",
                    DateTime = new DateTime(2024, 02, 16, 15, 28, 06),
                    Rating = 4.6
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 5,
                    ApartmentId = 8,
                    Comment = "Чисто, але було трохи холодно в кімнаті.",
                    DateTime = new DateTime(2024, 02, 13, 15, 28, 06),
                    Rating = 4
                });
                GuestComments.Add(new GuestComments
                {
                    GuestIdUser = 3,
                    ApartmentId = 8,
                    Comment = "Відмінне місце для відпочинку!",
                    DateTime = new DateTime(2024, 02, 12, 15, 28, 06),
                    Rating = 4.9
                });

                SaveChanges();
                #endregion  
                #region Chats
                Chats.Add(new Chat
                {
                    Comment = "Привіт, як ви?",
                    DateTime = DateTime.Now.AddHours(-4),
                    RentalApartmentId = 1,
                    MasterIdUser = 14,  // ot
                    GuestIdUser = 1     // do
                });
                Chats.Add(new Chat
                {
                    Comment = "Добрий вечір, як я можу вам допомогти?",
                    DateTime = DateTime.Now.AddHours(-3),
                    RentalApartmentId = 1,
                    MasterIdUser = 1,
                    GuestIdUser = 14
                });
                Chats.Add(new Chat
                {
                    Comment = "Дуже хочу орендувати кімнату від вас.",
                    DateTime = DateTime.Now.AddHours(-2),
                    RentalApartmentId = 1,
                    MasterIdUser = 14,
                   GuestIdUser = 1
                });
                Chats.Add(new Chat
                {
                    Comment = "О, ласкаво просимо! З радістю вас побачу.",
                    DateTime = DateTime.Now.AddHours(-1),
                    RentalApartmentId = 1,
                    MasterIdUser = 1,
                    GuestIdUser = 14
                });



                Chats.Add(new Chat
                {
                    Comment = "Добрий день! Ми сім'я з чотирьох осіб і хотіли б забронювати дім на літні канікули. Чи є вас підходящі варіанти?",
                    DateTime = DateTime.Now.AddHours(-4),
                    RentalApartmentId = 2,
                    MasterIdUser = 14,
                    GuestIdUser = 2
                });

                Chats.Add(new Chat
                {
                    Comment = "Доброго дня! Так, у нас є декілька варіантів для вашої сім'ї. Скільки часу ви плануєте провести у нас?",
                    DateTime = DateTime.Now.AddHours(-3),
                    RentalApartmentId = 2,
                    MasterIdUser = 2,
                   GuestIdUser = 14
                });

                Chats.Add(new Chat
                {
                    Comment = "Ми плануємо залишитися на два тижні, приблизно з 15 липня по 1 серпня. Чи є доступні дати в цей період?",
                    DateTime = DateTime.Now.AddHours(-2),
                    RentalApartmentId = 2,
                    MasterIdUser = 14,
                    GuestIdUser = 2
                });

                Chats.Add(new Chat
                {
                    Comment = "Так, у нас є доступні дати на ваш період перебування. Які у вас вимоги до дому? Наприклад, скільки спалень вам потрібно?",
                    DateTime = DateTime.Now.AddHours(-1),
                    RentalApartmentId = 2,
                    MasterIdUser = 2,
                    GuestIdUser = 14
                });
                Chats.Add(new Chat
                {
                    Comment = "Привіт! Цикавить чи є на кухні все необхідне обладнання для приготування їжи?",
                    DateTime = DateTime.Now.AddHours(-3),
                    RentalApartmentId = 3,
                    MasterIdUser = 14,
                    GuestIdUser = 3
                });

                Chats.Add(new Chat
                {
                    Comment = "Так, кухня повністю обладнана.",
                    DateTime = DateTime.Now.AddHours(-2),
                    RentalApartmentId = 3,
                    MasterIdUser = 14,
                    GuestIdUser = 3
                });
                SaveChanges();
                #endregion
                #region Pictures
                Pictures.Add(new Picture
                {
                    PictureName = "The Cromwell Collection1",
                    PictureUrl = "1.jpg",
                    RentalApartmentId = 1
                });
                Pictures.Add(new Picture
                {
                    PictureName = "The Cromwell Collection2",
                    PictureUrl = "2.jpg",
                    RentalApartmentId = 1
                });
                Pictures.Add(new Picture
                {
                    PictureName = "The Cromwell Collection3",
                    PictureUrl = "3.jpg",
                    RentalApartmentId = 1
                });
                Pictures.Add(new Picture
                {
                    PictureName = "The Cromwell Collection4",
                    PictureUrl = "4.jpg",
                    RentalApartmentId = 1
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "5.jpg",
                    RentalApartmentId = 1
                });

                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "21.jpg",
                    RentalApartmentId = 2
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "22.jpg",
                    RentalApartmentId = 2
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "23.jpg",
                    RentalApartmentId = 2
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "24.jpg",
                    RentalApartmentId = 2
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "25.jpg",
                    RentalApartmentId = 2
                });


                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "31.jpg",
                    RentalApartmentId = 3
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "32.jpg",
                    RentalApartmentId = 3
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "33.jpg",
                    RentalApartmentId = 3
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "34.jpg",
                    RentalApartmentId = 3
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "35.jpg",
                    RentalApartmentId = 3
                });

                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "41.jpg",
                    RentalApartmentId = 4
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "42.jpg",
                    RentalApartmentId = 4
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "43.jpg",
                    RentalApartmentId = 4
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "44.jpg",
                    RentalApartmentId = 4
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "45.jpg",
                    RentalApartmentId = 4
                });

                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "51.jpg",
                    RentalApartmentId = 5
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "52.jpg",
                    RentalApartmentId = 5
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "53.jpg",
                    RentalApartmentId = 5
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "54.jpg",
                    RentalApartmentId = 5
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "55.jpg",
                    RentalApartmentId = 5
                });

                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "61.jpg",
                    RentalApartmentId = 6
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "62.jpg",
                    RentalApartmentId = 6
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "63.jpg",
                    RentalApartmentId = 6
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "64.jpg",
                    RentalApartmentId = 6
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "65.jpg",
                    RentalApartmentId = 6
                });

                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "71.jpg",
                    RentalApartmentId = 7
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "72.jpg",
                    RentalApartmentId = 7
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "73.jpg",
                    RentalApartmentId = 7
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "74.jpg",
                    RentalApartmentId = 7
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "75.jpg",
                    RentalApartmentId = 7
                });


                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "81.jpg",
                    RentalApartmentId = 8
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "82.jpg",
                    RentalApartmentId = 8
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "83.jpg",
                    RentalApartmentId = 8
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "84.jpg",
                    RentalApartmentId = 8
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "85.jpg",
                    RentalApartmentId = 8
                });


                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "91.jpg",
                    RentalApartmentId = 9
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "92.jpg",
                    RentalApartmentId = 9
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "93.jpg",
                    RentalApartmentId = 9
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "94.jpg",
                    RentalApartmentId = 9
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "95.jpg",
                    RentalApartmentId = 9
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "101.jpg",
                    RentalApartmentId = 10
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "102.jpg",
                    RentalApartmentId = 10
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "103.jpg",
                    RentalApartmentId = 10
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "104.jpg",
                    RentalApartmentId = 10
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "105.jpg",
                    RentalApartmentId = 10
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "111.webp",
                    RentalApartmentId = 11
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "112.webp",
                    RentalApartmentId = 11
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "113.webp",
                    RentalApartmentId = 11
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "114.webp",
                    RentalApartmentId = 11
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "115.webp",
                    RentalApartmentId = 11
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "121.webp",
                    RentalApartmentId = 12
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "122.webp",
                    RentalApartmentId = 12
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "123.webp",
                    RentalApartmentId = 12
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "124.webp",
                    RentalApartmentId = 12
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "125.webp",
                    RentalApartmentId = 12
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "131.webp",
                    RentalApartmentId = 13
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "132.webp",
                    RentalApartmentId = 13
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "133.webp",
                    RentalApartmentId = 13
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "134.webp",
                    RentalApartmentId = 13
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "135.webp",
                    RentalApartmentId = 13
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "141.webp",
                    RentalApartmentId = 14
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "142.webp",
                    RentalApartmentId = 14
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "143.webp",
                    RentalApartmentId = 14
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "144.webp",
                    RentalApartmentId = 14
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "145.webp",
                    RentalApartmentId = 14
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "151.webp",
                    RentalApartmentId = 15
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "152.webp",
                    RentalApartmentId = 15
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "153.webp",
                    RentalApartmentId = 15
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "154.webp",
                    RentalApartmentId = 15
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "155.webp",
                    RentalApartmentId = 15
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "161.webp",
                    RentalApartmentId = 16
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "162.webp",
                    RentalApartmentId = 16
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "163.webp",
                    RentalApartmentId = 16
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "164.webp",
                    RentalApartmentId = 16
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "165.webp",
                    RentalApartmentId = 16
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "171.webp",
                    RentalApartmentId = 17
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "172.webp",
                    RentalApartmentId = 17
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "173.webp",
                    RentalApartmentId = 17
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "174.webp",
                    RentalApartmentId = 17
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "175.webp",
                    RentalApartmentId = 17
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "181.webp",
                    RentalApartmentId = 18
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "182.webp",
                    RentalApartmentId = 18
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "183.webp",
                    RentalApartmentId = 18
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "184.webp",
                    RentalApartmentId = 18
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "185.webp",
                    RentalApartmentId = 18
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "191.webp",
                    RentalApartmentId = 19
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "192.webp",
                    RentalApartmentId = 19
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "193.webp",
                    RentalApartmentId = 19
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "194.webp",
                    RentalApartmentId = 19
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "195.webp",
                    RentalApartmentId = 19
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "201.webp",
                    RentalApartmentId = 20
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "202.webp",
                    RentalApartmentId = 20
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "203.webp",
                    RentalApartmentId = 20
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "204.webp",
                    RentalApartmentId = 20
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "205.webp",
                    RentalApartmentId = 20
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "211.webp",
                    RentalApartmentId = 21
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "212.webp",
                    RentalApartmentId = 21
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "213.webp",
                    RentalApartmentId = 21
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "214.webp",
                    RentalApartmentId = 21
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "215.webp",
                    RentalApartmentId = 21
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "221.webp",
                    RentalApartmentId = 22
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "222.webp",
                    RentalApartmentId = 22
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "223.webp",
                    RentalApartmentId = 22
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "224.webp",
                    RentalApartmentId = 22
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "225.webp",
                    RentalApartmentId = 22
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "231.webp",
                    RentalApartmentId = 23
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "232.webp",
                    RentalApartmentId = 23
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "233.webp",
                    RentalApartmentId = 23
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "234.webp",
                    RentalApartmentId = 23
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "235.webp",
                    RentalApartmentId = 23
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "241.webp",
                    RentalApartmentId = 24
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "242.webp",
                    RentalApartmentId = 24
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "243.webp",
                    RentalApartmentId = 24
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "244.webp",
                    RentalApartmentId = 24
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "245.webp",
                    RentalApartmentId = 24
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "251.webp",
                    RentalApartmentId = 25
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "252.webp",
                    RentalApartmentId = 25
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "253.webp",
                    RentalApartmentId = 25
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "254.webp",
                    RentalApartmentId = 25
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "255.webp",
                    RentalApartmentId = 25
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "261.webp",
                    RentalApartmentId = 26
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "262.webp",
                    RentalApartmentId = 26
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "263.webp",
                    RentalApartmentId = 26
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "264.webp",
                    RentalApartmentId = 26
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "265.webp",
                    RentalApartmentId = 26
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "271.webp",
                    RentalApartmentId = 27
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "272.webp",
                    RentalApartmentId = 27
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "273.webp",
                    RentalApartmentId = 27
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "274.webp",
                    RentalApartmentId = 27
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "275.webp",
                    RentalApartmentId = 27
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "281.webp",
                    RentalApartmentId = 28
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "282.webp",
                    RentalApartmentId = 28
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "283.webp",
                    RentalApartmentId = 28
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "284.webp",
                    RentalApartmentId = 28
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "285.webp",
                    RentalApartmentId = 28
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "291.webp",
                    RentalApartmentId = 29
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "292.webp",
                    RentalApartmentId = 29
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "293.webp",
                    RentalApartmentId = 29
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "294.webp",
                    RentalApartmentId = 29
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "295.webp",
                    RentalApartmentId = 29
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "301.webp",
                    RentalApartmentId = 30
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "302.webp",
                    RentalApartmentId = 30
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "303.webp",
                    RentalApartmentId = 30
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "304.webp",
                    RentalApartmentId = 30
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "305.webp",
                    RentalApartmentId = 30
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "311.webp",
                    RentalApartmentId = 31
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "312.webp",
                    RentalApartmentId = 31
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "313.webp",
                    RentalApartmentId = 31
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "314.webp",
                    RentalApartmentId = 31
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "315.webp",
                    RentalApartmentId = 31
                });

                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "321.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "322.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "323.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "324.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "325.webp",
                    RentalApartmentId = 32
                });


                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "331.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "332.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "333.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "334.webp",
                    RentalApartmentId = 33
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "335.webp",
                    RentalApartmentId = 32
                });

                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "341.webp",
                    RentalApartmentId = 34
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "342.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "343.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "344.webp",
                    RentalApartmentId = 32
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "345.webp",
                    RentalApartmentId = 32
                });


                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "351.webp",
                    RentalApartmentId = 35
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "352.webp",
                    RentalApartmentId = 35
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "353.webp",
                    RentalApartmentId = 35
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "354.webp",
                    RentalApartmentId = 35
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "355.webp",
                    RentalApartmentId = 35
                });


                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "361.webp",
                    RentalApartmentId = 36
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "362.webp",
                    RentalApartmentId = 36
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "363.webp",
                    RentalApartmentId = 36
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "364.webp",
                    RentalApartmentId = 36
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "365.webp",
                    RentalApartmentId = 36
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "371.webp",
                    RentalApartmentId = 37
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "372.webp",
                    RentalApartmentId = 37
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "373.webp",
                    RentalApartmentId = 37
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "374.webp",
                    RentalApartmentId = 37
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "375.webp",
                    RentalApartmentId = 37
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "381.webp",
                    RentalApartmentId = 38
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "382.webp",
                    RentalApartmentId = 38
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "383.webp",
                    RentalApartmentId = 38
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "384.webp",
                    RentalApartmentId = 38
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "385.webp",
                    RentalApartmentId = 38
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "391.webp",
                    RentalApartmentId = 39
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "392.webp",
                    RentalApartmentId = 39
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "393.webp",
                    RentalApartmentId = 39
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "394.webp",
                    RentalApartmentId = 39
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "395.webp",
                    RentalApartmentId = 39
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "401.webp",
                    RentalApartmentId = 40
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "402.webp",
                    RentalApartmentId = 40
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "403.webp",
                    RentalApartmentId = 40
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "404.webp",
                    RentalApartmentId = 40
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "405.webp",
                    RentalApartmentId = 40
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "411.webp",
                    RentalApartmentId = 41
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "412.webp",
                    RentalApartmentId = 41
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "413.webp",
                    RentalApartmentId = 41
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "414.webp",
                    RentalApartmentId = 41
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "415.webp",
                    RentalApartmentId = 41
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "421.webp",
                    RentalApartmentId = 42
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "422.webp",
                    RentalApartmentId = 42
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "423.webp",
                    RentalApartmentId = 42
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "424.webp",
                    RentalApartmentId = 42
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "425.webp",
                    RentalApartmentId = 42
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "431.webp",
                    RentalApartmentId = 43
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "432.webp",
                    RentalApartmentId = 43
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "433.webp",
                    RentalApartmentId = 43
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "434.webp",
                    RentalApartmentId = 43
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "435.webp",
                    RentalApartmentId = 43
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "441.webp",
                    RentalApartmentId = 44
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "442.webp",
                    RentalApartmentId = 44
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "443.webp",
                    RentalApartmentId = 44
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "444.webp",
                    RentalApartmentId = 44
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "445.webp",
                    RentalApartmentId = 44
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "451.webp",
                    RentalApartmentId = 45
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
                    PictureUrl = "452.webp",
                    RentalApartmentId = 45
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "453.webp",
                    RentalApartmentId = 45
                });
                Pictures.Add(new Picture
                {
                    PictureName = "bedroom",
                    PictureUrl = "454.webp",
                    RentalApartmentId = 45
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "455.webp",
                    RentalApartmentId = 45
                });
                SaveChanges();


                #endregion
            }
        }

        public RBContext()
        {
        }


        #region DbSet
        public DbSet<Language> Languages { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Сontinent> Сontinent { get; set; }
        public DbSet<EmergencyContactPerson> EmergencyContactPersons { get; set; }
        public DbSet<GuestPaymentMethod> GuestPaymentMethods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<CommentsAboutGuest> CommentsAboutGuests { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<GuestComments> GuestComments { get; set; }
        public DbSet<OfferedAmenities> OfferedAmenities { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<RentalApartment> RentalApartments { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        #endregion

    }
}
