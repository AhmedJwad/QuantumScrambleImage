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
        StringBuilder ScrambleQuantumCircuit5(StringBuilder quantumState);
        StringBuilder InverseScrambleQuantumCircuit5(StringBuilder quantumState);
        StringBuilder ScrambleQuantumCircuit6(StringBuilder quantumState);
        StringBuilder InverseScrambleQuantumCircuit6(StringBuilder quantumState);
        StringBuilder ScrambleQuantumCircuit7(StringBuilder quantumState);
        StringBuilder InverseScrambleQuantumCircuit7(StringBuilder quantumState);
        StringBuilder ScrambleQuantumCircuit8(StringBuilder quantumState);
        StringBuilder InverseScrambleQuantumCircuit8(StringBuilder quantumState);
        StringBuilder ScrambleQuantumCircuit9(StringBuilder quantumState);
        StringBuilder InverseScrambleQuantumCircuit9(StringBuilder quantumState);
        StringBuilder ScrambleQuantumCircuit10(StringBuilder quantumState);
        StringBuilder InverseScrambleQuantumCircuit10(StringBuilder quantumState);
    }
}
