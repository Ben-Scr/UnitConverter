using System.Numerics;

namespace BenScr.Converter
{
    public static class EnumUtility
    {
        public static string[] GetNames<TEnum>()
        {
            return Enum.GetNames(typeof(TEnum));
        }

        // Info: Returns the underlying value of an enum
        public static TUnderlying GetUnderlyingValue<TEnum, TUnderlying>(TEnum _enum)
            where TEnum : struct, Enum
            where TUnderlying : unmanaged, IBinaryInteger<TUnderlying>
         => (TUnderlying)Convert.ChangeType(_enum, typeof(TUnderlying));


        public static Type GetUnderlyingType(Type type)
            => Enum.GetUnderlyingType(type);


        public static TUnderlying GetUnderlyingValueAtI<TEnum, TUnderlying>(int index)
            where TEnum : struct, Enum
            where TUnderlying : unmanaged, IBinaryInteger<TUnderlying>
        {
            var values = Enum.GetValues<TEnum>();
            return GetUnderlyingValue<TEnum, TUnderlying>(values[index]);
        }
        public static TEnum GetEnumAtI<TEnum>(int index)
        where TEnum : struct, Enum
        {
            var values = Enum.GetValues<TEnum>();
            return values[index];
        }
    }

}