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

        [Display(Name = "Names")]
        [MaxLength(50, ErrorMessage = "The block {0} Need maxim at  {1} caracters.")]
        [Required(ErrorMessage = "The block {0} is Required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Names")]
        [MaxLength(50, ErrorMessage = "The block {0} Need maxim at  {1} caracters.")]
        [Required(ErrorMessage = "The block {0} is Required.")]
        public string LastName { get; set; }

        [Display(Name = "Picture")]
        public Guid ImageId { get; set; }

        [Display(Name = "Picture")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7263/images/noimage.png"
            : $"https://shoping1.blob.core.windows.net/users/{ImageId}";
    }
}
