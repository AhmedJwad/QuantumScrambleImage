using System.ComponentModel.DataAnnotations;

namespace QuantumScrambleImage.Models
{
    public class AddImageViewModel
    {
        [Display(Name = "Photo")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public IFormFile ImageFile { get; set; }
    }
}
