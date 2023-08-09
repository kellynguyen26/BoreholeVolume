using System.Diagnostics;
using BoreholeVolume.Data;

namespace BoreholeVolume.Engine;

public class MissingTemperatureCompensation : ICompensation
{
    // If temperature reading is not available, the latest valid reading must be used
    public void Compensate(DataAtDepth[] data)
    {
        double lastT = 20.0;
        for (int rowIndex = 0; rowIndex < data.Length; rowIndex++)
        {
            if (data[rowIndex].Temperature.IsUndefined)
            {
                data[rowIndex].Temperature.Value = lastT;
                Debug.WriteLine($"Temperature at height {data[rowIndex].Depth} is {lastT}");
            }
            else
            {
                lastT = data[rowIndex].Temperature.Value;
            }
        }
    }
}
