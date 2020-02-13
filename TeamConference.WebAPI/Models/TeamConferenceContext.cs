using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
