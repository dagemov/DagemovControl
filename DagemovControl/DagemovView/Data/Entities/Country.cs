using System.ComponentModel.DataAnnotations;

namespace DagemovView.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage ="The field {0} Is required")]
        public string Name { get; set; }
        public ICollection<State> States { get; set; }
        public int StatesNumber => States.Count;
    }
}
