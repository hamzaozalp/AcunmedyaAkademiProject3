﻿namespace AcunmedyaAkademiProject3.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product()
        {
            ProductName = string.Empty;
            ProductDescription = string.Empty;
            ProductImageUrl = string.Empty;
            Category = new Category();
        }
    }
}