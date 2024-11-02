using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakanProject.Models
{
    public class Villa 
    {
        [Key]  
        public int VillaId { get; set; } 

        [Required] 
        [StringLength(100)]  
        public string VillaName { get; set; }

        [Required]  
        public string VillaDescription { get; set; }

        [Range(1, 20)] 
        public int VillaNumberOfRooms { get; set; }

        [Range(1, 10)]  
        public int VillaNumberOfBathrooms { get; set; }

        [Range(0, 10000)]  
        public double VillaPricePerNight { get; set; }

        [Required]  
        public string VillaLocation { get; set; }


        [DataType(DataType.Date)]
        public DateTime VillaDateAvailable { get; set; }  

        [StringLength(250)]
        public string? VillaImageUrl { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        
        public virtual ICollection<Booking> Bookings { get; set; } 


    }
}
