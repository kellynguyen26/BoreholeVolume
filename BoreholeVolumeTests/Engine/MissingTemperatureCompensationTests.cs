using BoreholeVolume.Data;
using BoreholeVolume.Engine;
using NUnit.Framework;

namespace BoreholeVolumeUnitTests.Engine;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class MissingTemperatureCompensationTests
{
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

    [Test]
    [TestCase(null)]
    [TestCase(double.NaN)]
    public void Compensate_SetsValueTo20_WhenValueIsUndefinedAndThereIsNoPrevData(double? temperature)
    {
        // Arrange
        DataAtDepth[] data = new DataAtDepth[1];
        data[0] = CreateDataRow(temperature, 0.0, 0.0, 0.0, 0.0);

        // Act
        MissingTemperatureCompensation engine = new MissingTemperatureCompensation();
        engine.Compensate(data);

        // Assert
        Assert.IsFalse(double.IsNaN(data[0].Temperature.Value));
        Assert.IsTrue(data[0].Temperature.Value == 20);
    }

    [Test]
    [TestCase(null)]
    [TestCase(double.NaN)]
    public void Compensate_SetsValueToPrevValue_WhenValueIsUndefinedAndThereIsPrevData(double? temperature)
    {
        // Arrange
        DataAtDepth[] data = new DataAtDepth[2];
        data[0] = CreateDataRow(21, 0.0, 0.0, 0.0, 0.0);
        data[1] = CreateDataRow(temperature, 0.0, 0.0, 0.0, 0.0);

        // Act
        MissingTemperatureCompensation engine = new MissingTemperatureCompensation();
        engine.Compensate(data);

        // Assert
        Assert.IsTrue(data[1].Temperature.Value == 21);
    }
}
