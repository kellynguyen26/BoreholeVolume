using BoreholeVolume.Data;

namespace BoreholeVolume.Engine;

public interface IVolumeCalculate
{
    double Calculate(DataAtDepth[] data);
}
