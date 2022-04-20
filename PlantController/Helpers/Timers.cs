using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PlantController.Helpers
{
    public static class Timers
    {
        public async static Task StartTimers()
        {
            List<Task> timers = new List<Task>(10);
            for (int i = 0; i < 10; i++)
            {
                int j = i;
                timers.Add(new Task(() => BadTimer(j + 1)));
            }

            foreach(Task timer in timers)
            {
                timer.Start();
            }

            await Task.WhenAll(timers);
            Console.WriteLine("Timer has finished");
        }


        public static void BadTimer(int seconds)
        {
            Console.WriteLine("Timer for {0} seconds started", seconds);
            DateTime startTime = DateTime.Now;
            DateTime nowTime = DateTime.Now;
            
            while( (nowTime-startTime).Seconds < seconds )
            {
                nowTime = DateTime.Now;
            }
            Console.WriteLine("Timer for {0} seconds ended", seconds);
        }

        public static void BetterTimer(int seconds)
        {
            Console.WriteLine("Timer for {0} seconds started", seconds);
            Thread.Sleep(seconds*1000);
            Console.WriteLine("Timer for {0} seconds ended", seconds);
        }
    }
}
