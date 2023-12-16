using System.ComponentModel.DataAnnotations;

namespace BookFlight.Model
{
    public class BookFlightModel
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string Time { get; set; }
    }
}
