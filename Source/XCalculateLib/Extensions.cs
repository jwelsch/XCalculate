using System;
using System.Collections;

namespace XCalculateLib
{
    public static class Extensions
    {
        public static object GetDefault(this Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        public static Type GetValueType(this IValue value)
        {
            if (value != null)
            {
                if (value.Value != null)
                {
                    return value.Value.GetType();
                }
            }

            return null;
        }

        public static string GetName(this IValue value)
        {
            if (value != null)
            {
                if (value.Info != null)
                {
                    return value.Info.Name;
                }
            }

            return null;
        }

        public static string GetDescription(this IValue value)
        {
            if (value != null)
            {
                if (value.Info != null)
                {
                    return value.Info.Description;
                }
            }

            return null;
        }

        public static string GetUnitLabel(this IValue value, bool abreviation = true, bool plural = true)
        {
            if (value != null)
            {
                if (value.Info != null)
                {
                    return value.Info.GetUnitLabel(abreviation, plural);
                }
            }

            return null;
        }

        public static string GetName(this IValueInfo valueInfo)
        {
            if (valueInfo != null)
            {
                return valueInfo.Name;
            }

            return null;
        }

        public static string GetDescription(this IValueInfo valueInfo)
        {
            if (valueInfo != null)
            {
                return valueInfo.Description;
            }

            return null;
        }

        public static string GetUnitLabel(this IValueInfo valueInfo, bool abreviation = true, bool plural = true)
        {
            if (valueInfo != null)
            {
                if (valueInfo.Unit != null)
                {
                    if (abreviation)
                    {
                        return plural ? valueInfo.Unit.AbreviationPlural : valueInfo.Unit.AbreviationSingular;
                    }

                    return plural ? valueInfo.Unit.NamePlural : valueInfo.Unit.NameSingular;
                }
            }

            return null;
        }
    }
}
