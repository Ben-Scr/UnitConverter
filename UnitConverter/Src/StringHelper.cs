namespace BenScr.Converter
{
    public static class StringHelper
    {
        public static string ToSI(ulong size)
        {
            double s = size;

            if (s < 1000.0) return ToString(s, " B");
            if (s < 1e6) return ToString(s / 1e3, " kB");
            if (s < 1e9) return ToString(s / 1e6, " MB");
            if (s < 1e12) return ToString(s / 1e9, " GB");
            return ToString(s / 1e12, " TB");
        }

        public static string ToString(params object[] objs)
        {
            string s = string.Empty;
            foreach (object o in objs) s += o.ToString();
            return s;
        }
    }
}
