namespace NasaStars.VM
{
    public class StarResultVM
    {
        public Dictionary<int, StarGroupVM> GroupByYearStars { get; set; } = new Dictionary<int, StarGroupVM>();
    }
}
