using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "Full Name")]
    public string Fullname { get; set; } = string.Empty;
}
