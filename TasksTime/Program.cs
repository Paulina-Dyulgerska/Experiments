using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksTime
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine($"Start! ({DateTime.UtcNow.ToString("T")})");

            var t1 = DoStuff();
            var t2 = DoStuff();
            await Task.WhenAll(t1, t2);

            Console.WriteLine($"Finish done! ({DateTime.UtcNow.ToString("T")})");
        }

        static async Task DoStuff()
        {
            Thread.Sleep(2000);
            Console.WriteLine($" Thread.Sleep(1500); ({DateTime.UtcNow.ToString("T")})");

            await Task.Delay(5000);
        }
    }
}
