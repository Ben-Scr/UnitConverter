using System.Numerics;

namespace BenScr.Converter
{
    public sealed class UnitConverter<TEnum, TUnderlying> : IUnitConverter
     where TUnderlying : unmanaged, IBinaryInteger<TUnderlying>
     where TEnum : struct, Enum
    {
        public TUnderlying BaseValue { get; private set; }
        public double Value { get; set; }

        public Type EnumType => typeof(TEnum);
        public Type UnderlyingType => typeof(TUnderlying);

        public UnitConverter(TEnum unit, double value)
        {
            Value = value;
            BaseValue = EnumUtility.GetUnderlyingValue<TEnum, TUnderlying>(unit);
        }

        public void SetEnum(TEnum unit)
        {
            BaseValue = EnumUtility.GetUnderlyingValue<TEnum, TUnderlying>(unit);
            Value = To(unit);
        }

        public double NormalizedValue() => Convert.ToDouble(BaseValue) * Value;

        public double To(TEnum targetUnit)
        {
            double numerator = Convert.ToDouble(BaseValue) * Value;
            double denominator = Convert.ToDouble(EnumUtility.GetUnderlyingValue<TEnum, TUnderlying>(targetUnit));
            return numerator / denominator;
        }

        public void SetUnit(Enum unit)
        {
            if (unit is not TEnum typed) throw new ArgumentException("Unit has an invalid Enum-Type", nameof(unit));
            SetEnum(typed);
        }

        public double To(Enum targetUnit)
        {
            if (targetUnit is not TEnum typed) throw new ArgumentException("Unit has an invalid Enum-Type", nameof(targetUnit));
            return To(typed);
        }
    }
}