using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeverageManagement
{
    public class Order
    {
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public decimal TotalPrice => Items.Sum(item => item.TotalPrice);  // 计算订单总价
        public string OrderStatus { get; set; }
        public int OrderID { get; set; }
        // 添加饮品到订单
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        // 清空订单
        public void ClearOrder()
        {
            Items.Clear();
        }
    }

}
