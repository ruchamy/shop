using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int quantity { get; set; }
        public string ImageSrc { get; set; }
    }
}
