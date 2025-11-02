using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; } = string.Empty;
        [Display(Name = "Cinema")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //Relationships
        public List<Movie> Movies { get; set; } = [];
    }
}
