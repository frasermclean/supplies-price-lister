namespace SuppliesPriceLister.Models
{
    public class MegacorpSupply : Supply
    {
        public override float Price => PriceInCents / 100;

        /// <summary>
        /// Price in cents.
        /// </summary>
        public uint PriceInCents { get; }

        /// <summary>
        /// Identifier of supply provider.
        /// </summary>
        public string ProviderId { get; }

        /// <summary>
        /// Material type.
        /// </summary>
        public string MaterialType { get; set; }
    }
}
