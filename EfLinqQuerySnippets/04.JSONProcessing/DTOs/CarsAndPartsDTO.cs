using Newtonsoft.Json;
using System.Collections.Generic;

namespace EfLinqQuerySnippets._04.JSONProcessing.DTOs
{
    public class CarsAndPartsDTO
    {
        [JsonProperty("car")]
        public CarMakeModelDistanceDTO Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<PartNamePriceDTO> Parts { get; set; }
    }
}
