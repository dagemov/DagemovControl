namespace DagemovMVC.Data.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        ICollection<Service> Services { get; set; }
    }
}
