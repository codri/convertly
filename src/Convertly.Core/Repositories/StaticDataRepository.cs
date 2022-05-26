using Convertly.Core.Models;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Convertly.Core.Repositories;

internal class StaticDataRepository
{
    private List<MeasurementUnit> measurementUnits;

    public List<MeasurementUnit> MeasurementUnits
    {
        get
        {
            if (this.measurementUnits is null)
            {
                var assembly = Assembly.GetAssembly(typeof(MeasurementUnit));
                var resourceStream = assembly.GetManifestResourceStream("Convertly.Core.Static.Data.json");

                using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
                {
                    var jsonOptions = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    var json = reader.ReadToEndAsync().GetAwaiter().GetResult();
                    this.measurementUnits = JsonSerializer.Deserialize<StaticData>(json, jsonOptions).Units;
                }
            }

            return this.measurementUnits;
        }
    }
}