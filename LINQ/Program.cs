using System;
using System.Linq;

namespace LINQ
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            
            // Fonte de Dados
            var numbers = new int[] {2, 3, 4, 5,6};
            
            
            // expressão 
            var result = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10)
                .ToList();
            
            // Executar a consulta 

            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
        }
    }
}