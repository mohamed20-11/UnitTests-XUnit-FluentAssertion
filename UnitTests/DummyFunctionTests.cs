using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public static class DummyFunctionTests
    {
        public static void WorldsDummTest()
        {
            try
            {
                int num = 0;
                DummyFunction dummyFunction = new DummyFunction();
                string result = dummyFunction.ReturnZero(num);
                if (result == "Picatchu")
                {

                    Console.WriteLine("Passed!");
                }
                else
                    Console.WriteLine("Not Passed!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
