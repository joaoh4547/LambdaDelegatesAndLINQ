using System;
using System.Globalization;

namespace DelegatesAndLambda.Entities
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }


        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Name}, Preço: {Price.ToString("C", CultureInfo.GetCultureInfo("pt-br"))} ";
        }

        public int CompareTo(Product other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}