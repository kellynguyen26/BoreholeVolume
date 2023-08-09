using BoreholeVolume.Data;

namespace BoreholeVolume;

public class DataLoader
{
    // Data must have 5 inputs (Temperature, A, B, C, Depth) and contain only numbers
    public static DataAtDepth[] LoadInput()
    {
        DataAtDepth[] data = new DataAtDepth[7];
        data[0] = CreateDataRow(double.NaN, 0.15, 0.15, 0.17, 10);
        data[1] = CreateDataRow(21, 0.15, 0.16, double.NaN, 20);
        data[2] = CreateDataRow(double.NaN, 0.16, 0.18, 0.15, 30);
        data[3] = CreateDataRow(22, 0.17, double.NaN, double.NaN, 40);
        data[4] = CreateDataRow(22, double.NaN, double.NaN, double.NaN, 50);
        data[5] = CreateDataRow(23, 0.18, 0.18, 0.15, 60);
        data[6] = CreateDataRow(24, 0.15, 0.16, 0.16, 70);

        return data;
    }

    private static DataAtDepth CreateDataRow(params double?[] data)
    {
        return new DataAtDepth()
        {
            Temperature = new DataPoint(data[0]),
            RadiusA = new VariableDataPoint(data[1]),
            RadiusB = new VariableDataPoint(data[2]),
            RadiusC = new VariableDataPoint(data[3]),
            Depth = new DataPoint(data[4])
        };


    }
}
