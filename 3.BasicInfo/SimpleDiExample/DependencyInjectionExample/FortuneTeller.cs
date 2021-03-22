using System;

namespace SimpleDiExample.DependencyInjectionExample
{
    public class FortuneTeller : IFortuneTeller
    {
        private IFortuneLoader _fortuneLoader;
        private IFortuneWriter _fortuneWriter;

        public FortuneTeller(IFortuneLoader fortuneLoader,
            IFortuneWriter fortuneWriter)
        {
            _fortuneLoader = fortuneLoader;
            _fortuneWriter = fortuneWriter;
        }

        public void TellFortune()
        {
            var fortune = _fortuneLoader.LoadFortune();
            _fortuneWriter.WriteFortune(fortune);
        }
    }
}