using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace NasaStars.DAL.Models
{
    [Index("Year", "Recclass")]
    public class Star
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nametype { get; set; }
        public string Recclass { get; set; }
        [Precision(14,6)]
        public decimal Mass { get; set; }
        [Precision(14, 6)]
        public string Fall { get; set; }
        public DateTime? Year { get; set; }
        [Precision(14, 6)]
        public decimal Reclat { get; set; }
        [Precision(14, 6)]
        public decimal Reclong { get; set; }
        [NotMapped]
        public Geolocation Geolocation { get; set; }
        public string Type { get; set; }
        public string Coordinates { get; set; }

        public int ComputedRegionCbhkFwbd { get; set; }
        public int ComputedRegionNnqa { get; set; }

    }
}
