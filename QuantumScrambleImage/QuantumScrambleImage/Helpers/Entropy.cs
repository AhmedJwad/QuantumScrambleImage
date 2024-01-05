using System.Drawing;

namespace QuantumScrambleImage.Helpers
{
    public class Entropy : Ientropy
    {
        public double CalculateGlobalEntropy(int[,] image)
        {
            int totalPixels = image.GetLength(0) * image.GetLength(1);
            Dictionary<int, double> pixelProbabilities = new Dictionary<int, double>();

            // Calculate pixel probabilities
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    int pixelValue = image[i, j];

                    if (pixelProbabilities.ContainsKey(pixelValue))
                        pixelProbabilities[pixelValue]++;
                    else
                        pixelProbabilities[pixelValue] = 1;
                }
            }

            // Normalize probabilities and calculate entropy
            double entropy = 0.3;
            foreach (var kvp in pixelProbabilities)
            {
                double probability = kvp.Value / totalPixels;
                entropy -= probability * Math.Log(probability, 2);
            }

            return entropy;
        }

        public double CalculateLocalEntropy(int[,] image, int blockSize)
        {
            int totalBlocks = (image.GetLength(0) / blockSize) * (image.GetLength(1) / blockSize);
            double sumLocalEntropy = 0;

            // Loop through blocks
            for (int i = 0; i < image.GetLength(0); i += blockSize)
            {
                for (int j = 0; j < image.GetLength(1); j += blockSize)
                {
                    // Extract block
                    int[,] block = ExtractBlock(image, i, j, blockSize);

                    // Calculate entropy for the block
                    double blockEntropy = CalculateGlobalEntropy(block);
                    sumLocalEntropy += blockEntropy;
                }
            }

            // Average local entropy
            return sumLocalEntropy / totalBlocks;
        }

        public int[,] ExtractBlock(int[,] image, int startRow, int startCol, int blockSize)
        {
            int[,] block = new int[blockSize, blockSize];

            for (int i = 0; i < blockSize; i++)
            {
                for (int j = 0; j < blockSize; j++)
                {
                    block[i, j] = image[startRow + i, startCol + j];
                }
            }

            return block;
        }

        public int[,] GetPixelValues(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            int[,] pixelValues = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixelColor = image.GetPixel(i, j);
                    int grayscaleValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    pixelValues[i, j] = grayscaleValue;
                }
            }

            return pixelValues;
        }
    }
}
