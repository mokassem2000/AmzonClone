using AmazonClone.BL.interfaces;
using AmazonClone.DAL.AmazonContext;
using AmazonClone.DAL.Entites;
using AmazonClone.Models;
using System.Linq;

namespace AmazonClone.BL.classes
{
    public class ProductRepo : IProductreo
    {
        public ProductRepo(AmazonContext context)
        {
            Context = context;
        }

        public AmazonContext Context { get; }

        public void DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductVM> GetAllProducts()
        {
            var data = Context.products.Select(product => new ProductVM()
            {
                Id=product.Id,
                Name = product.Name,
                Desc = product.Desc,
                SKU = product.SKU,
                Price = product.Price,
                CreatedAt = product.CreatedAt,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                imageName = product.Image,



            });
            return data;
        }
        public  ProductVM GetOneProduct(int id)
        {
            var data = Context.products.FirstOrDefault(product =>product.Id==id);
            var dataVM = new ProductVM()
            {
                Id = data.Id,
                Name = data.Name,
                Desc = data.Desc,
                SKU = data.SKU,
                Price = data.Price,
                CreatedAt = data.CreatedAt,
                StockQuantity = data.StockQuantity,
                CategoryId = data.CategoryId,
                imageName=data.Image,
              

            };
            return dataVM;
        }
        public bool CrateProduct(ProductVM model)
        {
            if (model != null)
            {
                var product = new Product()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Desc = model.Desc,
                    SKU = model.SKU,
                    Price = model.Price,
                    CreatedAt = model.CreatedAt,
                    StockQuantity = model.StockQuantity,
                    CategoryId = model.CategoryId,
                    Image = model.imageName,
                };
                Context.Add(product);
                Context.SaveChanges();
                return true;



            }
            else{
                return false;

            }




        }
        public IQueryable<ProductVM>  GetFilterProduct(int id)
        {
            var data = Context.products.Where(item => item.CategoryId == id).Select(product => new ProductVM()

            {
                Id = product.Id,
                Name = product.Name,
                Desc = product.Desc,
                SKU = product.SKU,
                Price = product.Price,
                CreatedAt = product.CreatedAt,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                imageName = product.Image,

            });
            
            return data;
        }
        public void UpdateProduct(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
