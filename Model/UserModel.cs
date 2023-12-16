using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BookFlight.Model
{
    public class UserModel
    {
       

        [Key]
        public int Id { get; set; }


        public string UserName { get; set; }
        [Required]


        public string EmailAddress { get; set; }


        [Required]

        public string Password { get; set; }

        public DateTime JoinedAt { get; set; }




    }
}
