using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CalcGains.Model;
using CsvHelper;
using CsvHelper.Configuration;

namespace CalcGains.Services
{
    public static class ProductsSaver<T> where T : Product
    {
        public static void SaveToCsv(T product)
        {
            using (TextWriter writer = new StreamWriter("Products.csv", true))
            {
                var csvWriter = new CsvWriter(writer);
                csvWriter.WriteField(product.Name);
                csvWriter.WriteField(product.Calories);
                csvWriter.WriteField(product.Protein);
                csvWriter.WriteField(product.Fat);
                csvWriter.WriteField(product.Carbs);
                csvWriter.NextRecord();
                writer.Flush();
            }
        }

        public static List<Product> LoadFromCsv()
        {
            List<Product> result = new List<Product>();
            using (TextReader reader = new StreamReader("Products.csv"))
            {
                var csvReader = new CsvReader(reader);
                Product value;
                csvReader.Configuration.HasHeaderRecord = false;
                while (csvReader.Read())
                {
                    value = new Product(csvReader.GetField(0), Double.Parse(csvReader.GetField(1)), Double.Parse(csvReader.GetField(2)), Double.Parse(csvReader.GetField(3)), Double.Parse(csvReader.GetField(4)));
                    result.Add(value);
                }
            }
            return result;
        }
    }
}
