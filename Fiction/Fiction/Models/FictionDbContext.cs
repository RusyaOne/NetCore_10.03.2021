using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public class FictionDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }


        private IConfiguration _configuration;

        public FictionDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("FictionDbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Finn Mertens", Age = 14 },
                new Character { Id = 2, Name = "Philip Fry", Age = 25 },
                new Character { Id = 3, Name = "Arven Undomiel", Age = 2700 });
        }
    }
}