using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenScr.Converter
{
    public interface IUnitConverter
    {
        Type EnumType { get; }
        Type UnderlyingType { get; }

        double Value { get; set; }
        double NormalizedValue();

        void SetUnit(Enum unit);
        double To(Enum targetUnit);

        public static IUnitConverter CreateConverterRuntime(Type enumType, Enum unit, double value)
        {
            if (!enumType.IsEnum) throw new ArgumentException("enumType has to be Enum");

            Type underlying = Enum.GetUnderlyingType(enumType);

            Type converterType = typeof(UnitConverter<,>).MakeGenericType(enumType, underlying);

            object instance = Activator.CreateInstance(converterType, unit, value)
                ?? throw new InvalidOperationException("Couldn't create converter.");

            return (IUnitConverter)instance;
        }
    }
}
