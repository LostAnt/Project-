using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            float a1 = 100;
            a1 = a1 - a1 * 1,005;
            Console.WriteLine(a1);
        }
    }
}
