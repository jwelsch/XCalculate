using System;

namespace ExtensionLib
{
    internal class ActivatorTypeInstantiator : ITypeInstantiator
    {
        public object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public T Create<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
