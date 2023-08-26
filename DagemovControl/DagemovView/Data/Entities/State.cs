using System.Text.Json.Serialization;

namespace DagemovView.Data.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public Country Country { get; set; }
        public ICollection<City> Citys { get; set; }
        public int CityNumber => Citys == null ? 0 : Citys.Count;
    }
}
