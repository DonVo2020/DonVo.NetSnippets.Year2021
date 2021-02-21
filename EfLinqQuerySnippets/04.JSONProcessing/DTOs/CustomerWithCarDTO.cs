using Newtonsoft.Json;

namespace EfLinqQuerySnippets._04.JSONProcessing.DTOs
{
    public class CustomerWithCarDTO
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty("spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
