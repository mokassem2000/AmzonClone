﻿using AmazonClone.DAL.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AmazonClone.Models;

namespace AmazonClone.DAL.AmazonContext
{
    public class AmazonContext:IdentityDbContext
    {
        public AmazonContext(DbContextOptions<AmazonContext> opts) : base(opts) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;initial catalog=AmazonClon");
        //}
        public DbSet<Order> orders { set; get; }
        public DbSet<Product> products { set; get; }
        public DbSet<OrderdItem> OoderItems { set; get; }
        public DbSet<Category> categories { set; get; }
        public DbSet<AmazonClone.Models.ProductVM> ProductVM { get; set; }
        public DbSet<AmazonClone.Models.RoleVM> RoleVM { get; set; }

    }
}
