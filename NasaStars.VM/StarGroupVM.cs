using System.ComponentModel.DataAnnotations.Schema;

namespace NasaStars.VM
{
    public class StarGroupVM
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public decimal TotalSumMass { get; set; }
        public int TotalCount { get; set; }
    }
}


