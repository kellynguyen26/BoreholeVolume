namespace BoreholeVolume.Data;

public class DataAtDepth 
{
    public IDataPoint Depth { get; set; } = null!;
    public IDataPoint Temperature { get; set; } = null!;
    public IVariableDataPoint RadiusA { get; set; } = null!;
    public IVariableDataPoint RadiusB { get; set; } = null!;
    public IVariableDataPoint RadiusC { get; set; } = null!;

}
