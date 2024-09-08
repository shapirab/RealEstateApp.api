using RealEstateApp.Data.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.DataModels.DTOs
{
    public class PropertyDto
    {
        public PropertyType PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public bool Furnishing { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        public string? SpecialFeatures { get; set; }
        public DateTime Availibility { get; set; }
        public double PropertyAge { get; set; }
        public bool IsGate { get; set; }
        public string? MainEntrance { get; set; }
        public double TotalPropertyArea { get; set; }
        public double? BuiltArea { get; set; }
        public double? CarpetArea { get; set; }
        public CarParkingType? CarParking { get; set; }
        public CommerciaType? CommercialUse { get; set; }
        public string? Comments { get; set; }
    }
}
