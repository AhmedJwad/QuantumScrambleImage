using System.Drawing;
using System.Text;

namespace QuantumScrambleImage.Helpers
{
    public class Converter : IConverter
    {
        public void ApplyCNotGate(StringBuilder quantumState, int controlIndex, int targetIndex)
        {
            if (quantumState[controlIndex] == '1')
            {
                quantumState[targetIndex] = (quantumState[targetIndex] == '0') ? '1' : '0';
            }
        }

        public void ApplySwapGate(StringBuilder quantumState, int index1, int index2)
        {
            char temp = quantumState[index1];
            quantumState[index1] = quantumState[index2];
            quantumState[index2] = temp;
        }
        public void ApplyToffoliGate(StringBuilder quantumState, int controlIndex1, int controlIndex2, int targetIndex)
        {
            if (quantumState[controlIndex1] == '1' && quantumState[controlIndex2] == '1')
            {
                quantumState[targetIndex] = (quantumState[targetIndex] == '0') ? '1' : '0';
            }
        }
        public  string ConvertToQuantumState2(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            StringBuilder quantumState = new StringBuilder();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(j, i);

                    string binaryPixel = Convert.ToString(pixelColor.R, 2).PadLeft(8, '0') +
                                        Convert.ToString(pixelColor.G, 2).PadLeft(8, '0') +
                                        Convert.ToString(pixelColor.B, 2).PadLeft(8, '0');

                    quantumState.Append(binaryPixel);
                }
            }

            // Apply quantum gates
          //  StringBuilder processedQuantumState = ScrambleQuantumCircuit1(quantumState);

            return quantumState.ToString();
        }

        public StringBuilder ScrambleQuantumCircuit1(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());

            for (int k = 0; k < quantumState.Length; k += 8)
            {
                // Apply CNot gate between position[0] and position[2]
                ApplyCNotGate(processedQuantumState, k, k + 2);

                // Apply Swap gate between position[1] and position[2]
                ApplySwapGate(processedQuantumState, k + 1, k + 2);

                // Apply CNot gate between position[4] and position[2]
                ApplyCNotGate(processedQuantumState, k + 4, k + 2);

                // Apply CNot gate between position[3] and position[1]
                ApplyCNotGate(processedQuantumState, k + 3, k + 1);

                // Apply Swap gate between position[3] and position[4]
                ApplySwapGate(processedQuantumState, k + 3, k + 4);

                // Apply CNot gate between position[7] and position[6]
                ApplyCNotGate(processedQuantumState, k + 7, k + 6);

                // Apply CNot gate between position[7] and position[5]
                ApplyCNotGate(processedQuantumState, k + 7, k + 5);
            }

            return processedQuantumState;
        }
        public StringBuilder ReverseScrambleQuantumCircuit1(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());

            for (int k = quantumState.Length - 8; k >= 0; k -= 8)
            {
                // Apply CNot gate between position[7] and position[5]
                ApplyCNotGate(processedQuantumState, k + 7, k + 5);

                // Apply CNot gate between position[7] and position[6]
                ApplyCNotGate(processedQuantumState, k + 7, k + 6);

                // Apply Swap gate between position[3] and position[4]
                ApplySwapGate(processedQuantumState, k + 3, k + 4);

                // Apply CNot gate between position[3] and position[1]
                ApplyCNotGate(processedQuantumState, k + 3, k + 1);

                // Apply CNot gate between position[4] and position[2]
                ApplyCNotGate(processedQuantumState, k + 4, k + 2);

                // Apply Swap gate between position[1] and position[2]
                ApplySwapGate(processedQuantumState, k + 1, k + 2);

                // Apply CNot gate between position[0] and position[2]
                ApplyCNotGate(processedQuantumState, k, k + 2);
            }

            return processedQuantumState;
        }
        public void scrambleimage(Bitmap bmp)
        {
            double x = 0.99;
            int ih = bmp.Height;
            int iw = bmp.Width;
            System.Drawing.Color c = new System.Drawing.Color();
            for (int i = 0; i < 100; i++)
            {
                x = 4 * x * (1 - x);
            }
            for (int j = 0; j < ih; j++)
            {
                for (int i = 0; i < iw; i++)
                {
                    c = bmp.GetPixel(i, j);
                    int chaos = 0, g;
                    string k;
                    for (int w = 0; w < 8; w++)
                    {
                        x = 4 * x * (1 - x);
                        if (x >= 0.5) g = 1;
                        else g = 0;
                        chaos = ((chaos << 1) | g);
                    }
                    //c = 
                    bmp.SetPixel(i, j, System.Drawing.Color.FromArgb(c.R ^ (int)chaos,
                                                     c.G ^ (int)chaos,
                                                     c.B ^ (int)chaos));
                }
            }
        }

       

        public void ApplyNotGate(StringBuilder quantumState, int targetIndex)
        {
            quantumState[targetIndex] = (quantumState[targetIndex] == '0') ? '1' : '0';
        }

        public StringBuilder ScrambleQuantumCircuit2(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());

            for (int k = 0; k < quantumState.Length; k += 8)
            {
                // Apply CNot gate between position[0] and position[1]
                ApplyCNotGate(processedQuantumState, k, k + 1);

                // Apply CNot gate between position[1] and position[2]
                ApplyCNotGate(processedQuantumState, k + 1, k + 2);

                // Apply CNot gate between position[3] and position[4]
                ApplyCNotGate(processedQuantumState, k + 3, k + 4);

                // Apply Swap gate between position[2] and position[3]
                ApplySwapGate(processedQuantumState, k + 2, k + 3);

                // Apply CNot gate between position[3] and position[4]
                ApplyCNotGate(processedQuantumState, k + 3, k + 4);

                // Apply Swap gate between position[2] and position[1]
                ApplySwapGate(processedQuantumState, k + 2, k + 1);

                // Apply Not gate at position[5]
                ApplyNotGate(processedQuantumState, k + 5);

                // Apply Swap gate between position[6] and position[7]
                ApplySwapGate(processedQuantumState, k + 6, k + 7);
            }

            return processedQuantumState;
        }

        public StringBuilder ReverseScrambleQuantumCircuit2(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());

            for (int k = quantumState.Length - 8; k >= 0; k -= 8)
            {
                // Apply Swap gate between position[6] and position[7]
                ApplySwapGate(processedQuantumState, k + 6, k + 7);

                // Apply Not gate at position[5]
                ApplyNotGate(processedQuantumState, k + 5);

                // Apply Swap gate between position[2] and position[1]
                ApplySwapGate(processedQuantumState, k + 2, k + 1);

                // Apply CNot gate between position[3] and position[4]
                ApplyCNotGate(processedQuantumState, k + 3, k + 4);

                // Apply Swap gate between position[2] and position[3]
                ApplySwapGate(processedQuantumState, k + 2, k + 3);

                // Apply CNot gate between position[1] and position[2]
                ApplyCNotGate(processedQuantumState, k + 1, k + 2);

                // Apply CNot gate between position[0] and position[1]
                ApplyCNotGate(processedQuantumState, k, k + 1);
            }

            return processedQuantumState;
        }
        public StringBuilder ScrambleQuantumCircuit3(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());
            for (int k = quantumState.Length - 8; k >= 0; k -= 8)
            {

                // Apply CNOT gate between position[1] and position[0]
                ApplyCNotGate(processedQuantumState, 1, 0);

                // Apply Toffoli gate between position[2], position[3], and position[7]
                ApplyToffoliGate(processedQuantumState, 2, 3, 7);

                // Apply CNOT gate between position[1] and position[2]
                ApplyCNotGate(processedQuantumState, 1, 2);

                // Apply Swap gate between position[2] and position[3]
                ApplySwapGate(processedQuantumState, 2, 3);

                // Apply Swap gate between position[4] and position[5]
                ApplySwapGate(processedQuantumState, 4, 5);

                // Apply Toffoli gate between position[7], position[6], and position[5]
                ApplyToffoliGate(processedQuantumState, 7, 6, 5);

                // Apply CNOT gate between position[3] and position[0]
                ApplyCNotGate(processedQuantumState, 3, 0);
            }

            return processedQuantumState;
        }
        public StringBuilder InverseScrambleQuantumCircuit3(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());
            for (int k = quantumState.Length - 8; k >= 0; k -= 8)
            {

                // Apply CNOT gate between position[3] and position[0] (inverse of CNOT between position[3] and position[0])
                ApplyCNotGate(processedQuantumState, 3, 0);

                // Apply Toffoli gate between position[7], position[6], and position[5] (inverse of Toffoli between position[7], position[6], and position[5])
                ApplyToffoliGate(processedQuantumState, 7, 6, 5);

                // Apply Swap gate between position[4] and position[5] (inverse of Swap between position[4] and position[5])
                ApplySwapGate(processedQuantumState, 4, 5);

                // Apply Swap gate between position[2] and position[3] (inverse of Swap between position[2] and position[3])
                ApplySwapGate(processedQuantumState, 2, 3);

                // Apply CNOT gate between position[1] and position[2] (inverse of CNOT between position[1] and position[2])
                ApplyCNotGate(processedQuantumState, 1, 2);

                // Apply Toffoli gate between position[2], position[3], and position[7] (inverse of Toffoli between position[2], position[3], and position[7])
                ApplyToffoliGate(processedQuantumState, 2, 3, 7);

                // Apply CNOT gate between position[1] and position[0] (inverse of CNOT between position[1] and position[0])
                ApplyCNotGate(processedQuantumState, 1, 0);
            }

            return processedQuantumState;
        }
        public StringBuilder ScrambleQuantumCircuit4(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());
            for (int k = quantumState.Length - 8; k >= 0; k -= 8)
            {
                // Apply Swap gate between position[1] and position[4]
                ApplySwapGate(processedQuantumState, 1, 4);

                // Apply CNOT gate between position[7] and position[0]
                ApplyCNotGate(processedQuantumState, 7, 0);

                // Apply CNOT gate between position[2] and position[4]
                ApplyCNotGate(processedQuantumState, 2, 4);

                // Apply CNOT gate between position[5] and position[3]
                ApplyCNotGate(processedQuantumState, 5, 3);

                // Apply Toffoli gate between position[1], position[2], and position[6]
                ApplyToffoliGate(processedQuantumState, 1, 2, 6);

                // Apply Toffoli gate between position[3], position[4], and position[5]
                ApplyToffoliGate(processedQuantumState, 3, 4, 5);

                // Apply Not gate at position[7]
                ApplyNotGate(processedQuantumState, 7);
            }

            return processedQuantumState;
        }
        public StringBuilder InverseScrambleQuantumCircuit4(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());

            for (int k = 0; k < quantumState.Length; k += 8)
            {
                // Apply Not gate at position[7] (inverse of Not gate at position[7])
                ApplyNotGate(processedQuantumState, k + 7);

                // Apply Toffoli gate between position[3], position[4], and position[5] (inverse of Toffoli between position[3], position[4], and position[5])
                ApplyToffoliGate(processedQuantumState, k + 3, k + 4, k + 5);

                // Apply Toffoli gate between position[1], position[2], and position[6] (inverse of Toffoli between position[1], position[2], and position[6])
                ApplyToffoliGate(processedQuantumState, k + 1, k + 2, k + 6);

                // Apply CNOT gate between position[5] and position[3] (inverse of CNOT between position[5] and position[3])
                ApplyCNotGate(processedQuantumState, k + 5, k + 3);

                // Apply CNOT gate between position[2] and position[4] (inverse of CNOT between position[2] and position[4])
                ApplyCNotGate(processedQuantumState, k + 2, k + 4);

                // Apply CNOT gate between position[7] and position[0] (inverse of CNOT between position[7] and position[0])
                ApplyCNotGate(processedQuantumState, k + 7, k);

                // Apply Swap gate between position[1] and position[4] (inverse of Swap between position[1] and position[4])
                ApplySwapGate(processedQuantumState, k + 1, k + 4);
            }

            return processedQuantumState;
        }




    }
}
