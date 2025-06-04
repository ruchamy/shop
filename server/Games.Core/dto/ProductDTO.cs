using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Games.Core
{
    public class ProductDTO
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public int CategoryId { get; set; }
        //public string Description { get; set; }
        //public int Price { get; set; }
        //public int quantity { get; set; }
        //public string ImageSrc { get; set; }


        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("imageSrc")]
        public string ImageSrc { get; set; }
    }
}
