using Microsoft.Extensions.Configuration;
using SuppliesPriceLister.Models;
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

            var supplies = new List<ISupply>();

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
