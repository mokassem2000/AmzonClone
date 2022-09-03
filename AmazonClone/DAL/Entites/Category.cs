using System.Collections.Generic;

namespace AmazonClone.DAL.Entites
{
    public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public virtual List<Product> products { set; get; }
    }
}
