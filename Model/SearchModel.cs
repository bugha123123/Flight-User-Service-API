using System.ComponentModel.DataAnnotations;

namespace BookFlight.Model
{
    public class SearchModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserSearched { get; set; }
    }
}
