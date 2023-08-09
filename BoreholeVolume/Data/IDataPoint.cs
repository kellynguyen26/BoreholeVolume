namespace BoreholeVolume.Data;

public interface IDataPoint
{
    double Value { get; set; }
    bool IsUndefined { get; }
}
