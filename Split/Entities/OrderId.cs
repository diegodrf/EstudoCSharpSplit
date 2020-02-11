using System;
using System.Collections.Generic;
using System.Text;

namespace Split.Entities
{
    class OrderId
    {
        public string MerchantOrderId { get; set; }
        public OrderId()
        {
        }

        public OrderId(string merchantOrderId)
        {
            MerchantOrderId = merchantOrderId;
        }
    }
}
