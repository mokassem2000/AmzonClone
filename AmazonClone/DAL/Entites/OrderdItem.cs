using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonClone.DAL.Entites
{
    [Table("OrserdItem")]
    public class OrderdItem
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public int quantity { set; get; }
        public DateTime CreateAt{ set; get; }= DateTime.Now;
        public int ProductId { set; get; }

        public Product Product { set; get; }
        public int OrderId { set; get; }
       
        public Order order { set; get; }





    }
}
