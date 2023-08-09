using BoreholeVolume.Data;

namespace BoreholeVolume.Engine;

public class BoreholeVolumeCalculation : IVolumeCalculate
{

    private List<ICompensation> _compensationEngines;

    public BoreholeVolumeCalculation(
        List<ICompensation> compensationEngines)
    {
        _compensationEngines = compensationEngines;
    }

    public double Calculate(DataAtDepth[] data)
    {
        if (data == null || data.Length == 0)
        {
            return 0.0;
        }
        _compensationEngines.ForEach(e => e.Compensate(data));
        double radius = GetAvgRadius(data);
        double height = GetDepth(data);

        return GetVolume(radius, height);
    }

    private double GetAvgRadius(DataAtDepth[] data)
    {
        List<double> radii = new List<double>();
        radii.AddRange(data.Select(r => r.RadiusA.CorrectedValue));
        radii.AddRange(data.Select(r => r.RadiusB.CorrectedValue));
        radii.AddRange(data.Select(r => r.RadiusC.CorrectedValue));
        return radii.Average();
    }

    private double GetDepth(DataAtDepth[] data)
    {
        return data[data.Length - 1].Depth.Value;
    }

    private double GetVolume(double radius, double height)
    {
        double pie = 3.1416;
        return pie * Math.Pow(radius, 2) * height;
    }
    
}
