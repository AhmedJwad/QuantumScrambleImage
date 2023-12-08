using System.ComponentModel.DataAnnotations;

namespace QuantumScrambleImage.Data.Entities
{
    public class Image
    {
        public int Id { get; set; }


        [Display(Name = "Photo")]
        public string ImageId { get; set; }

        public bool isEncrypted { get; set; }

        [Display(Name = "Photo")]
        public string ImageFullPath => ImageId == string.Empty
            ? $"https://localhost:7147/noimage.png"
            : $"https://localhost:7147/{ImageId}";
    }
}
