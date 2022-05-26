using Convertly.Core.Models;
using Convertly.Core.Repositories;

namespace Convertly.Core.Services;

public class UnitConverterService
{
    private readonly List<MeasurementUnit> measurementUnits;

    public UnitConverterService()
    {
        var staticDataRepository = new StaticDataRepository(); // this can be injected
        this.measurementUnits = staticDataRepository.MeasurementUnits;
    }

    public IEnumerable<string> MeasurementTypes
    {
        get
        {
            return this.measurementUnits.Select(m => m.Name);
        }
    }

    public IEnumerable<string> MeasurementUnitTypes(string measurementName)
    {
        return this.measurementUnits.FirstOrDefault(m => m.Name == measurementName)
            ?.Types?.Select(t => t.Name);
    }

    public double Convert(double sourceValue, string sourceUnitType, string targetUnitType, string measurementType)
    {
        var measurement = this.measurementUnits.First(u => u.Name == measurementType);

        var sourceRatio = measurement.Types.First(t => t.Name == sourceUnitType).Ratio;
        var targetRatio = measurement.Types.First(t => t.Name == targetUnitType).Ratio;

        return (sourceValue / sourceRatio) * targetRatio;
    }
}