using DagemovView.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DagemovView.Models.Address
{
    public class AddState 
    {
        public int Id { get; set; }
        [Display(Name = "State")]
        [MaxLength(50, ErrorMessage = "the fiel {0} need max {1} chars")]
        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
