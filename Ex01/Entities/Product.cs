﻿using System.Globalization;

namespace Ex01.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Nome: {Name}, Price: {Price.ToString("C", CultureInfo.GetCultureInfo("pt-br"))}";
        }
    }
}