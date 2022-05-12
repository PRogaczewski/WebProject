using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Models;

namespace CarRentalWebProject.Model
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) {}
        public DbSet<Car> cars { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<City> cities { get; set; }
    }
}
