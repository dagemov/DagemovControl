namespace DagemovMVC.Data.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public int Phone1 { get; set; }
        public int Phone2 { get; set; }
        public int Phone3 { get; set; }

        public Client Client { get; set; }
        public User User { get; set; }
    }
}
