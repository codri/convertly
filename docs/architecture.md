# Value Conversion App

## Domain Constraints

There are a wide range of units that can be converted among themeselves.

From the top of my head:

Fundamental units:
    - Length
    - Mass
    - Time
    - Area
    - Volume
    - Pressure
    - Temperature
Artificial
    - Currency
    - Information size(bytes, Gbytes and so on)

## Project Structure

```
/src
    /Convertly.Core -- core business logic, can be reused in a mobile app, server app, IoT
        /Services -- classical n-tier app structure, with 3 layers of abstraction (WPF ViewModel -> Service -> Repository)
        /Repositories
        /Models
    /Convertly.Desktop -- a desktop application that presents the business logic
/test
build.ps1 -- building and running the tests from the CLI
```

## Options

### Use C# type system to model the above conversions

The above functionality can be expressed as a series of classes constrained by interfaces.
We can also overload the cast operators, which will have a similar behaviour.

Ex:

```c#
interface IConvertUnits<In, Out>
{
    double ConvertUnits(double value, In source, Out target);
}

class Inch : IConvertUnits<Inch, Meter>
{
    public double ConvertUnits(double value, Inch source, Meter target)
    {
        return value * 0.0254;
    }
}

class Meter {}

```

### Data Driven Approach - Implemented Approach

The main observation for this approach is that for each Unit Type there is usually a base unit in which
other units are defined.

Ex: The imperial unit system(inch, ft and so on) have been defined in terms of meters for
quite a while.

If we were to store the units in a database(Static\Data.json), where we store the values relative to main
measurement unit. We can convert to the main unit, hten convert into the target.

This approach will save us a lot of code, since we can store the Data into a configuration file.
If we were optimising for developement time, we could detect the Data file change and reload it,
thus saving us the need to re-compile the project while adding new files.

Of course WPF has built-in support for static resources(and so Win32) and we can use that,
but I prefer JSON as a more readable alternative.

The disadvantage of storing so much configuration outside C# is that the developers don't get IDE suport,
and not help from the type system. This is a tradeoff I'm willing to make for this example.