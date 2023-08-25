namespace DagemovView.Data.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Citys { get; set; }
        public int CityNumber => Citys.Count;
    }
}
