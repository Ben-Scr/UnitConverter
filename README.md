# Converter
A C# library for converting values

## How to use
```csharp
using BenScr.Converter;
```

- Define an Enum that you want to use for converting
```csharp
public enum LengthUnit : ulong
{
    Millimeter = 1,
    Centimeter = 10,
    Meter = 1000,
    Kilometer = 1000000
}
```

- Create a new UnitConverter<TEnum, TUnderlying>(TEnum enum, double value)
```csharp
var metricConverter = new UnitConverter<LengthUnit, ulong>(LengthUnit.Millimeter, 2500);
double meters = metricConverter.To(LengthUnit.Meter);
Console.WriteLine($"2500 mm = {meters} m"); // Output: "2,5 m"
```
