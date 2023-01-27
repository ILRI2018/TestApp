namespace NasaStars.DAL.Models
{
    public class Geolocation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal[] Coordinates { get; set; }
    }
}
