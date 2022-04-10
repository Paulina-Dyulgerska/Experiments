using System;
using System.Threading.Tasks;

namespace TasksExceptions
{
    class Program
    {
        static async Task Main()
        {
            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                Console.WriteLine("Whoopsie");
            };
            await  DoStuff();
            GC.Collect();
        }

        static async Task DoStuff()
        {
            await Task.Delay(100);
            throw new Exception();
        }
        // Output: nothing!!!!!!!! I see Whoopsie ONLY IF I put await fo DoStuff()!!!!!!!!
    }
}
