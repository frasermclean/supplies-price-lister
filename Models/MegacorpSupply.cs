using Newtonsoft.Json;

namespace SuppliesPriceLister.Models
{
    public class MegacorpSupply : ISupply
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        [JsonProperty("uom")]
        public string UnitOfMeasurement { get; set; }

        /// <summary>
        /// Price in US cents.
        /// </summary>
        public uint PriceInUsCents { get; set; }

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
