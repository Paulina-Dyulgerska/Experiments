using System;

namespace NullableReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            string a = null;

            Console.WriteLine(a ?? "as".ToString());

        }
    }
}
