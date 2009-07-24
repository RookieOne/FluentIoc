using System;

namespace FluentIoc
{
    /// <summary>
    /// Interface for Ioc Container
    /// </summary>
    public interface IIocContainer
    {
        /// <summary>
        /// Registers the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="type2">The type2.</param>
        void Register(Type type, Type type2);
    }
}