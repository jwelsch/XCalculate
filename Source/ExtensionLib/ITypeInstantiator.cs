using System;

namespace ExtensionLib
{
    internal interface ITypeInstantiator
    {
        object Create(Type type);

        T Create<T>();
    }
}
