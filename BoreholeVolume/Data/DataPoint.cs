namespace BoreholeVolume.Data;

public class DataPoint : IDataPoint
{
    public double Value { get; set; }
    public bool IsUndefined { get; set; }

    public DataPoint (double? value)
    {
        Value = value ?? 0.0;

        IsUndefined = (value == null || double.IsNaN(value.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
