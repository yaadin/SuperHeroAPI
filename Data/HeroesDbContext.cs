using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using SuperHeroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
	public class HeroesDbContext : DbContext
	{
        public HeroesDbContext(DbContextOptions<HeroesDbContext> options) : base(options)
        {
        }
        public DbSet<HeroModel> hero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroModel>().HasData(
                new HeroModel
                {
                    ID = 1,
                    Name = "Peter Parker",
                    rating = 9.7,
                    Description = "Spider Man"
                }
                );
        }
    }
}


