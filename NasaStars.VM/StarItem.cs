using System.ComponentModel.DataAnnotations.Schema;

namespace NasaStars.VM
{
    public class StarItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Mass { get; set; }
        public string Recclass { get; set; }
        public DateTime? Year { get; set; }

    }
}


