using CsvHelper.Configuration.Attributes;

namespace SuppliesPriceLister.Models
{
    public class HumphriesSupply : Supply
    {
        [Name("identifier")]
        public override string Id { get; set; }

        [Name("desc")]
        public override string Description { get; set; }

        [Name("costAUD")]
        public override float Price { get; set; }

        [Name("unit")]
        public override string UnitOfMeasurement { get; set; }

        public HumphriesSupply(string identifier, string desc, string unit, float costAUD)
        {
            Id = identifier;
            Description = desc;
            UnitOfMeasurement = unit;
            Price = costAUD;
        }
    }
}
