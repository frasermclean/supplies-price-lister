using CsvHelper;
using SuppliesPriceLister.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SuppliesPriceLister.Parsing
{
    public static class HumpriesCsvParser
    {
        public static IEnumerable<HumphriesSupply> GetHumphriesSupplies(string filename)
        {
            try
            {
                using var streamReader = new StreamReader(filename);
                using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

                var records = csvReader.GetRecords<HumphriesSupply>().ToList();
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while trying to read CSV file: {filename}, exception: {ex}");
                return new List<HumphriesSupply>();
            }
        }
    }
}
