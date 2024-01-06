using System.ComponentModel.DataAnnotations;

namespace QuantumScrambleImage.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Original Photo")]
        public string ImageId { get; set; }


        [Display(Name = "Scramble Photo")]
        public string ScrambleId { get; set; }

        public double ScrambleEntropy { get; set; }

        public double OriginalEntropy { get; set; }

        public int[] Scramblehistogram { get; set; }

        public int[] originalhistogram { get; set; }

        [Display(Name = "Original Photo")]
        public string ImageFullPath => ImageId == string.Empty
            ? $"https://localhost:7147/noimage.png"
            : $"https://localhost:7147/{ImageId}";

        [Display(Name = "Scramble Photo")]
        public string ScrambleFullPath => ScrambleId == string.Empty
            ? $"https://localhost:7147/noimage.png"
            : $"https://localhost:7147/{ScrambleId}";
    }
}
