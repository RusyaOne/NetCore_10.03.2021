using SimpleDiExample.DependencyInjectionExample;
using System;
using Unity;
using Unity.Injection;

namespace SimpleDiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IFortuneLoader, MyFortuneLoader>(new InjectionConstructor("My string here"));
            container.RegisterType<IFortuneWriter, FortuneConsoleWriter>();
            container.RegisterType<IFortuneTeller, FortuneTeller>();

            var fortuneTeller = container.Resolve<IFortuneTeller>();

            fortuneTeller.TellFortune();

            //var fortuneTeller = new FortuneTeller(new MyFortuneLoader("You will live now"));
            //fortuneTeller.TellFortune();

            Console.Read();
        }
    }
}