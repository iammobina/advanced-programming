using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hashcode
{
    static class Program
    {
        static void Main()
        {
            int a = "96522321".GetHashCode();
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
