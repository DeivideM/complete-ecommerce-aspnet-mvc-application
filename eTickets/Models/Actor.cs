using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfilePictureURL { get; set; } = string.Empty;

        //Relationships
        public List<Actors_Movies> Actors_Movies { get; set; } = [];
    }
}
