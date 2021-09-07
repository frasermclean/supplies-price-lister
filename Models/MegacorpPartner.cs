using Newtonsoft.Json;
using System.Collections.Generic;

namespace SuppliesPriceLister.Models
{
    public class MegacorpPartner
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("partnerType")]
        public string Type { get; set; }

        [JsonProperty("partnerAddress")]
        public string Address { get; set; }

        [JsonProperty("supplies")]
        public List<MegacorpSupply> Supplies { get; set; }
    }
}
