using CsvHelper.Configuration.Attributes;

namespace SuppliesPriceLister.Models
{
    public class HumphriesSupply : Supply
    {
        public HumphriesSupply(string identifier, string desc, string unit, float costAUD)
        {
            Id = identifier;
            Description = desc;
            UnitOfMeasurement = unit;
            Price = costAUD;
        }
    }
}
