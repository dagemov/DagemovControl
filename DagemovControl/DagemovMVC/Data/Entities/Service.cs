using System.ComponentModel.DataAnnotations;

namespace DagemovMVC.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }


        public ICollection<Adress> Adress { get; set; }
        public Contrat Contrat { get; set; }
        public Schedule Schedule { get; set; }
 

        [Display(Name = "Picture")]
        public Guid ImageId { get; set; }

        [Display(Name = "Picture")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7227/images/no-image.jpg"
            : $"https://pathv1.blob.core.windows.net/users/{ImageId}";

    }
}
