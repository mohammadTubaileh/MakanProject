using System.ComponentModel.DataAnnotations;

namespace MakanProject.Models
{
    public class Apartment :SharedProb
    {
        [Key]  
        public int ApartmentId { get; set; }

        [Required]  
        [StringLength(100)]  
        public string ApartmentName { get; set; }

        [Required]  
        [StringLength(500)]  
        public string ApartmentDescription { get; set; }

        [Required]  
        public string ApartmentLocation { get; set; }

        [Range(1, 50)]  
        public int ApartmentNumberOfRooms { get; set; }

        [Range(1, 20)]  
        public int ApartmentNumberOfBathrooms { get; set; }


        [Range(0, 10000)]  
        public double ApartmentPricePerNight { get; set; }

        [DataType(DataType.Date)]
        public DateTime ApartmentDateAvailable { get; set; }  

        [StringLength(250)]
        public string? ApartmentImageUrl { get; set; }  
    }
}
