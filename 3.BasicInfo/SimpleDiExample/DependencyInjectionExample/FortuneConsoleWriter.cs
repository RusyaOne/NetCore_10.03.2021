using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDiExample.DependencyInjectionExample
{
    public class FortuneConsoleWriter : IFortuneWriter
    {
        public void WriteFortune(string fortune)
        {
            Console.Write(fortune);
        }
    }
}
