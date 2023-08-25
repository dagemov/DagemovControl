namespace DagemovView.Data.Entities
{
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public City City { get; set; }
    }
}
