using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Programm
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100 };

            int[] coins_list = new int [1];

            //Console.WriteLine("Welcome to coin-change calculator");
            //Console.WriteLine("Please enter amount of money  you want to change: ");
            //int amount = 589;

            //Console.WriteLine("If you want to change amount with coins existing coins enter_[1]");
            //Console.WriteLine("If you want to enter your own coins value,enter______________[2]");
            //    int ans1 = int.Parse(Console.ReadLine());

            //if (ans1 == 1)
            //{
            //    Change_Greedy(coins, amount);
            //}
            //else if (ans1 == 2)
            //{
            //    Change_Dynamic(coins_list, amount);
            //}
            #endregion

            #region Analys

            int size = 100;

            Console.WriteLine("Greedy     Dynamic");
            for (int i = 1; i < 11; i++)
            {
                RunAnalys(size * i);
            }
           
            #endregion
        }
        public static void RunAnalys(int NumberOfCoins)
        {

            List<int> CoinsList = new List<int>();

            for (int i = 1; i <= NumberOfCoins; i++)
            {
                CoinsList.Add(i);
            }
            int change = 1000;
            for (int i = 1; i < 11; i++)
            {
                change=change * i;
            }
            int[] coins = CoinsList.ToArray();



            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            MakeChange.Change_Greedy(coins, change);
            stopwatch.Stop();
            double TimeForGreedyWithCoinsInc = stopwatch.Elapsed.TotalMilliseconds;
            //Console.WriteLine(NumberOfCoins+";"+TimeForGreedyWithCoinsInc);


            stopwatch.Restart();
            MakeChange.Change_Dynamic_Random(coins,change);
            stopwatch.Stop();
            double TimeForDynamicWithCoinsInc = stopwatch.Elapsed.TotalMilliseconds;
            //Console.WriteLine(TimeForDynamicWithCoinsInc);

            stopwatch.Restart();
            MakeChange.Change_Greedy(coins, change);
            stopwatch.Stop();
            double TimeForGreedyChangeIncreasing = stopwatch.Elapsed.TotalMilliseconds;
            //Console.WriteLine(TimeForGreedyChangeIncreasing);

            stopwatch.Restart();
            MakeChange.Change_Dynamic_Random(coins, change);
            stopwatch.Stop();
            double TimeForDynamicWithChangeIncrease = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(TimeForDynamicWithChangeIncrease);

        }


    }
    class MakeChange
    {
        public static void Change_Greedy(int[] coins, int amount)
        {

            Array.Sort(coins);
            Array.Reverse(coins);

            List<string> amount_list = new List<string>();

            foreach (int coin in coins)
            {
                int how_many = amount / coin;

                if (how_many > 0)
                {
                    amount_list.Add(how_many + "x" + coin);
                }

                amount = amount % coin;

            }
            
            //Console.WriteLine(string.Join(", ", amount_list.ToArray()));
        }
        public static void Change_Dynamic(int[] coins, int change)
        {

            var coins_list = new List<int>();


            for (int k = 0; k < 1; k++)
            {

                Console.WriteLine("Do you want to enter coins? n/ yes/1 no/2 ");
                int answer = int.Parse(Console.ReadLine());
                if (answer == 1)
                {
                    for (int i = 0; i < coins_list.Count + 1; i++)
                    {
                        i = int.Parse(Console.ReadLine());
                        if (i > 0)
                        {
                            coins_list.Add(i);
                            i++;
                        }
                    }
                    k--;
                    continue;
                }
                else
                {

                    continue;
                }

            }
            int[] coins_list1 = coins_list.ToArray();
            Array.Sort(coins_list1);
            Array.Reverse(coins_list1);
            var coins_list2 = new List<string>();
            foreach (int coin in coins_list1)
            {
                int quantity = change / coin;

                if (quantity > 0)
                {
                    coins_list2.Add(quantity + "x" + coin);
                }

                change = change % coin;

            }
            Console.WriteLine(string.Join(", ", coins_list2.ToArray()));
        }
        public static void Change_Dynamic_Random(int[]coins,int change)
        {
            Random random = new Random();
            var coins_list = new List<int>();
                    for (int i = 0; i < coins_list.Count + 1; i++)
                    {
                        i = random.Next(0,100);
                            coins_list.Add(i);
                            i++;
                    }
            
            int[] coinsArray = coins_list.ToArray();
            Array.Sort(coinsArray);
            Array.Reverse(coinsArray);
            var coins_list2 = new List<string>();
            foreach (int coin in coins)
            {
                int quantity = change / coin;

                if (quantity > 0)
                {
                    coins_list2.Add(quantity + "x" + coin);
                }

                change = change % coin;

            }
           

        }
    }
}
