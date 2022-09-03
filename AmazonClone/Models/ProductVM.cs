using System;

namespace AmazonClone.Models
{
    public class ProductVM
    {
        
        public int Id { set; get; }
       
        public string Name { set; get; }
        
        public string Desc { set; get; }
        public string SKU { set; get; }
       

        public decimal Price { set; get; }

        public DateTime CreatedAt { set; get; }
        public DateTime ModifiedAt { set; get; }
        public int StockQuantity { set; get; }
        public int CategoryId { set; get; }
        

    }
}
