using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TeamConference.WebAPI.Models
{
    public class TeamConferenceContext : IdentityDbContext
    {
        public TeamConferenceContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<User> ApplicationUsers { get; set; }
    }
}
