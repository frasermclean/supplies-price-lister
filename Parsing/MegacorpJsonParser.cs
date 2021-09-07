using Newtonsoft.Json;
using SuppliesPriceLister.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuppliesPriceLister.Parsing
{
    public static class MegacorpJsonParser
    {
        public static IEnumerable<MegacorpSupply> GetMegacorpSupplies(string filename, float exchangeRate)
        {
            try
            {
                // read and parse json from file
                string jsonString = File.ReadAllText(filename);
                var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonString);

                // iterate through each partner and add every supply
                var supplies = new List<MegacorpSupply>();
                foreach (var partner in rootObject.Partners)
                    supplies.AddRange(partner.Supplies);

                // iterate though each supply to calculate price in AUD
                foreach (var supply in supplies)
                    supply.Price = supply.PriceInUsCents / 100 * exchangeRate;

                return supplies;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while trying to read Megacorp JSON file: {filename}, exception: {ex}");
                return new List<MegacorpSupply>();
            }
        }

        /// <summary>
        /// Root object of the Megacorp JSON file.
        /// </summary>
        private class RootObject
        {
            [JsonProperty("partners")]
            public List<MegacorpPartner> Partners { get; set; }
        }
    }
}
