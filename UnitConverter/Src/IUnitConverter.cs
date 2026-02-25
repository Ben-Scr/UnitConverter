using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenScr.UnitConverter
{
    public interface IUnitConverter
    {
        Type EnumType { get; }
        Type UnderlyingType { get; }

        double Value { get; set; }
        double NormalizedValue();

        void SetUnit(Enum unit);
        double To(Enum targetUnit);
    }
}
