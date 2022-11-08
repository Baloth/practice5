using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakes.Entyties
{
    internal class CakeOrder
    {
        public int Id { get; set; }

        public List<CakeOrderItem> cakeOrderItems { get; set; }

        public double TotalSumm { get; set; }
    }
    internal class CakeOrderItem
    {
        public int Id { get; set; }

        public CakeOrder orderId { get; set; }

        public CakeAttr attrName { get; set; }

        public CakeProp CakeProp { get; set; }

    }

}
