using AmazonClone.DAL.AmazonContext;
using AmazonClone.DAL.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace AmazonClone.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanger;
        private readonly Order _order;
        private readonly AmazonContext _context;

        public SignInManager<IdentityUser> _signInManager { get; }

        public CartController(UserManager<IdentityUser> usermanger, Order order, AmazonContext Context, SignInManager<IdentityUser> signInManager)
        {
            _usermanger = usermanger;
            _order = order;
            _context = Context;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {


            IdentityUser user = HttpContext.User.Identity.IsAuthenticated ? await _usermanger.FindByNameAsync(HttpContext.User.Identity.Name) : null;
            if (user != null)
            {
                var userorder = _context.orders.Include(o => o.User).FirstOrDefault(o => o.User.Id == user.Id);
                if (userorder == null)
                {
                    userorder = new Order()
                    {
                        User = user,
                    };

                    _context.Add(userorder);
                    _context.SaveChanges();


                }


                var orderItems = _context.OoderItems.Include(o => o.Product).Where(o => o.OrderId == userorder.Id).ToArray();
                ViewBag.orderItems = orderItems;
                ViewBag.ordereditemCount = userorder.items;


            }


            return View();
        }
      
        public async Task<IActionResult> AddItem(int id)
        {
            IdentityUser user = HttpContext.User.Identity.IsAuthenticated ? await _usermanger.FindByNameAsync(HttpContext.User.Identity.Name) : null;

            if (user != null)
            {
                var product = _context.products.Where(p => p.Id == id).ToArray();
                var userorder = _context.orders.Include(o => o.User).FirstOrDefault(o => o.User.Id == user.Id);
                var orderditem = _context.OoderItems.FirstOrDefault(o => o.OrderId == userorder.Id && o.ProductId == product[0].Id);


                userorder = _context.orders.Include(o => o.User).FirstOrDefault(o => o.User.Id == user.Id);
                if (userorder == null)
                {
                    userorder = new Order()
                    {
                        User = user,
                    };

                    _context.Add(userorder);
                    _context.SaveChanges();


                }
                orderditem = _context.OoderItems.FirstOrDefault(o => o.OrderId == userorder.Id && o.ProductId == product[0].Id);
                if (orderditem == null)
                {

                    OrderdItem orderdItem = new OrderdItem() { OrderId = userorder.Id, ProductId = product[0].Id, quantity = 1, };
                    _context.Add(orderdItem);
                    userorder.items += 1;
                    product[0].StockQuantity -= 1;
                    _context.Update(userorder);
                    _context.Update(product[0]);
                    _context.SaveChanges();
                    return Json(new { orderditem.quantity });
                }
                orderditem.quantity += 1;
                product[0].StockQuantity -= 1;
                userorder.items = orderditem.quantity;
                _context.Update(product[0]);
                _context.Update(orderditem);
                _context.Update(userorder);
                _context.SaveChanges();
                return Json(new {orderditem.quantity});

            }
                return RedirectToAction("Login", "Account");
           

            

        }
        public async  Task<IActionResult> removeItem(int id)
        {
            var product = _context.products.Where(p => p.Id == id).ToArray();
            IdentityUser user = HttpContext.User.Identity.IsAuthenticated ? await _usermanger.FindByNameAsync(HttpContext.User.Identity.Name) : null;
            var userorder = _context.orders.Include(o => o.User).FirstOrDefault(o => o.User.Id == user.Id);
            var orderditem = _context.OoderItems.FirstOrDefault(o => o.OrderId == userorder.Id && o.ProductId == product[0].Id);

            if (orderditem.quantity > 1)
            {
                orderditem.quantity -= 1;
                userorder.items = orderditem.quantity;
                _context.Update(orderditem);
                _context.SaveChanges();
                return Json(new { orderditem.quantity });
            }
            _context.Remove(orderditem);
            _context.SaveChanges();
            return Json(new { orderditem.quantity });
        }
    }
}
