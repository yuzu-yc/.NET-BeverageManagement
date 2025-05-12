using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeverageManagement
{
    public class OrderItem
    {
        public string DrinkName { get; set; }   // 饮品名称
        public int Quantity { get; set; }        // 饮品数量
        public decimal Price { get; set; }       // 饮品单价
        public decimal TotalPrice => Quantity * Price;  // 饮品总价
    }

}
