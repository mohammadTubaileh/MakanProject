using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakanProject.Models
{
    public class Booking
    {

        
        [Key]
            public int Id { get; set; }
            public int VillaId { get; set; }

            [ForeignKey("VillaId")] 
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public virtual Villa Villa { get; set; }
        
    }
}
