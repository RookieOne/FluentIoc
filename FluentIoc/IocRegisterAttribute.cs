using System;

namespace FluentIoc
{
    /// <summary>
    /// Register Attribute used to register a class with an Ioc Container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class IocRegisterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IocRegisterAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public IocRegisterAttribute(Type type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the type to register.
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; set; }
    }
}