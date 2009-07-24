using FluentIoc;

namespace FluentIoc_Test.RegisteringAClassWithOneInterface
{
    [IocRegister(typeof (IMyClass))]
    public class MyClass : IMyClass
    {
    }
}