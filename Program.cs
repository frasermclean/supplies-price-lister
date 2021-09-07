using Microsoft.Extensions.Configuration;
using SuppliesPriceLister.Models;
using SuppliesPriceLister.Parsing;
using System;
using System.Collections.Generic;

namespace SuppliesPriceLister
{
    public class Program
    {
        private static float exchangeRate;

        #region Constants

        private const string SettingsFilename = "appsettings.json";
        private const string HumphriesCsvFilename = "humphries.csv";
        private const string MegacorpJsonFilename = "megacorp.json";

        #endregion

        public static void Main(string[] args)
        {
            Console.WriteLine($"Reading configuration file: {SettingsFilename}");

            // read configuration from file
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(SettingsFilename, optional: false)
                .Build();

            // get exchange rate from configuration
            if (!float.TryParse(configuration.GetSection("audUsdExchangeRate").Value, out exchangeRate))
            {
                Console.WriteLine($"Error: couldn't read exchange rate from: {SettingsFilename}");
                return;
            }

            Console.WriteLine($"Current AUD to USD exchange rate is: {exchangeRate}");

            // read supply data from files
            var humpriesSupplies = HumpriesCsvParser.GetHumphriesSupplies(HumphriesCsvFilename);
            var megacorpSupplies = MegacorpJsonParser.GetMegacorpSupplies(MegacorpJsonFilename, exchangeRate);

            // create combined, sorted list of supplies
            var supplies = new List<Supply>();
            supplies.AddRange(humpriesSupplies);
            supplies.AddRange(megacorpSupplies);
            supplies.Sort((a, b) =>
            {
                if (a.Price > b.Price)
                    return -1; // a's price is higher
                else if (a.Price < b.Price)
                    return 1; // b's price is higher

                return 0; // equal
            });

            RenderSupplies(supplies);
        }

        /// <summary>
        /// Prints a collection of supplies to the console.
        /// </summary>
        /// <param name="">The collection to render.</param>
        private static void RenderSupplies(List<Supply> supplies)
        {
            Console.WriteLine($"Rendering {supplies.Count} supplies." + Environment.NewLine);

            string heading = string.Format("{0, -45}{1, -55}{2}", "ID", "Item Description", "Price (AUD)");
            Console.WriteLine(heading);

            // draw a line accross the entire window width
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("-");

            foreach (var supply in supplies)
            {
                string line = string.Format("{0, -45}{1, -55}{2, 11:C}", supply.Id, supply.Description, supply.Price);
                Console.WriteLine(line);
            }
        }
    }
}
