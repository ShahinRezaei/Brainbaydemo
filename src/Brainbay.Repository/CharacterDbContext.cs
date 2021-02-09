using Brainbay.Common;
using Brainbay.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brainbay.Repository
{
    public class CharacterDbContext : DbContext
    {

        
        public CharacterDbContext()
        {
        }

        public CharacterDbContext(DbContextOptions<CharacterDbContext> options)
            :base(options)
        {
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CharacterDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

         public DbSet<Character> Characters { get; set; }
         public DbSet<CharacterType> CharacterTypes { get; set; }
         public DbSet<Episode> Episodes { get; set; }
         public DbSet<Gender> Genders { get; set; }
         public DbSet<Location> Locations { get; set; }
         public DbSet<Origin> Origins { get; set; }
         public DbSet<Species> Species { get; set; }
         public DbSet<Status> Statuses { get; set; }

    }
}
