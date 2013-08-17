// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Sample
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TDAmeritrade.Client;
    using TDAmeritrade.Client.Models;

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Sample().Wait();
        }

        static async Task Sample()
        {
            Console.WriteLine("\n  TD Ameritrade .NET Client Library Demo\n");

            using (var client = new AmeritradeClient())
            {
                client.LogIn();

                Console.WriteLine("  Is Authenticated: " + client.IsAuthenticated);
                Console.WriteLine("  User's ID: " + (client.UserID ?? "n/a"));
                Console.WriteLine("  User's Exchange Status: " + client.UserExchangeStatus);
                Console.WriteLine("  Available Quotes:");
                Console.WriteLine("    - Real-Time: " + string.Join(", ", client.AvailableQuotes.RealTime
                    .Select(x => Enum.GetName(typeof(Markets), x))));
                Console.WriteLine("    - Delayed: " + string.Join(", ", client.AvailableQuotes.Delayed
                    .Select(x => Enum.GetName(typeof(Markets), x))));

                Console.WriteLine("  Symbol Lookup for 'bank of a':");
                foreach (var symbol in await client.FindSymbols("bank of a"))
                {
                    Console.WriteLine("    - " + symbol.Key + ", " + symbol.Value);
                }

                var quotes = await client.GetQuotes("GOOG", "GOOGGG");
                var prices = await client.GetHistoricalPrices("GOOG,MSFT", startDate: DateTime.Now.AddDays(-30));

                await client.LogOut();
            }

            Console.ReadKey(true);
        }
    }
}
