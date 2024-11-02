using System.ComponentModel.DataAnnotations;

namespace MakanProject.Models
{
    public class Request
    {

        public int RequestId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int UserNumber { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
