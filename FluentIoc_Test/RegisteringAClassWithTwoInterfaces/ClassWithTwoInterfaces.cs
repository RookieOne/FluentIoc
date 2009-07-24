using FluentIoc;

namespace FluentIoc_Test.RegisteringAClassWithTwoInterfaces
{
    [IocRegister(typeof(IInterface1))]
    [IocRegister(typeof(IInterface2))]
    public class ClassWithTwoInterfaces : IInterface1, IInterface2
    {
    }
}