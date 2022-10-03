using AmazonClone.DAL.Entites;
using AmazonClone.Models;
using System.Linq;

namespace AmazonClone.BL.interfaces
{
    public interface IProductreo
    {
        IQueryable<ProductVM> GetAllProducts();
        ProductVM GetOneProduct(int id);
        IQueryable<ProductVM> GetFilterProduct(int id);
        bool CrateProduct(ProductVM model);
        void DeleteProduct(int id);
        void UpdateProduct(int id);
    }
}
