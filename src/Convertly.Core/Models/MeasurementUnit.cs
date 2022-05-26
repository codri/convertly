namespace Convertly.Core.Models;

public class MeasurementUnit
{
    public string Name { get; set; }

    public string BaseUnit { get; set;  }

    public List<MeasurementUnitType> Types { get; set; }
}