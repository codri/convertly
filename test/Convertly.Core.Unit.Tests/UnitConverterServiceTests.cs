using Convertly.Core.Services;

namespace Convertly.Core.Unit.Tests;

public class UnitConverterServiceTests
{
    private readonly UnitConverterService unitConverterService;

    public UnitConverterServiceTests()
    {
        this.unitConverterService = new UnitConverterService();
    }

    [Theory]
    [InlineData(1.0, 39.3701, "m", "inch")]
    [InlineData(1.0, 0.0254, "inch", "m")]
    [InlineData(1.0, 1000.0, "m", "mm")]
    [InlineData(1.0, 0.001, "mm", "m")]
    public void UnitConverterServiceTests_Length_Values_Are_Handled(double inValue, double expectedOut, string inputUnit, string outputUnit)
    {
        // Arrange
        // Act
        var outValue = this.unitConverterService.Convert(inValue, inputUnit, outputUnit, "Length");

        // Assert
        Assert.Equal(expectedOut, outValue, 3);
    }


    [Theory]
    [InlineData(1.0, 2.20462, "kg", "lbs")]
    [InlineData(1.0, 0.4535, "lbs", "kg")]
    public void UnitConverterServiceTests_Mass_Values_Are_Handled(double inValue, double expectedOut, string inputUnit, string outputUnit)
    {
        // Arrange
        // Act
        var outValue = this.unitConverterService.Convert(inValue, inputUnit, outputUnit, "Mass");

        // Assert
        Assert.Equal(expectedOut, outValue, 3);
    }
}