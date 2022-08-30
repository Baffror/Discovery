using Discovery.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Discovery.Data
{
    public class AspNetIdentityDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }

        public AspNetIdentityDbContext(DbContextOptions options) : base(options)
        {



        }
    }
}
