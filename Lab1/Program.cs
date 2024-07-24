using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int productCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string productName = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                float productSum = Convert.ToSingle(Console.ReadLine());
                products[i] = new Product() { ProductCode = productCode, ProductName = productName, ProductSum = productSum };

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(products, options);

                using (StreamWriter sw = new StreamWriter("../../../Products.json"))
                {
                    sw.WriteLine(jsonString);
                }

            }
        }
    }
}
