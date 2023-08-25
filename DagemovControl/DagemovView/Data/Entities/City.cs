namespace DagemovView.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}
