using System.ComponentModel.DataAnnotations;

namespace BookFlight.Model.DBO
{
    public class EmailDTO
    {
        [Required]
        public string To { get; set; } = string.Empty;





        public string body { get; set; } = string.Empty;




         


    }
}
