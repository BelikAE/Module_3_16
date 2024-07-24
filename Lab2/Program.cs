using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using(StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }

            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            
            Product maxProduct = products[0];
            foreach(Product product in products)
            {
                if (product.ProductSum > maxProduct.ProductSum)
                {
                    maxProduct = product;
                }

            }
            Console.WriteLine($"{maxProduct.ProductCode} {maxProduct.ProductName} {maxProduct.ProductSum}");
            Console.ReadKey();

        }
    }
}
