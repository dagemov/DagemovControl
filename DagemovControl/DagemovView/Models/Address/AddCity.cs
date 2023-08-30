using System.ComponentModel.DataAnnotations;

namespace DagemovView.Models.Address
{
    public class AddCity
    {
        public int Id { get; set; }
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        public int StateId { get; set; }
    }
}
