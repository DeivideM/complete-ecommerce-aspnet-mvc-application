using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 500 characters")]
        public string FullName { get; set; } = string.Empty;
        
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; } = string.Empty;
        
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; } = string.Empty;

        //Relationships
        public List<Movie> Movies { get; set; } = [];
    }
}
