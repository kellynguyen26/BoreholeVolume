using BoreholeVolume.Data;

namespace BoreholeVolume.Engine;

public interface ICompensation
{
    void Compensate(DataAtDepth[] data);
}
