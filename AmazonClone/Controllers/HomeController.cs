  using AmazonClone.BL.interfaces;
using AmazonClone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonClone.Controllers
{
    
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IProductreo Products { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public HomeController(ILogger<HomeController> logger, IProductreo products,IHostingEnvironment HostingEnvironment)
        {
            _logger = logger;
            Products = products;
            this.HostingEnvironment = HostingEnvironment;
        }

       
        public IActionResult Index(int pg=1)

        {
            
            /*int PageIndex,int PageSize*/
            const int pagesize = 10;
            if (pg < 1)
            {
                pg = 1;
            }
            ;
            var countData = Products.GetAllProducts().ToList().Count();
            var pager = new Pager(countData,pg,pagesize);
            int recskip = (pg - 1) * pagesize;
            var data = Products.GetAllProducts().Skip(recskip).Take(pagesize);

          
            ViewBag.Pager = pager;



            return View(data);
        }
     
        public IActionResult ProductDitail(int id)
        {
            var data=Products.GetOneProduct(id);
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct(ProductVM model)
        {
         
            string uniqefilename = null;
            if (model.image != null)
            {
                string uploadfolder = Path.Combine(HostingEnvironment.WebRootPath + "\\ProductImages");
                uniqefilename = Guid.NewGuid().ToString() + "_" + model.image.FileName;
                string imagePath = Path.Combine(uploadfolder, uniqefilename);
                model.image.CopyTo(new FileStream(imagePath, FileMode.Create));
                model.imageName = uniqefilename;
                if (ModelState.IsValid)
                {

                    var result = Products.CrateProduct(model);
                    if (result)
                    {


                        return RedirectToAction("Index");

                    }
                    else
                    {

                        ModelState.AddModelError("", "somthing wrong happen while adding the product ");
                    }



                }


            }
            else {
                ModelState.AddModelError("", "enter image plese");
               return View(model);

            }
            
            return View(model);
        }
        [HttpGet]
        //[Authorize(Roles ="")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct()
        {

            return View();

        }
        public JsonResult ProductFilter(int id)
        {
            var data=Products.GetFilterProduct(id);

            return Json(data);

        }
        public IActionResult Privacy()
        {

            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
