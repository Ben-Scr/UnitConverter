using System.Numerics;
namespace BenScr.Converter
{
    public struct Convertable<TEnum, TUnderlying> 
      where TUnderlying : unmanaged, IBinaryInteger<TUnderlying>
      where TEnum : struct, Enum
    {
        public TUnderlying BaseValue { get; private set; }
        public double Value { get; set; }

        public Convertable(TEnum _enum, double value)
        {
            Value = value;
            BaseValue = EnumUtility.GetUnderlyingValue<TEnum, TUnderlying>(_enum);
        }

        public void SetEnum(TEnum _enum)
        {
            BaseValue = EnumUtility.GetUnderlyingValue<TEnum, TUnderlying>(_enum);
            Value = To(_enum);
        }

        public double NormalizedValue() => Convert.ToDouble(BaseValue) * Value;

        public double To(TEnum targetUnit)
        {
            double numerator = Convert.ToDouble(BaseValue) * Value;
            double denominator = Convert.ToDouble(EnumUtility.GetUnderlyingValue<TEnum, TUnderlying>(targetUnit));
            return numerator / denominator;
        }
    }
}