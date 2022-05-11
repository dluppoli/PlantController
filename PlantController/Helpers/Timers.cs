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
            List<Task> timers = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                int j = i;
                timers.Add(Task.Run( async () => await BetterTimer( (j + 1)*10 )) );
            }

            timers.Add(Task.Run(() => BadTimer(10)));

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

        public static async Task BetterTimer(int seconds)
        {
            Console.WriteLine("Timer for {0} seconds started", seconds);
            await Task.Delay(seconds * 1000);
            Console.WriteLine("Timer for {0} seconds ended", seconds);
        }
    }
}
