using Microsoft.AspNetCore.Identity;
using System;

namespace AmazonClone.Models
{
    public class OredrVM
    {
        public int Id { set; get; }
       
        public IdentityUser User { set; get; }
        public int total { set; get; }
        public DateTime CreateAt { set; get; } 

        
    }
}
