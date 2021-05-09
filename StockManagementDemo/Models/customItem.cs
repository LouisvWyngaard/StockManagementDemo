using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagementDemo.Models
{
    public class customItem
    {
        public int? ID { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public List<Image> image { get; set; }
    }
}
