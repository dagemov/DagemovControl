using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DagemovMVC.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Social Number")]
        [MaxLength(9)]
        [Required(ErrorMessage ="U must input TaxID number Valid")]
        public int TaxId { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "The block {0} Need maxim at  {1} caracters.")]
        [Required(ErrorMessage = "The block {0} is Required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Names")]
        [MaxLength(50, ErrorMessage = "The block {0} Need maxim at  {1} caracters.")]
        [Required(ErrorMessage = "The block {0} is Required.")]
        public string LastName { get; set; }

        [Display(Name = "Hour value")]
        [MaxLength(50, ErrorMessage ="Is riducle size the hour by hour :)")]
        [Required(ErrorMessage ="Input number value , remeber use . or , to decimals")]
        public double HourValue { get; set; }

        [Display(Name = "Picture")]
        public Guid ImageId { get; set; }

        [Display(Name = "Picture")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7227/images/no-image.jpg"
            : $"https://pathv1.blob.core.windows.net/users/{ImageId}";

        public ICollection<Phone> PhoneNumbers { get; set; }
    }
}
