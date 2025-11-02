using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        //public Guid PublicId { get; set; } = Guid.NewGuid();

        [Display(Name = "Full Name")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 500 characters")]
        [Required(ErrorMessage ="Full name is required")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; } = string.Empty;

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; } = string.Empty;

        //Relationships
        public List<Actors_Movies> Actors_Movies { get; set; } = [];
        
    }
}
