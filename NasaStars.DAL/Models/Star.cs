using System.ComponentModel.DataAnnotations.Schema;

namespace NasaStars.DAL.Models
{
    public class Star
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nametype { get; set; }
        public string Recclass { get; set; }
        public string Mass { get; set; }
        public string Fall { get; set; }
        public DateTime Year { get; set; }
        public decimal Reclat { get; set; }
        public decimal Reclong { get; set; }
        [NotMapped]
        public Geolocation Geolocation { get; set; }

        public int ComputedRegionCbhkFwbd { get; set; }

        public int ComputedRegionNnqa { get; set; }

    }
}
