﻿using Microsoft.EntityFrameworkCore;

namespace FoodWoodz.DAL.Model
{
    public class RestaurantDataContext : DbContext
    {
        public RestaurantDataContext(DbContextOptions<RestaurantDataContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> addresses { get; set; }



    }
}
