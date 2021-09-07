using Microsoft.Extensions.Configuration;
using System;

namespace SuppliesPriceLister
{
    public class Program
    {
        private static float exchangeRate;

        private const string SettingsFilename = "appsettings.json";

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
        }
    }
}
