using System.Drawing;

namespace QuantumScrambleImage.Helpers
{
    public interface Ientropy
    {
        int[,] GetPixelValues(Bitmap image);
        double CalculateGlobalEntropy(int[,] image);
        double CalculateLocalEntropy(int[,] image, int blockSize);
        int[,] ExtractBlock(int[,] image, int startRow, int startCol, int blockSize);
    }
}
