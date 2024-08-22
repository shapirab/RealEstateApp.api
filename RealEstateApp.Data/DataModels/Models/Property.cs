using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.DataModels.Models
{
    public enum PropertyType
    {
        House,
        Apartment,
        Condo
    }

    public enum CarParkingType
    {
        IndoorGarage,
        OnStreet,
        DrivewayParking
    }

    public enum CommerciaType
    {
        Rent,
        Sell
    }

    public class Address
    {
        public string City;
        public string State;
    }

    public class Property
    {
        
        public int PropertyId { get; set; }
        public PropertyType PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public bool Furnishing { get; set; }
        public Address Address { get; set; }
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

        public Property()
        {
            
        }

        public Property(int propertyId, PropertyType propertyType, int numberOfBedrooms, bool furnishing, 
            Address address, int? floor, int? totalFloors, string? specialFeatures, DateTime availibility, 
            double propertyAge, bool isGate, string? mainEntrance, double totalPropertyArea, double? builtArea, 
            double? carpetArea, CarParkingType? carParking, CommerciaType? commercialUse, string? comments)
        {
            PropertyId = propertyId;
            PropertyType = propertyType;
            NumberOfBedrooms = numberOfBedrooms;
            Furnishing = furnishing;
            Address = address;
            Floor = floor;
            TotalFloors = totalFloors;
            SpecialFeatures = specialFeatures;
            Availibility = availibility;
            PropertyAge = propertyAge;
            IsGate = isGate;
            MainEntrance = mainEntrance;
            TotalPropertyArea = totalPropertyArea;
            BuiltArea = builtArea;
            CarpetArea = carpetArea;
            CarParking = carParking;
            CommercialUse = commercialUse;
            Comments = comments;
        }
    }
}
