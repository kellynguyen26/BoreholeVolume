using BoreholeVolume.Data;
using BoreholeVolume.Engine;
using Moq;
using NUnit.Framework;

namespace BoreholeVolumeUnitTests.Engine;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BoreholeVolumeCalculationTests
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
    public void Calculate_ReturnsZeroVolume_WhenThereIsNoData()
    {
        // Arrange
        DataAtDepth[] data = null!;

        List<ICompensation> compensationEngines = new List<ICompensation>();
        var calculation = new BoreholeVolumeCalculation(compensationEngines);

        // Act
        var volume = calculation.Calculate(data);

        // Assert
        Assert.IsTrue(volume == 0.0);
    }

    [Test]
    public void Calculate_ReturnsVolume_WhenThereIsNoCompensationEngine()
    {
        // Arrange
        DataAtDepth[] data = new DataAtDepth[1];
        data[0] = CreateDataRow(0.0, .95, .95, 1.10, 10);

        List<ICompensation> compensationEngines = new List<ICompensation>(); 
        var calculation = new BoreholeVolumeCalculation(compensationEngines);

        // Act
        var volume = calculation.Calculate(data);

        // Assert
        Assert.IsTrue(volume == 31.416);
    }

    [Test]
    public void Calculate_ReturnsVolume_WhenThereAreCompensationEngines()
    {
        // Arrange
        DataAtDepth[] data = new DataAtDepth[1];
        data[0] = CreateDataRow(null, null, .95, 1.10, 10);

        Mock<ICompensation> mockTempEngine = new Mock<ICompensation>();
        mockTempEngine.Setup(e => e.Compensate(data)).Callback(() => {
            data[0].Temperature.Value = 10;
        });

        Mock<ICompensation> mockRadiusEngine = new Mock<ICompensation>();
        mockRadiusEngine.Setup(e => e.Compensate(data)).Callback(() => {
            data[0].RadiusA.Value = .95;
        });

        var calculation = new BoreholeVolumeCalculation(
            new List<ICompensation>()
        {
            mockTempEngine.Object,
            mockRadiusEngine.Object
        });

        // Act
        var volume = calculation.Calculate(data);

        // Assert
        Assert.IsTrue(volume == 31.416);
        mockTempEngine.Verify(e => e.Compensate(data), Times.Once);
        mockRadiusEngine.Verify(e => e.Compensate(data), Times.Once);
    }
}
