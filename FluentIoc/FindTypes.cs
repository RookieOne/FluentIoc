using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentIoc
{
    /// <summary>
    /// Finds Types in an Assembly
    /// </summary>
    public class FindTypes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FindTypes"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        private FindTypes(Assembly assembly)
        {
            _assembly = assembly;
        }

        private readonly Assembly _assembly;

        /// <summary>
        /// Creates a FindTypes instance passing in the given assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public static FindTypes InAssembly(Assembly assembly)
        {
            return new FindTypes(assembly);
        }

        /// <summary>
        /// Creates a FindTypes instance passing in the assembly with the type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FindTypes InAssemblyWithType<T>()
        {
            return new FindTypes(Assembly.GetAssembly(typeof (T)));
        }

        /// <summary>
        /// Finds types in the assembly that have the passed in custom attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<TypeWithAttribute<T>> ThatHaveAttribute<T>()
        {
            var result = new List<TypeWithAttribute<T>>();

            Type[] types = _assembly.GetTypes();

            foreach (Type type in types)
            {
                object[] attributes = type.GetCustomAttributes(typeof (T), false);

                for(int i=0; i<attributes.Length; i++)
                {
                    result.Add( new TypeWithAttribute<T>(type, (T) attributes[i]));
                }                    
            }

            return result;
        }

        /// <summary>
        /// Type With Attribute C# non-tuple tuple
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class TypeWithAttribute<T>
        {
            public Type Type { get; set; }
            public T Attribute { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="TypeWithAttribute&lt;T&gt;"/> class.
            /// </summary>
            /// <param name="type">The type.</param>
            /// <param name="attribute">The attribute.</param>
            public TypeWithAttribute(Type type, T attribute)
            {
                Type = type;
                Attribute = attribute;
            }
        }
    }
}