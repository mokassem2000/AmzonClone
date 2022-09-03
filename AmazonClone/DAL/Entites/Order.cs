using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonClone.DAL.Entites
{
    public class Order
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public IdentityUser User { set; get; }
        public int total { set; get; }
        public DateTime CreateAt { set; get; } = DateTime.Now;

        public virtual   List<OrderdItem>  Orders{ set; get; }

    }
}
