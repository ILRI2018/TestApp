namespace NasaStars.VM
{
    public class StarResultVM
    {
        public List<StarItem> StarItems { get; set; }
        public Dictionary<int, List<StarItem>> GroupStarsByYear { get; set; } = new Dictionary<int, List<StarItem>>();
        //public int TotalSumm { get; set; }


    }
}
