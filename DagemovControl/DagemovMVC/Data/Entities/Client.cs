namespace DagemovMVC.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Adress> Adresses { get; set; }
        public ICollection<Phone> Phones { get; set; }
    }
}
