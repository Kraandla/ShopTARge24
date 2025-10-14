namespace ShopTARge24.Core.Dto
{

    public class AccuLocationRootDto
        {
            public string? LocalObservationDateTime { get; set; }
            public long EpochTime { get; set; }
            public string? WeatherText { get; set; }
            public int WeatherIcon { get; set; }
            public bool HasPrecipitation { get; set; }
            public string? PrecipitationType { get; set; }
            public bool IsDayTime { get; set; }

            public string? MobileLink { get; set; }
            public string? Link { get; set; }

            public class Temperature
            {
                public UnitValue? Metric { get; set; }
                public UnitValue? Imperial { get; set; }
            }

            public class UnitValue
            {
                public double Value { get; set; }
                public string? Unit { get; set; }
                public int UnitType { get; set; }
            }
        }

}

