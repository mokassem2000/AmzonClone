using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonClone.DAL.Entites
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Name{ set; get; }
        [Required]
        public string Desc { set; get; }
        [Required]
        public string Image { set; get; }
        public string SKU { set; get; }
        [Required]
         
        public decimal Price { set; get; }

        public DateTime CreatedAt { set; get; }=DateTime.Now;
        public DateTime ModifiedAt { set; get; }
        public int StockQuantity { set; get; }
        public int  CategoryId { set; get; }
        public Category category { set; get; }
        public virtual List<OrderdItem> orderditems { set; get; }







    }
}
