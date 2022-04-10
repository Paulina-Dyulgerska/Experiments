using System;
using System.Collections.Generic;

namespace Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<int> col = new HashSet<int> { 1, 2, 3, 4 };

            //foreach (var item in col)
            //{
            //    Console.WriteLine(item);
            //}

            //List<int> col2 = new List<int> { 1, 2, 3, 4 };

            //for (int i = 0; i < col2.Count; i++)
            //{
            //    Console.WriteLine(col2[i]);
            //}

            Bang.StaticMethod();
            Console.WriteLine("-");
            var gg = new Bang();
        }
    }

    public sealed class Bang
    {
        static Bang()
        {
            Console.WriteLine("In static constructor");
            //throw new Exception("Bang!");
        }

        public Bang()
        {
            Console.WriteLine("In instance Bang constructor.");
        }

        public static void StaticMethod()
        {
            Console.WriteLine("In StaticMethod()");
        }
    }
}
