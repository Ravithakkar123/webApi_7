﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWoodz.DAL.Model
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int CurrentPrice { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public float Amount { get; set; }
        public int FoodItemId { get; set; }
        public FoodItem foodItem { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
