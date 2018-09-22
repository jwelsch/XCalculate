using System;

namespace XCalculateLib
{
    public interface IUnit : IEquatable<IUnit>
    {
        string NameSingular
        {
            get;
        }

        string NamePlural
        {
            get;
        }

        string AbreviationSingular
        {
            get;
        }

        string AbreviationPlural
        {
            get;
        }

        string Format(object value, bool abreviate = false);
    }
}
