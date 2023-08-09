using BoreholeVolume.Data;

namespace BoreholeVolume.Engine;

public enum PacketEnum { A, B, C };
public class RadiusCompensation : ICompensation
{
    Dictionary<PacketEnum, double> packetConstants = new Dictionary<PacketEnum, double>
    {
        { PacketEnum.A, 0.0495 },
        { PacketEnum.B, 0.0486 },
        { PacketEnum.C, 0.044 }
    };

    public void Compensate(DataAtDepth[] data)
    {
        double prevT = 20; // assume temperature starts at 20 C degree
        for (int i = 0; i < data.Length; i++)
        {
            double deltaT = data[i].Temperature.Value - prevT;

            data[i].RadiusA.Correction = data[i].RadiusA.Value * packetConstants[PacketEnum.A] * deltaT;
            data[i].RadiusB.Correction = data[i].RadiusB.Value * packetConstants[PacketEnum.B] * deltaT;
            data[i].RadiusC.Correction = data[i].RadiusC.Value * packetConstants[PacketEnum.C] * deltaT;

            prevT = data[i].Temperature.Value;
        }
    }
}
