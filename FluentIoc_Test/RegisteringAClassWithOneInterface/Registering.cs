using System;
using FluentIoc;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentIoc_Test.RegisteringAClassWithOneInterface
{
    [TestFixture]
    public class Registering
    {
        [Test]
        public void ShouldRegisterMyClass()
        {
            var mock = new MockRepository();
            var container = mock.DynamicMock<IIocContainer>();

            Expect.Call(() => container.Register(typeof (IMyClass), typeof (MyClass)))
                .IgnoreArguments()
                .Constraints(Is.Matching<Type>(t => t == typeof(IMyClass)),
                             Is.Matching<Type>(t => t == typeof(MyClass)));

            mock.ReplayAll();

            Register.AssemblyWithType<MyClass>().With(container);

            mock.VerifyAll();
        }
    }
}