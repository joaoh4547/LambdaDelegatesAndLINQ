using System.Globalization;

namespace LINQ.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}," +
                $" Nome:{Name}" +
                $" Preço: {Price.ToString("C", CultureInfo.GetCultureInfo("pt-br"))}," +
                $" Categoria: {Category.Name} - {Category.Tier}";
        }
    }
}   