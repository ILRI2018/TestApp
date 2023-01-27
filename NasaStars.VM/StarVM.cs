using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace NasaStars.VM
{
    public struct StarVM
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
        //[NotMapped]
        //public GeolocationVM Geolocation { get; set; }

        [JsonProperty(":@computed_region_cbhk_fwbd")]
        public int ComputedRegionCbhkFwbd { get; set; }

        [JsonProperty(":@computed_region_nnqa_25f4")]
        public int ComputedRegionNnqa { get; set; }
    }
}
