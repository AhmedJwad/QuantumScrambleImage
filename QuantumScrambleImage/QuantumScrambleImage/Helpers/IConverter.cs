using System.Drawing;
using System.Text;

namespace QuantumScrambleImage.Helpers
{
    public interface IConverter
    {
        string ConvertToQuantumState2(Bitmap bitmap);
        void ApplyCNotGate(StringBuilder quantumState, int controlIndex, int targetIndex);
        void ApplySwapGate(StringBuilder quantumState, int index1, int index2);
        void ApplyToffoliGate(StringBuilder quantumState, int controlIndex1, int controlIndex2, int targetIndex);
        void ApplyNotGate(StringBuilder quantumState, int targetIndex);
        void scrambleimage(Bitmap bmp);
        StringBuilder ScrambleQuantumCircuit1(StringBuilder quantumState);
        StringBuilder ReverseScrambleQuantumCircuit1(StringBuilder quantumState);       
        StringBuilder ScrambleQuantumCircuit2(StringBuilder quantumState);
        StringBuilder ReverseScrambleQuantumCircuit2(StringBuilder quantumState);       
        StringBuilder ScrambleQuantumCircuit3(StringBuilder quantumState);
        StringBuilder InverseScrambleQuantumCircuit3(StringBuilder quantumState);
        StringBuilder ScrambleQuantumCircuit4(StringBuilder quantumState);
        StringBuilder InverseScrambleQuantumCircuit4(StringBuilder quantumState);

    }
}
