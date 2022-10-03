using AmazonClone.DAL.AmazonContext;
using AmazonClone.DAL.Entites;
using System.Collections.Generic;
using System.Linq;

namespace AmazonClone.BL.classes
{
    public class CategoryRepo
    {
        public CategoryRepo(AmazonContext amazonContext)
        {
            AmazonContext = amazonContext;
        }

        public AmazonContext AmazonContext { get; }

        public IQueryable<Category> GetAllCategory()
         {
            return AmazonContext.categories;
        
        
        }
    }
}
