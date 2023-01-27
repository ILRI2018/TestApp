﻿using Microsoft.EntityFrameworkCore;

namespace NasaStars.DAL
{
    public class NasaStarsContext: DbContext
    {
        public NasaStarsContext(DbContextOptions options) : base(options) { }

        public DbSet<Models.Star> Stars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
