namespace BoreholeVolume.Data;

public interface IVariableDataPoint : IDataPoint
{
    double Correction { get; set; }
    double CorrectedValue { get; }
}
