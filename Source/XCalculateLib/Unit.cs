using System;

namespace XCalculateLib
{
    public class Unit : IUnit
    {
        private readonly static string FormatTemplate = "{0} {1}";

        public string NameSingular
        {
            get;
        }

        public string NamePlural
        {
            get;
        }

        public string AbreviationSingular
        {
            get;
        }

        public string AbreviationPlural
        {
            get;
        }

        public Unit(string nameSingular, string namePlural = null, string abreviationSingular = null, string abreviationPlural = null)
        {
            if (nameSingular == null)
            {
                throw new ArgumentNullException(nameof(nameSingular));
            }

            if (nameSingular.Length == 0)
            {
                throw new ArgumentException("Cannot be empty string.", nameof(nameSingular));
            }

            this.NameSingular = nameSingular;
            this.NamePlural = namePlural;
            this.AbreviationSingular = abreviationSingular;
            this.AbreviationPlural = abreviationPlural;
        }

        public string Format(object value, bool abreviate = false)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            string doFormat(object v, string l) => l == null ? $"{v}" : string.Format(FormatTemplate, v, l);

            if (TypeConverter.ToObject<double>(value) == 1.0)
            {
                if (abreviate)
                {
                    //return this.AbreviationSingular == null ? $"{value}" : string.Format(FormatTemplate, value, this.AbreviationSingular);
                    return doFormat(value, this.AbreviationSingular);
                }

                return doFormat(value, this.NameSingular);
            }

            if (abreviate)
            {
                return doFormat(value, this.AbreviationPlural);
            }

            return doFormat(value, this.NamePlural);
        }

        public bool Equals(IUnit other)
        {
            if (other == null)
            {
                return false;
            }

            return this.NameSingular == other.NameSingular
                && this.NamePlural == other.NamePlural
                && this.AbreviationSingular == other.AbreviationSingular
                && this.AbreviationPlural == other.AbreviationPlural;
        }

        public override string ToString()
        {
            return this.NameSingular;
        }

        public override bool Equals(object obj)
        {
            return this.Equals((IUnit)obj);
        }

        public override int GetHashCode()
        {
            return this.NameSingular.GetHashCode()
                + this.NamePlural.GetHashCode()
                + this.AbreviationSingular.GetHashCode()
                + this.AbreviationPlural.GetHashCode();
        }
    }
}
