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

        public string ScrambleId2 { get; set; }

        public double ScrambleEntropy2 { get; set; }      

        public int[] Scramblehistogram2 { get; set; }

        [Display(Name = "Scramble Photo2")]
        public string ScrambleFullPath2 => ScrambleId2 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId2}";
        public string ScrambleId3 { get; set; }

        public double ScrambleEntropy3 { get; set; }

        public int[] Scramblehistogram3 { get; set; }

        [Display(Name = "Scramble Photo2")]
        public string ScrambleFullPath3 => ScrambleId3 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId3}";
        public string ScrambleId4 { get; set; }

        public double ScrambleEntropy4 { get; set; }

        public int[] Scramblehistogram4 { get; set; }

        [Display(Name = "Scramble Photo4")]
        public string ScrambleFullPath4 => ScrambleId4 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId4}";
        public string ScrambleId5 { get; set; }

        public double ScrambleEntropy5 { get; set; }

        public int[] Scramblehistogram5 { get; set; }

        [Display(Name = "Scramble Photo5")]
        public string ScrambleFullPath5 => ScrambleId5 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId5}";
        public string ScrambleId6 { get; set; }

        public double ScrambleEntropy6 { get; set; }

        public int[] Scramblehistogram6 { get; set; }

        [Display(Name = "Scramble Photo6")]
        public string ScrambleFullPath6 => ScrambleId6 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId6}";
        public string ScrambleId7 { get; set; }

        public double ScrambleEntropy7 { get; set; }

        public int[] Scramblehistogram7 { get; set; }

        [Display(Name = "Scramble Photo7")]
        public string ScrambleFullPath7 => ScrambleId7 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId7}";
        public string ScrambleId8 { get; set; }

        public double ScrambleEntropy8 { get; set; }

        public int[] Scramblehistogram8 { get; set; }

        [Display(Name = "Scramble Photo8")]
        public string ScrambleFullPath8 => ScrambleId8 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId8}";
        public string ScrambleId9 { get; set; }

        public double ScrambleEntropy9 { get; set; }

        public int[] Scramblehistogram9 { get; set; }

        [Display(Name = "Scramble Photo9")]
        public string ScrambleFullPath9 => ScrambleId9 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId9}";
        public string ScrambleId10 { get; set; }

        public double ScrambleEntropy10 { get; set; }

        public int[] Scramblehistogram10 { get; set; }

        [Display(Name = "Scramble Photo10")]
        public string ScrambleFullPath10 => ScrambleId10 == string.Empty
           ? $"https://localhost:7147/noimage.png"
           : $"https://localhost:7147/{ScrambleId10}";
    }
}
