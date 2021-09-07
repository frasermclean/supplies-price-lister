using CsvHelper.Configuration.Attributes;

namespace SuppliesPriceLister.Models
{
    public class HumphriesSupply : ISupply
    {
        [Name("identifier")]
        public string Id { get; set; }

        [Name("desc")]
        public string Description { get; set; }

        [Name("costAUD")]
        public float Price { get; set; }

        [Name("unit")]
        public string UnitOfMeasurement { get; set; }

        public HumphriesSupply(string identifier, string desc, string unit, float costAUD)
        {
            Id = identifier;
            Description = desc;
            UnitOfMeasurement = unit;
            Price = costAUD;
        }
    }
}
