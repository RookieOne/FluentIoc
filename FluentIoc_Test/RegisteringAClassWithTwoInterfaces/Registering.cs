using System;
using FluentIoc;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentIoc_Test.RegisteringAClassWithTwoInterfaces
{
    [TestFixture]
    public class Registering
    {
        [Test]
        public void ShouldRegisterClassWithBothInterfaces()
        {
            var mock = new MockRepository();
            var container = mock.DynamicMock<IIocContainer>();

            Expect.Call(() => container.Register(typeof (IInterface1), typeof (ClassWithTwoInterfaces)))
                .IgnoreArguments()
                .Constraints(Is.Matching<Type>(t => t == typeof (IInterface1)),
                             Is.Matching<Type>(t => t == typeof (ClassWithTwoInterfaces)));

            Expect.Call(() => container.Register(typeof (IInterface2), typeof (ClassWithTwoInterfaces)))
                .IgnoreArguments()
                .Constraints(Is.Matching<Type>(t => t == typeof (IInterface2)),
                             Is.Matching<Type>(t => t == typeof (ClassWithTwoInterfaces)));

            mock.ReplayAll();

            Register.AssemblyWithType<ClassWithTwoInterfaces>().With(container);

            mock.VerifyAll();
        }
    }
}