using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class DummyFunction
    {
        public string ReturnZero(int num)
        {
            if (num == 0) return "Picatchu";
            else
                return "Squirtle";
        }
    }
}
