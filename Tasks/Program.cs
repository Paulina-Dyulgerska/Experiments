using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //}

        static async Task Main()
        {
            Console.WriteLine("Start Main 1 " + DateTime.UtcNow.ToString("T"));
            //new Task(() => PrintNumbersInRange(1, 10)).Start();
            //var f1 = DoStuff1();
            DoStuff1();
            Console.WriteLine("Finish Main 1 " + DateTime.UtcNow.ToString("T"));

            Console.WriteLine(new string('-', 60));

            Console.WriteLine("Start Main 2 " + DateTime.UtcNow.ToString("T"));
            //var f2 = DoStuff2();
            //await DoStuff2();
            Console.WriteLine("Finish Main 2 " + DateTime.UtcNow.ToString("T"));
            //await Task.WhenAll(f2);

            //Console.WriteLine($"{f1.Result} + {f2.Result}");
            Console.WriteLine("Finish Main await Task.WhenAll(f1, f2); " + DateTime.UtcNow.ToString("T"));


            Console.WriteLine("Start Main 0 " + DateTime.UtcNow.ToString("T"));
            var t = new Task(async () => await DoStuff());
            t.Start();
            await Task.WhenAll(t);
            Console.WriteLine("Finish Main 0 " + DateTime.UtcNow.ToString("T"));


            Console.WriteLine("Start Main with new Task returned " + DateTime.UtcNow.ToString("T"));
            var tt = DoStuff2();
            //tt.Wait();
            Console.WriteLine("Finish Main with new Task returned " + DateTime.UtcNow.ToString("T"));



            Console.ReadLine(); //ako nqmam await na Task.Delay(10000) i nqmam tozi red tuk, programata 
            //shte svyrshi PREDI tezi Taskove, koito sa bez await, da sa svyrshili rabotata si i az nqma 
            // da q polucha tazi rabota kato resultat!!!! Task.Delay(10000) se mqtka v ThreadPool-a i ostawa
            // tam za wremeto, koeto mu dam, a sled towa, ako mu dam neshto za ContinueWith, to towa neshto
            //nqma da se izpylni, ako programata svyrshi predi da e minalo wremeto za delay na task ot 
            // Task.Delay()!!!!! Zatowa da dawam na wseki otdelen otrqzyk ot rabota otdelen await, ako 
            // shte mi tbrqwa zadyljitelno da si go polucha, zashtoto inache moje i da ne go polucha!!!
            // v ASP.NET Core imam neprekysnato vyrwqsht app i zatowa tam se izpylnqwat wsichki zadadeni
            // sled Task.Delay neshta, no tuk v tozi consolen app, towa ne e taka i trqbwa da spra 
            // programata s COnsole.Readline, za da ne izleze ot scope-yt i da svyrshi!!!!!!!!! I towa NE
            // zawisi ot towa dali mi e Main-a async ili ne - svyrshi li coda, izliza ot Main i zatwqrq 
            // programata, bez znacheni dali ima taskowe, koito ne sa svyrshili rabotata si.
            // DA PROVERQ DALI AKO DYJRA TQHNA instancii, shte e pak taka!!!!
        }
        static async Task DoStuff()
        {
            Console.WriteLine("Start DoStuff 0 " + DateTime.UtcNow.ToString("T"));
            //Thread.Sleep(5000);
            new Task(() => PrintNumbersInRange(21, 30));
            await Task.Delay(2000).ContinueWith((a) => PrintNumbersInRange(400, 410));
            Console.WriteLine("Finish DoStuff 0 " + DateTime.UtcNow.ToString("T"));
        }

        static async Task DoStuff1()
        {
            Console.WriteLine("Start DoStuff 1 " + DateTime.UtcNow.ToString("T"));
            //Thread.Sleep(5000);
            new Task(() => PrintNumbersInRange(21, 30));
            Task.Delay(10000).ContinueWith((a) => PrintNumbersInRange(100, 110));
            Console.WriteLine("Finish DoStuff 1 " + DateTime.UtcNow.ToString("T"));
            await Task.Run(() => PrintNumbersInRange(1, 10));
            //throw new Exception();
        }

        static async Task DoStuff2()
        {
            Console.WriteLine("Start DoStuff 2 " + DateTime.UtcNow.ToString("T"));
            //Thread.Sleep(2000);
            //await Task.Delay(2000).ContinueWith((a) => DoStuff1());
            await Task.Delay(3000);
            Console.WriteLine("Finish DoStuff 2 " + DateTime.UtcNow.ToString("T"));
            //throw new Exception();

            new Task(() => PrintNumbersInRange(11, 20)).Start(); // tozi task nikoga ne se dovyrshva,
                                                                 // zashtoto Main Threada spira!!!
                                                                 //Ako iskam da se izpylni, trqbwa da
                                                                 // spra s Console.Readline Main methoda, za
                                                                 // da moje da se izpylni i towa!!!
            var tttt = new Task(() => PrintNumbersInRange(1001, 1010));
            tttt.Start();
        }

        static void PrintNumbersInRange(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine($"{i} {DateTime.UtcNow.ToString("T")}");
            }
        }

    }
}
