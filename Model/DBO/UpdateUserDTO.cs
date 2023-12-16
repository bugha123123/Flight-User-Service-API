using System.ComponentModel.DataAnnotations;

namespace BookFlight.Model.DBO
{
    public class UpdateUserDTO
    {

        [Required]


        public string EmailAddress { get; set; }

        [Required]

        public string Password { get; set; }

    }
}
