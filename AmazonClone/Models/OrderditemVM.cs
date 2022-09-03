using System;

namespace AmazonClone.Models
{
    public class OrderditemVM
    {

     
        public int Id { set; get; }
      
        public int quantity { set; get; }
        public DateTime CreateAt { set; get; } 
        public int ProductId { set; get; }
        public int OrderId { set; get; }


    }
}
