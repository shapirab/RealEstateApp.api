using RealEstateApp.Data.DataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.DataModels.Entities
{
    public class PropertyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }
        [Required]
        public PropertyType PropertyType { get; set; }
        [Required]
        public int NumberOfBedrooms { get; set; }
        [Required]
        public bool Furnishing { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        public string? SpecialFeatures { get; set; }
        [Required]
        public DateTime Availibility { get; set; }
        public double? PropertyAge { get; set; }
        public bool? IsGate { get; set; }
        public string? MainEntrance { get; set; }
        [Required]
        public double TotalPropertyArea { get; set; }
        public double? BuiltArea { get; set; }
        public double? CarpetArea { get; set; }
        public CarParkingType? CarParking { get; set; }
        public CommerciaType? CommercialUse { get; set; }
        [MaxLength(200)]
        public string? Comments { get; set; }
    }
}
