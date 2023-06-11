/*
Разработать приложение «Тамагочи». Жизненный цикл персонажа — 1-2 минуты. 
Персонаж случайным образом выдаёт просьбы (но подряд одна и та же просьба не выдаётся). 
Просьбы могут быть следующие: 
- покормить, 
- погулять, 
- уложить спать, 
- полечить, 
- поиграть. 
Если просьбы не удовлетворяются трижды, персонаж «заболевает» и просит его полечить. В случае отказа — «умирает». Персонаж отображается в консольном окне при помощи псевдографики.
 */

using CS_Tomagotchi;
using System;
using System.Timers;

namespace Delegate
{

    public delegate void TomagotchiStateHandler(string m);

    class Program
    {
        

        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();

            timer.Interval = 1000;

            Tomagotchi t = new Tomagotchi(100, 60);

            // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
            timer.Elapsed += new ElapsedEventHandler(t.OnTimer);

            timer.Start(); // Начинает вызывать событие Elapsed            

            t.feedMe += Green_Message;
            t.walkMe += Green_Message;
            t.sleepMe += Green_Message;
            t.playMe += Green_Message;
            t.treatMe += Yellow_Message;
            t.dead += Red_Message;

            Random rnd = new Random();

            int e = rnd.Next(1, 4);   
                
            int temp = e;

            while (true)
            {

                Console.WriteLine("\n Энергия : {0} Отказы : {1}", t.CurrentPower, t.Refusal);


                while (e == temp)        //контроль повторения событий
                {
                    e = rnd.Next(1, 5);
                }

                temp = e;

                switch (e)
                {
                    case 1: 
                        t.FeedMe();
                        break;
                    case 2:
                        t.WalkMe();
                        break; ;
                    case 3:
                        t.SleepMe();
                        break;
                    case 4:
                        t.PlayMe();
                        break;

                    default: 
                        break;
                }
                if (t.Refusal >= 3) t.TreatMe();

                if (!t.Alive()) t.Die();

                Console.Clear();
            }

        }



        private static void Green_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void Yellow_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void Red_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

