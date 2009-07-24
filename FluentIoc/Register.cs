using System.Reflection;

namespace FluentIoc
{
    /// <summary>
    /// Fluent facade for registering an assembly with an Ioc Container
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Register"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        private Register(Assembly assembly)
        {
            _assembly = assembly;
        }

        private Assembly _assembly;

        /// <summary>
        /// Creates a Register fluent config from the assembly with type of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Register AssemblyWithType<T>()
        {
            return new Register(Assembly.GetAssembly(typeof (T)));
        }

        /// <summary>
        /// Registers the assembly with the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public void With(IIocContainer container)
        {
            if (_assembly == null)
                return;

            var registrations = FindTypes.InAssembly(_assembly).ThatHaveAttribute<IocRegisterAttribute>();

            foreach (var registration in registrations)
                container.Register(registration.Attribute.Type, registration.Type);
        }
    }
}