using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Sum_of_coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var totalCoins = 0;
            var usedCoins = new Dictionary<int, int>();

            var coins = new Queue<int>(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(c => c));
                
            var target = int.Parse(Console.ReadLine());
            

            while (target > 0 && coins.Count != 0)
            {
                var currentCoin = coins.Dequeue();
                var count = target / currentCoin;

                if (count == 0)
                {
                    continue;
                }

                usedCoins[currentCoin] = count;
                totalCoins += count;

                target %= currentCoin;
            }

            if (target != 0)
            {
                Console.WriteLine("Error");
                return;
            }

            Console.WriteLine($"Number of coins to take: {totalCoins}");
            foreach (var coin in usedCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }
    }
}