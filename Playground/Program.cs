using BenScr.Converter;


public static class Program
{
    public static void Main()
    {
        var metricConverter = new Convertable<LengthUnit, ulong>(LengthUnit.Millimeter, 2500);
        double meters = metricConverter.To(LengthUnit.Meter);
        Console.WriteLine($"2500 mm = {meters} m");

        var metricConverter2 = new Convertable<LengthUnit, ulong>(LengthUnit.Kilometer, 2);
        double inMm = metricConverter.NormalizedValue();
        Console.WriteLine($"2 km = {inMm} mm");

        var memConverter = new Convertable<DataSizeUnit, ulong>(DataSizeUnit.Megabyte, 5);
        double bytes = memConverter.NormalizedValue();
        Console.WriteLine($"5 MB = {bytes} B");

        var memConverter2 = new Convertable<DataSizeUnit, ulong>(DataSizeUnit.Byte, 5000);
        double kb = memConverter2.To(DataSizeUnit.Kilobyte);
        Console.WriteLine($"5000 B = {kb} KB");

        var len3 = new Convertable<LengthUnit, ulong>(LengthUnit.Millimeter, 1500);
        Console.WriteLine($"1500 mm = {len3.To(LengthUnit.Meter)} m");
    }
}