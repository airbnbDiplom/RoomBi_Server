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
            //Database.EnsureCreated();
            if (Database.EnsureCreated())
            {
                Languages.Add(new Language { Name = "Англійська" }); // English
                Languages.Add(new Language { Name = "Українська" });
                Countries.Add(new Country { Name = "Україна", CountryCode = "+380" });
                Countries.Add(new Country { Name = "Велика Британія", CountryCode = "+44" });
                Countries.Add(new Country { Name = "Румунія", CountryCode = "+40" });
                Countries.Add(new Country { Name = "Німеччина", CountryCode = "+49" });
                Countries.Add(new Country { Name = "Італія", CountryCode = "+39" });

                Locations.Add(new Location { Name = "На пляжі" }); //OnBeach
                Locations.Add(new Location { Name = "Арктика" }); // Arctic
                Locations.Add(new Location { Name = "Поряд є озеро" }); // ThereIsLakeNearby
                Locations.Add(new Location { Name = "Острови" }); // islands
                Locations.Add(new Location { Name = "Тропіки" }); // Tropics
                Locations.Add(new Location { Name = "Національні парки" }); // NationalParks
                Locations.Add(new Location { Name = "Місто мрії" }); // CityOfDreams
                Locations.Add(new Location { Name = "Пустеля" }); // Desert
                Locations.Add(new Location { Name = "Біля пляжу" }); // NearTheBeach


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

                Sports.Add(new Sport { Name = "Серфінг" }); // Surfing
                Sports.Add(new Sport { Name = "Катання на лижах" }); // Skiing
                Sports.Add(new Sport { Name = "Виноградники" }); // Vineyards
                Sports.Add(new Sport { Name = "Гольф" }); // Golf
                Sports.Add(new Sport { Name = "B&B" }); // B&B

                SaveChanges();
                Users.Add(new User
                {
                    Name = "Дмитро Золкин",
                    Password = "password123",
                    Email = "dimzolkin@example.com",
                    Address = "Київ,вул.Миру 42",
                    PhoneNumber = "+123456789",
                    LanguageId = 2,
                    CountryId = 2,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    AirbnbRegistrationYear = new DateTime(2015, 3, 10),
                    ProfilePicture = "profile.jpg",

                    CurrentStatus = false,
                    UserStatus = false
                });
                Users.Add(new User
                {

                    Name = "Jane Smith",
                    Password = "strongpassword456",
                    Email = "jane.smith@example.com",
                    Address = "456 Oak St",
                    PhoneNumber = "+987654321",
                    LanguageId = 1,
                    CountryId = 2,
                    DateOfBirth = new DateTime(1985, 8, 22),
                    AirbnbRegistrationYear = new DateTime(2018, 6, 5),
                    ProfilePicture = "avatar.jpg",
                    CurrentStatus = true,
                    UserStatus = true
                });
                SaveChanges();
                GuestPaymentMethods.Add(new GuestPaymentMethod
                {

                    CardNumber = "**** **** **** 1234",
                    ExpirationDate = "12/25",
                    CVV = "123",
                    CardType = "Visa",
                    IdUser = 1
                });
                GuestPaymentMethods.Add(new GuestPaymentMethod
                {
                    CardNumber = "**** **** **** 5678",
                    ExpirationDate = "06/24",
                    CVV = "456",
                    CardType = "MasterCard",
                    IdUser = 2
                });
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
                    IdUser = 1
                });
                SaveChanges();
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
                    CashRegisterParticular = true, // Касовий апарат 
                    LargeKitchens = true, // Великі кухні
                    SpecialFeatures = "Some special features here",
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
                    Description = "Description of the offered amenities."
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
                    CashRegisterParticular = true, // Касовий апарат 
                    LargeKitchens = true, // Великі кухні
                    SpecialFeatures = "Some special features here",
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
                    Description = "Description of the offered amenities."
                });


                RentalApartments.Add(new RentalApartment
                {
                    Title = "The Cromwell Collection",
                    Address = "Лондон, Кенсингтон и Челси, 23 Old Brompton Road",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 4,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    Beds = 3,
                    PricePerNight = 150.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.9,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Tulse Hill Luxury Cosy Rooms",
                    Address = "Лондон, Ламбет, 18 Northstead Road, SW2 3JW ",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 2,
                    Beds = 1,
                    PricePerNight = 110.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.7,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Camden House",
                    Address = "Лондон, Rousden Street, Камден, NW1 0ST",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 2,
                    Beds = 3,
                    PricePerNight = 45.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.8,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "The Beaufort",
                    Address = "Лондон, 33 Beaufort Gardens, Кенсингтон и Челси, SW3 1PP",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 200.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "D8 House",
                    Address = "Лондон, 124 Bethnal Green Road, Тауэр-Хэмлетс, E2 6DG",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 65.0,
                    ObjectState = "Вільний",
                    ObjectRating = 4.7,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Fashionable Brick Lane",
                    Address = "Лондон, Brick Lane, Тауэр-Хэмлетс",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 99.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });

                RentalApartments.Add(new RentalApartment
                {

                    Title = "Flat 17",
                    Address = "Лондон, 88-90 Elden House, Кенсингтон и Челси, SW3 3E",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 59.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Avari Apartments",
                    Address = "Лондон, 17 Winchester Street, Вестминстер, SW1V 4PA",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 75.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });


                RentalApartments.Add(new RentalApartment
                {

                    Title = "Stunning duplex with terrace",
                    Address = "Лондон, 135 York Way 3 Salamander Court, N7 9LG,",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 6,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    Beds = 3,
                    PricePerNight = 169.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Paddington by CAPITAL",
                    Address = "Лондон,  9 Devonshire Terrace, Вестминстер, W2 3DN,",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 55.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 11,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 2,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Мінібудинок",
                    Address = "Німеччина,  Schöneck/Vogtland",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 3,
                    Bedrooms = 3,
                    Bathrooms = 1,
                    Beds = 3,
                    PricePerNight = 123.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 4,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Мінібудинок",
                    Address = "Німеччина,  Mittelstrimmig",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 3,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 99.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 4,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Транспортний контейнер",
                    Address = "Німеччина,  Mettmann",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 92.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 4,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Мінібудинок",
                    Address = "Німеччина,  Schöneck/Vogtland",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 3,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 3,
                    PricePerNight = 138.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 4,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Мінібудинок",
                    Address = "Німеччина,  Reisbach",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 93.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 4,
                });
                 RentalApartments.Add(new RentalApartment
                {

                    Title = "Мінібудинок",
                    Address = "Німеччина,  Welzow",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 2,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 66.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 31,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 4,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Будинок на дереві",
                    Address = "Румунія,  Porumbacu de Jos",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 1,
                    PricePerNight = 166.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 7,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Будинок на дереві",
                    Address = "Румунія,  Moisei",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
                    NumberOfGuests = 4,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Beds = 2,
                    PricePerNight = 87.0,
                    ObjectState = "Вільний",
                    ObjectRating = 5,
                    OfferedAmenitiesId = 1,
                    TypeApartment = "Ціле помешкання",
                    HouseId = 7,
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Будинок на дереві",
                    Address = "Румунія,  Peșteana",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Будинок на дереві",
                    Address = "Румунія,  Râșnov",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Будинок на дереві",
                    Address = "Румунія,  Șelari",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Квартира з видом на море та терасою",
                    Address = "Італія,  Ravello",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Трулло",
                    Address = "Італія,  Cisternino",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Антральний лофт",
                    Address = "Італія,  Salerno",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Сассі Матери",
                    Address = "Італія,  Матера",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Білий дім у центрі",
                    Address = "Італія,  Ostuni",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 4,
                    CountryId = 5,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Бутик Dominic",
                    Address = "Румунія,  Cloașterf",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    LocationId = 7,
                    SportId = 2,
                    CountryId = 3,
                });
                RentalApartments.Add(new RentalApartment
                {

                    Title = "Cabana Colt Verde 2",
                    Address = "Румунія,  Slăvuța",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "AdyBeca - Forest Nook",
                    Address = "Румунія,  Șuncuiuș",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Трансильванська ферма",
                    Address = "Румунія,  Aluniș",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Сучасний зруб з каміном і сауною",
                    Address = "Румунія,  Dealu Negru",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Дерев 'яний будинок",
                    Address = "Румунія,  Bulzeștii de Sus",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Замок Ґалбіно",
                    Address = "Італія,  Anghiari",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Середньовічний замок",
                    Address = "Італія,  Вітторіо-Венето",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Середньовічний замок",
                    Address = "Італія,  Gualdo Cattaneo",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Дімора - приголомшливий старовинний замок",
                    Address = "Італія,  Monselice",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Абатство Сан-Джусто",
                    Address = "Італія,  Tuscania",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Torre Trasita",
                    Address = "Італія,  Positano",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Вежа замку",
                    Address = "Італія,  Roncade",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Pathfinder",
                    Address = "Румунія,  Moacșa",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Затишний будинок-фургон",
                    Address = "Румунія,  Urlați",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "ферма Habitat",
                    Address = "Італія,  Сорренто",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Літл-Парадайс",
                    Address = "Італія,  Granieri",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Караваном",
                    Address = "Італія,  Альгеро",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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

                    Title = "Флоріан - вогнище!",
                    Address = "Італія,  Lacona",
                    IngMap = "51.509865",
                    LatMap = "-0.118092",
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
                    OwnerId = 2,
                    ApartmentId = 2,
                    CheckInDate = DateTime.Now.AddDays(10),
                    CheckOutDate = DateTime.Now.AddDays(14),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 3,
                    CheckInDate = DateTime.Now.AddDays(2),
                    CheckOutDate = DateTime.Now.AddDays(14),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 4,
                    CheckInDate = DateTime.Now.AddDays(5),
                    CheckOutDate = DateTime.Now.AddDays(10),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 4,
                    CheckInDate = DateTime.Now.AddDays(12),
                    CheckOutDate = DateTime.Now.AddDays(15),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 5,
                    CheckInDate = DateTime.Now.AddDays(32),
                    CheckOutDate = DateTime.Now.AddDays(39),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 6,
                    CheckInDate = DateTime.Now.AddDays(2),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 7,
                    CheckInDate = DateTime.Now.AddDays(2),
                    CheckOutDate = DateTime.Now.AddDays(99),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 8,
                    CheckInDate = DateTime.Now.AddDays(20),
                    CheckOutDate = DateTime.Now.AddDays(29),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 9,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 10,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 10,
                    CheckInDate = DateTime.Now.AddDays(12),
                    CheckOutDate = DateTime.Now.AddDays(29),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 11,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(3),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 11,
                    CheckInDate = DateTime.Now.AddDays(10),
                    CheckOutDate = DateTime.Now.AddDays(22),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 12,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(5),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 12,
                    CheckInDate = DateTime.Now.AddDays(13),
                    CheckOutDate = DateTime.Now.AddDays(19),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 13,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 14,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(7),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 15,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(4),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 15,
                    CheckInDate = DateTime.Now.AddDays(9),
                    CheckOutDate = DateTime.Now.AddDays(13),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 16,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(5),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 17,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(22),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 18,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(2),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 19,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(12),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 20,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(15),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 21,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 22,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(18),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 23,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(6),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 24,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(3),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 25,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(13),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 26,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(21),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 27,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(6),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 28,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(23),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 29,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(11),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 30,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(3),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 31,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(14),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 32,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 32,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(2),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 33,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(31),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 34,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(5),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 35,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(7),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 36,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(9),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 37,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(4),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 38,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(15),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 39,
                    CheckInDate = DateTime.Now.AddDays(11),
                    CheckOutDate = DateTime.Now.AddDays(23),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 40,
                    CheckInDate = DateTime.Now.AddDays(2),
                    CheckOutDate = DateTime.Now.AddDays(4),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 41,
                    CheckInDate = DateTime.Now.AddDays(5),
                    CheckOutDate = DateTime.Now.AddDays(8),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 42,
                    CheckInDate = DateTime.Now.AddDays(10),
                    CheckOutDate = DateTime.Now.AddDays(32),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 43,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(10),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 44,
                    CheckInDate = DateTime.Now.AddDays(9),
                    CheckOutDate = DateTime.Now.AddDays(12),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                }); Bookings.Add(new Booking
                {
                    OwnerId = 2,
                    ApartmentId = 45,
                    CheckInDate = DateTime.Now.AddDays(5),
                    CheckOutDate = DateTime.Now.AddDays(15),
                    NumberOfGuests = 3,
                    TotalPrice = 300.0,
                    PaymentStatus = false
                });
                
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

                GuestСomments.Add(new GuestСomments
                {
                    GuestIdUser = 1,
                    ApartmentId = 1,
                    Comment = "Відмінно!",
                    DateTime = DateTime.Now.AddDays(-1),
                    Rating = 4.5
                });

                GuestСomments.Add(new GuestСomments
                {
                    GuestIdUser = 2,
                    ApartmentId = 1,
                    Comment = "Сподобалося!",
                    DateTime = DateTime.Now.AddDays(-3),
                    Rating = 5.0
                });

                GuestСomments.Add(new GuestСomments
                {
                    GuestIdUser = 2,
                    ApartmentId = 1,
                    Comment = "Замечательне місце!",
                    DateTime = DateTime.Now.AddDays(-5),
                    Rating = 4.8
                });

                SaveChanges();

                Chats.Add(new Chat
                {
                    Comment = "Привіт, як ви?",
                    DateTime = DateTime.Now.AddHours(-4),
                    RentalApartmentId = 1,
                    MasterIdUser = 1,
                    GuestIdUser = 2
                });

                Chats.Add(new Chat
                {
                    Comment = "Добрий вечір, як я можу вам допомогти?",
                    DateTime = DateTime.Now.AddHours(-3),
                    RentalApartmentId = 1,
                    MasterIdUser = 1,
                    GuestIdUser = 2
                });

                Chats.Add(new Chat
                {
                    Comment = "Дуже хочу орендувати кімнату від вас.",
                    DateTime = DateTime.Now.AddHours(-2),
                    RentalApartmentId = 1,
                    MasterIdUser = 1,
                    GuestIdUser = 2
                });

                Chats.Add(new Chat
                {
                    Comment = "О, ласкаво просимо! З радістю вас побачу.",
                    DateTime = DateTime.Now.AddHours(-1),
                    RentalApartmentId = 1,
                    MasterIdUser = 1,
                    GuestIdUser = 2
                });

                SaveChanges();
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
                    PictureName = "The Cromwell Collection5",
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
                    PictureName = "Foto4",
                    PictureUrl = "24.jpg",
                    RentalApartmentId = 2
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "25.jpg",
                    RentalApartmentId = 2
                });


                Pictures.Add(new Picture
                {
                    PictureName = "Foto1",
                    PictureUrl = "31.jpg",
                    RentalApartmentId = 3
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto2",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto4",
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
                    PictureName = "Foto1",
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
                    PictureName = "Foto3",
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
                    PictureName = "Foto4",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto2",
                    PictureUrl = "132.webp",
                    RentalApartmentId = 13
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
                    PictureUrl = "133.webp",
                    RentalApartmentId = 13
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto3",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto3",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto4",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto3",
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
                    PictureName = "Foto3",
                    PictureUrl = "253.webp",
                    RentalApartmentId = 25
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
                    PictureUrl = "254.webp",
                    RentalApartmentId = 25
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
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
                    PictureName = "Foto4",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto3",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto4",
                    PictureUrl = "334.webp",
                    RentalApartmentId = 33
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto5",
                    PictureUrl = "345.webp",
                    RentalApartmentId = 34
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto4",
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
                    PictureName = "Foto5",
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
                    PictureName = "Foto3",
                    PictureUrl = "393.webp",
                    RentalApartmentId = 39
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
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
                    PictureName = "Foto3",
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
                    PictureName = "Foto3",
                    PictureUrl = "413.webp",
                    RentalApartmentId = 41
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto4",
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
                    PictureName = "Foto3",
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
                    PictureName = "Foto2",
                    PictureUrl = "432.webp",
                    RentalApartmentId = 43
                });
                Pictures.Add(new Picture
                {
                    PictureName = "Foto3",
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
                    PictureName = "Foto2",
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
                    PictureName = "Foto4",
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
            }
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EmergencyContactPerson> EmergencyContactPersons { get; set; }
        public DbSet<GuestPaymentMethod> GuestPaymentMethods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<CommentsAboutGuest> CommentsAboutGuests { get; set; }
        public DbSet<Chat> Chats { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<GuestСomments> GuestСomments { get; set; }
        public DbSet<OfferedAmenities> OfferedAmenities { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public DbSet<RentalApartment> RentalApartments { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

    }
}
