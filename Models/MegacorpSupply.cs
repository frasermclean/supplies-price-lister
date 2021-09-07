using Newtonsoft.Json;

namespace SuppliesPriceLister.Models
{
    public class MegacorpSupply : Supply
    {
        public override string Id { get; set; }
        public override string Description { get; set; }
        public override float Price { get; set; }

        [JsonProperty("uom")]
        public override string UnitOfMeasurement { get; set; }

        /// <summary>
        /// Price in US cents.
        /// </summary>
        [JsonProperty("priceInCents")]
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
