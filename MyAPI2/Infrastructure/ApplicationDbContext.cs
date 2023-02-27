using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MyAPI2.Domain.Entities;

namespace MyAPI2.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Gender> Genders { get; set; }  
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Gender>().ToTable("Gender");
        }
    }
    
}
