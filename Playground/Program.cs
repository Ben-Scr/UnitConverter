using BenScr.Converter;


public static class Program
{
    public static void Main()
    {
        var metricConverter = new Convertable<Metric, ulong>(Metric.Millimeter, 2500UL);
        double meters = metricConverter.To(Metric.Meter);
        Console.WriteLine($"2500 mm = {meters} m");

        var metricConverter2 = new Convertable<Metric, ulong>(Metric.Kilometer, 2UL);
        double inMm = metricConverter.NormalizedValue();
        Console.WriteLine($"2 km = {inMm} mm");

        var memConverter = new Convertable<Memory, ulong>(Memory.Megabyte, 5UL);
        double bytes = memConverter.NormalizedValue();
        Console.WriteLine($"5 MB = {bytes} B");

        var memConverter2 = new Convertable<Memory, ulong>(Memory.Byte, 5000UL);
        double kb = memConverter2.To(Memory.Kilobyte);
        Console.WriteLine($"5000 B = {kb} KB");

        var len3 = new Convertable<Metric, ulong>(Metric.Millimeter, 1500UL);
        Console.WriteLine($"1500 mm = {len3.To(Metric.Meter)} m");
    }
}