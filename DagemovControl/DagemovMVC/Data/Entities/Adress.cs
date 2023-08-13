namespace DagemovMVC.Data.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }

        public Service Service { get; set; }
        public Client Client { get; set; }
        public User User { get; set; }
    }
}
