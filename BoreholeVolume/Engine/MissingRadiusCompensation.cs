using BoreholeVolume.Data;

namespace BoreholeVolume.Engine;

public class MissingRadiusCompensation : ICompensation
{
    // If temperature reading is not available, the latest valid reading must be used
    public void Compensate(DataAtDepth[] data)
    {
        // averaging (available) previous and following readings 
        double aRadiusAvgValue = GetAvgReading(data.Select(r => r.RadiusA).ToArray()) ?? 0.0;
        double bRadiusAvgValue = GetAvgReading(data.Select(r => r.RadiusB).ToArray()) ?? 0.0;
        double cRadiusAvgValue = GetAvgReading(data.Select(r => r.RadiusC).ToArray()) ?? 0.0;

        for (int i = 0; i < data.Length; i++)
        {
            // averaging (available) readings at same depth
            double? rowAvgValue = GetAvgReading(data[i].RadiusA, data[i].RadiusB, data[i].RadiusC);
            if (data[i].RadiusA.IsUndefined)
            {
                data[i].RadiusA.Value = rowAvgValue.HasValue ? rowAvgValue.Value : aRadiusAvgValue;
            }
            if (data[i].RadiusB.IsUndefined)
            {
                data[i].RadiusB.Value = rowAvgValue.HasValue ? rowAvgValue.Value : bRadiusAvgValue;
            }
            if (data[i].RadiusC.IsUndefined)
            {
                data[i].RadiusC.Value = rowAvgValue.HasValue ? rowAvgValue.Value : cRadiusAvgValue;
            }
        }
    }

    private double? GetAvgReading(params IDataPoint[] data)
    {
        List<double> temp = new List<double>();
        for (int i = 0; i < data.Length; i++)
        {
            // only average available data
            if (!data[i].IsUndefined)
            {
                temp.Add(data[i].Value);
            }
        }
        return (temp.Count == 0) ? null : temp.Average();
    }
}
