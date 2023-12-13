using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCSharp.dto.Orders.Response
{
    public class DeleteOrderResponse
    {
        public Guid Order_ID { get; set; }
        public Guid User_ID { get; set; }
        public Guid Product_ID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
