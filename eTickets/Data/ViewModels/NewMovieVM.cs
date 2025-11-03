using eTickets.Data.Enums;
using eTickets.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data.ViewModels;

public class NewMovieVM
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Movie Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [Display(Name = "Movie Description")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Price is required")]
    [Display(Name = "Price in $")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Movie poster is required")]
    [Display(Name = "Movie poster URL")]
    public string ImageURL { get; set; } = string.Empty;

    [Required(ErrorMessage = "Start date is required")]
    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required")]
    [Display(Name = "End date")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Movie category is required")]
    [Display(Name = "Select a category")]
    public MovieCategory MovieCategory { get; set; }

    [Required(ErrorMessage = "Movie actor(s) is/are required")]
    [Display(Name = "Select actor(s)")]
    public required List<int> ActorIds { get; set; }

    [Required(ErrorMessage = "Movie cinema is required")]
    [Display(Name = "Select a cinema")]
    public int CinemaId { get; set; }

    [Required(ErrorMessage = "Movie procuder is required")]
    [Display(Name = "Select a producer")]
    public int ProducerId { get; set; }

}
