using Microsoft.EntityFrameworkCore;

namespace NasaStars.DAL
{
    public class NasaStarsContext: DbContext
    {
        public NasaStarsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
