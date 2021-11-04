using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Ex02.Entities;

namespace Ex02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var employees = new List<Employee>();
            Console.Write("Enter full file path: ");
            var path = Console.ReadLine();
            Console.Write("Enter Salary: ");
            var salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (File.Exists(path) && path != null)
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var fields = reader.ReadLine().Split(',');

                        employees.Add(new Employee(fields[0], fields[1],
                            double.Parse(fields[2], CultureInfo.InvariantCulture)));
                    }
                }

                var emails = employees.Where(e => e.Salary > salary).OrderBy(e => e.Email).Select(e => e.Email);
                var salarySum = employees.Where(e => e.Name.StartsWith("M")).Sum(e => e.Salary);

                Console.WriteLine(
                    $"Email of people whose salary is more than {salary.ToString("C", CultureInfo.GetCultureInfo("pt-br"))} ");
                foreach (var email in emails)
                {
                    Console.WriteLine(email);
                }

                Console.WriteLine($"Sum of salary of people whose name starts with 'M': {salarySum.ToString("C", CultureInfo.GetCultureInfo("pt-br"))}");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}