namespace BoreholeVolume.Data;

public class VariableDataPoint : DataPoint, IVariableDataPoint
{
    public double Correction { get; set; } = 0.0;
    public double CorrectedValue => Value + Correction;

    public VariableDataPoint (double? value) : base (value)
    {
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
