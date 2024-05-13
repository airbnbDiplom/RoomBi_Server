

namespace RoomBi.DAL
{
    public class OfferedAmenities
    {
        public int Id { get; set; }


        // Basic amenities
        public bool WiFi { get; set; } // Вай-Фай
        public bool TV { get; set; } // Телевизор
        public bool Kitchen { get; set; } // Кухня
        public bool WashingMachine { get; set; } // Стиральная машина
        public bool FreeParking { get; set; } // Бесплатная парковка на территории
        public bool PaidParking { get; set; } // Платная парковка на территории
        public bool AirConditioner { get; set; } // Кондиционер
        public bool Workspace { get; set; } // Рабочая зона

        // Special features
        public string? SpecialFeatures { get; set; } // Есть ли у вас что-то особенное?

        // Outdoor amenities
        public bool Pool { get; set; } // Бассейн
        public bool Jacuzzi { get; set; } // Джакузи
        public bool InnerYard { get; set; } // Внутренний двор
        public bool BBQArea { get; set; } // Зона барбекю
        public bool OutdoorDiningArea { get; set; } // Обеденная зона на улице
        public bool FirePit { get; set; } // Костровище
        public bool PoolTable { get; set; } // Стол для игры в пул
        public bool Fireplace { get; set; } // Камин
        public bool Piano { get; set; } // Пианино
        public bool GymEquipment { get; set; } // Тренажеры
        public bool LakeAccess { get; set; } // Выход к озеру
        public bool BeachAccess { get; set; } // Выход на пляж
        public bool SkiInOut { get; set; } // Вход/выход на лыжах
        public bool OutdoorShower { get; set; } // Душ на улице

        // Safety features
        public bool SmokeDetector { get; set; } // Датчик дыма
        public bool FirstAidKit { get; set; } // Аптечка
        public bool FireExtinguisher { get; set; } // Огнетушитель
        public bool CarbonMonoxideDetector { get; set; } // Датчик угарного газа



        // Description
        public string? Description { get; set; } // Описание

       
    }

}
