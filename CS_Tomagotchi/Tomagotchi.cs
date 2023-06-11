
using Delegate;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace CS_Tomagotchi
{

    class Tomagotchi
    {
        int  _power, _refusal, _count;

        public Tomagotchi(int power, int count) 
        { 
            _power = power;
            _count = count;
        }

        public int Count
        {
            set => _count = value;

            get => _count;
        }
        public int CurrentPower
        {
            set => _power = value;

            get => _power;
        }

        public int Refusal
        {
            set => _refusal = value;

            get => _refusal;
        }

        public bool Act()
        {
            ConsoleKeyInfo a;            

            while (true || false)
            {
                Console.Write("\n Удовлетворить просьбу? (Y/N) :");

                a = Console.ReadKey();

                if (a.Key == ConsoleKey.Y)
                    return true;
 
                if (a.Key == ConsoleKey.N)
                    return false;
                else
                    Console.Write("\n Ошибка! Попробуйте еще раз...");
            }
        }

        public void FeedMe()
        {
            CurrentPower -= 10;

            PrintFunny();
            feedMe?.Invoke("\n Я голодный! Покорми меня! ");

            if (Act())
            {
                CurrentPower += 25;
                Refusal = 0;
            }
            else
            {
                Refusal++;
                Console.Clear();
                Console.WriteLine("\n");
                PrintSad();
                Console.ReadKey();
            }
        }

        public void WalkMe()
        {
            CurrentPower -= 10;

            PrintFunny();
            feedMe?.Invoke("\n Я устал! Погуляй со мной! ");

            if (Act())
            {
                CurrentPower += 25;
                Refusal = 0;
            }
            else
            {
                Refusal++;
                Console.Clear();
                Console.WriteLine("\n");
                PrintSad();
                Console.ReadKey();
            }
        }

        public void SleepMe()
        {
            CurrentPower -= 10;

            PrintFunny();
            feedMe?.Invoke("\n Я устал! Уложи меня спать! ");

            if (Act())
            {
                CurrentPower += 25;
                Refusal = 0;
            }
            else
            {
                Refusal++;
                Console.Clear();
                Console.WriteLine("\n");
                PrintSad();
                Console.ReadKey();
            }
        }

        public void PlayMe()
        {
            CurrentPower -= 10;

            PrintFunny();
            playMe?.Invoke("\n Мне скучно! Поиграй со мной! ");

            if (Act())
            {
                CurrentPower += 25;
                Refusal = 0;
            }
            else
                {
                    Refusal++;
                    Console.Clear();
                    Console.WriteLine("\n");
                    PrintSad();
                    Console.ReadKey();
                }
            }

        public void TreatMe()
        {
            CurrentPower -= 10;
                        
            treatMe?.Invoke("\n Я заболел! Полечи меня! ");

            if (Act())
            {
                CurrentPower += 25;
                Refusal = 0;
            }
            else Die();
        }

        public void Die()
        {
            Console.Clear();
            Console.WriteLine("\n");
            PrintDead();

            dead?.Invoke("\n Я умер! Энергия: " + CurrentPower + " Отказы: " + Refusal + " Время жизни: " + Count);

            Environment.Exit(0);
        }

        public bool Alive()
        {
            if (CurrentPower <= 0) return false;
            else            
                return true;
        }

        public void PrintFunny()
        {
            Console.WriteLine();
            Console.WriteLine("     **        **");
            Console.WriteLine("    ****      ****");
            Console.WriteLine("    *****    *****");
            Console.WriteLine("     ************");
            Console.WriteLine("     *          * ");
            Console.WriteLine("    *   (.)  (.) *  ");
            Console.WriteLine("    *            *");
            Console.WriteLine("  ****   *   *  ****");
            Console.WriteLine("  ****    ***   ****   ");
            Console.WriteLine("      **********   ");
            Console.WriteLine("       ***   ***   ");
            Console.WriteLine("\n\n Нажмите любую клавишу...");
        }

        public void PrintSad()
        {
            Console.WriteLine();
            Console.WriteLine("     **        **");
            Console.WriteLine("    ****      ****");
            Console.WriteLine("    *****    *****");
            Console.WriteLine("     ************");
            Console.WriteLine("     *          * ");
            Console.WriteLine("    *   (.)  (.) *  ");
            Console.WriteLine("    *            *");
            Console.WriteLine("  ****    ***   ****");
            Console.WriteLine("  ****   *   *  ****   ");
            Console.WriteLine("      **********   ");
            Console.WriteLine("       ***   ***   ");
            Console.WriteLine("\n\n Нажмите любую клавишу...");
        }

        public void PrintDead()
        {
            Console.WriteLine();
            Console.WriteLine("     **        **");
            Console.WriteLine("    ****      ****");
            Console.WriteLine("    *****    *****");
            Console.WriteLine("     ************");
            Console.WriteLine("     *          * ");
            Console.WriteLine("    *    x    x  *  ");
            Console.WriteLine("    *            *");
            Console.WriteLine("  ****    ***   ****");
            Console.WriteLine("  ****          ****   ");
            Console.WriteLine("      **********   ");
            Console.WriteLine("       ***   ***   ");
        }

        //static int count = 0;

        public void OnTimer(object sender, ElapsedEventArgs arg /* Предоставляет данные для события Elapsed */)
        {
            System.Timers.Timer timer = (System.Timers.Timer)sender;

            Count--;

            if (Count == 0)
            {
                timer.Stop();

                Die();
            }

            Console.Title = String.Format(" Томагочи. Время жизни {0} секунд.", Count);
        }

        public event TomagotchiStateHandler feedMe;
        public event TomagotchiStateHandler walkMe;
        public event TomagotchiStateHandler sleepMe;
        public event TomagotchiStateHandler treatMe;
        public event TomagotchiStateHandler playMe;

        public event TomagotchiStateHandler dead;
    }
}

