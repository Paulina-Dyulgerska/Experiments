using System;
using System.Threading.Tasks;

namespace TasksConcurrency
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine($"Start! ({DateTime.UtcNow.ToString("T")})");

            var t1 = DoStuff(1);
            var t2 = DoStuff(2);

            await Task.WhenAll(t1, t2);
            Console.WriteLine($"Finish done! ({DateTime.UtcNow.ToString("T")})");

        }
        static async Task DoStuff(int number)
        {
            // Imagine a Network call here.
            await Task.Delay(2000);
            Console.WriteLine($"{number} done! ({DateTime.UtcNow.ToString("T")})");

            //throw new Exception($"from {number}");
        }
    }
}
