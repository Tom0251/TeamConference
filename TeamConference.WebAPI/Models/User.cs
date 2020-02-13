using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamConference.WebAPI.Models
{
    public class User: IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }
}
