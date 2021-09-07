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
            var supplies = new List<ISupply>();
            supplies.AddRange(humpriesSupplies);
            supplies.AddRange(megacorpSupplies);

            RenderSupplies(supplies);
        }

        /// <summary>
        /// Prints a collection of supplies to the console.
        /// </summary>
        /// <param name="">The collection to render.</param>
        private static void RenderSupplies(List<ISupply> supplies)
        {
            Console.WriteLine($"Rendering {supplies.Count} supplies.");
        }
    }
}
