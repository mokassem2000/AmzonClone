using AmazonClone.DAL.AmazonContext;
using AmazonClone.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AmazonClone.BL.classes
{
    public class Total
    {


        public Total(AmazonContext context)
        {
            _context = context;
        }

        public AmazonContext _context { get; }

        public  int cartTotal(Order order) {
            int total = 0;
            var orderItems = _context.OoderItems.Where(o => o.OrderId==order.Id);
            foreach (var item in orderItems)
            {
                total +=item.quantity;
            }

            return total;

        }
        public decimal cartTotalprice(Order order)
        {
            decimal totalprice= 0m;
            var orderItems = _context.OoderItems.Include("Product").Where(o => o.OrderId == order.Id);
            foreach (var item in orderItems)
            {
                totalprice += (decimal)item.quantity*(decimal)item.Product.Price;
            }

            return totalprice;

        }
    }
}
