namespace NasaStars.VM
{
    public class StarResultVM
    {
        public Dictionary<int, StarGroupVM> GroupByYearStars { get; set; } = new Dictionary<int, StarGroupVM>();
        public List<StarGroupVM> StarGroupVMs { get; set; } = new List<StarGroupVM>();
        public int Total { get; set; }
        public decimal TotalMass { get; set; }
    }
}
