using Newtonsoft.Json;

namespace SuppliesPriceLister.Models
{
    public class MegacorpSupply : ISupply
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public float Price => PriceInCents / 100;

        [JsonProperty("uom")]
        public string UnitOfMeasurement { get; set; }

        /// <summary>
        /// Price in cents.
        /// </summary>
        public uint PriceInCents { get; set; }

        /// <summary>
        /// Identifier of supply provider.
        /// </summary>
        public string ProviderId { get; set; }

        /// <summary>
        /// Material type.
        /// </summary>
        public string MaterialType { get; set; }
    }
}
