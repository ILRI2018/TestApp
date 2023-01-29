using System.ComponentModel.DataAnnotations.Schema;

namespace NasaStars.VM
{
    public class StarGroupVM
    {
        public int Year { get; set; }
        public int TotalSumMass { get; set; }
        public int TotalCount { get; set; }
    }
}


