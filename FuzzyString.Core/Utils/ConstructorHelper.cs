using System;
using System.Reflection;

namespace FuzzySearch.Core
{
    static class ConstructorHelper<T> where T : class
    {
        public static T Build()
        {
            return (T)typeof(T).GetConstructor(
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new Type[0],
                new ParameterModifier[0]).Invoke(null);
        }
    }
}