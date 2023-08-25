namespace DagemovView.Data.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}
