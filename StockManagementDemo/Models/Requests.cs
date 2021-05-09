using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagementDemo.Models
{
    public class Requests
    {
    }

    public class putStockItemsRequest
    {
        public int? ID { get; set; }

        public string RegNo { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string ModelYear { get; set; }

        public decimal KMS { get; set; }

        public string Colour { get; set; }

        public string VIN { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal CostPrice { get; set; }

        public int Accessories { get; set; }

        public int Images { get; set; }

        public DateTime DTCreated { get; set; }

        public DateTime DTUpdated { get; set; }
    }
}
