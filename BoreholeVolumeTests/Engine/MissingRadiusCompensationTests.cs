using BoreholeVolume.Data;
using BoreholeVolume.Engine;
using NUnit.Framework;
using System.Diagnostics.Metrics;

namespace BoreholeVolumeUnitTests.Engine;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class MissingRadiusCompensationTests
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
    public void Compensate_SetsValue_WhenValueIsNullOrNotANumber(double? radius)
    {
        // Arrange
        DataAtDepth[] data = new DataAtDepth[1];
        data[0] = CreateDataRow(0.0, radius, 0.0, 0.0, 0.0);

        // Act
        MissingRadiusCompensation engine = new MissingRadiusCompensation();
        engine.Compensate(data);

        // Assert
        Assert.IsFalse(double.IsNaN(data[0].RadiusA.Value));
    }

    [Test]
    public void Compensate_SetsValueToAverageAtSameDepth_WhenValueIsMissing()
    {
        // Arrange
        DataAtDepth[] data = new DataAtDepth[1];
        data[0] = CreateDataRow(0.0, null, 0.15, 0.17, 10);

        // Act
        MissingRadiusCompensation engine = new MissingRadiusCompensation();
        engine.Compensate(data);

        // Assert
        Assert.IsTrue(data[0].RadiusA.Value == 0.16);
    }

    [Test]
    public void Compensate_SetsValueToAverageOfPreviousAndFollowingValues_WhenValueIsMissing()
    {
        // Arrange
        DataAtDepth[] data = new DataAtDepth[3];
        data[0] = CreateDataRow(0.0, null, null, null, 10);
        data[1] = CreateDataRow(0.0, 0.15, 0.15, 0.15, 10);
        data[2] = CreateDataRow(0.0, 0.17, 0.17, 0.17, 10);

        // Act
        MissingRadiusCompensation engine = new MissingRadiusCompensation();
        engine.Compensate(data);

        // Assert
        Assert.IsTrue(data[0].RadiusA.Value == 0.16);
    }

}
