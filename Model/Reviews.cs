using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookFlight.Model
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        
        public string TitleInput { get; set; }

        [Required]
        public string MyReviews { get; set; }

        [Required]
        public string LocationInput { get; set; }

        public string Image { get; set; }

        //[ForeignKey(nameof(UserModel))]
        //public int  UserModelId { get; set; }

        //public UserModel UserModel { get; set; }

    }
}
