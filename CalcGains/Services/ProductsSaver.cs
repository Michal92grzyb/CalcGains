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
    public static class ProductsSaver
    {
        public static void SaveToCsv(List<Product> products)
        {
            using (TextWriter writer = new StreamWriter("Products.csv", false))
            {
                var csvWriter = new CsvWriter(writer);
                csvWriter.Configuration.Delimiter = "\t";
                foreach (Product product in products)
                {
                    csvWriter.WriteField(product.Name);
                    csvWriter.WriteField(product.Calories);
                    csvWriter.WriteField(product.Protein);
                    csvWriter.WriteField(product.Fat);
                    csvWriter.WriteField(product.Carbs);
                    csvWriter.NextRecord();
                }
                writer.Flush();
            }
        }

        public static List<Product> LoadFromCsv()
        {
            List<Product> result = new List<Product>();
            using (TextReader reader = new StreamReader("Products.csv"))
            {
                var csvReader = new CsvReader(reader);
                csvReader.Configuration.Delimiter = "\t";
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

        public static void SaveMealsToCsv(Meal meal)
        {
            using (TextWriter writer = new StreamWriter("Meals.csv", true))
            {
                var csvWriter = new CsvWriter(writer);
                csvWriter.Configuration.Delimiter = "\t";
                foreach (Component component in meal.Components)
                {
                    csvWriter.WriteField(component.Product.Name);
                    csvWriter.WriteField(component.Product.Calories);
                    csvWriter.WriteField(component.Product.Protein);
                    csvWriter.WriteField(component.Product.Fat);
                    csvWriter.WriteField(component.Product.Carbs);
                    csvWriter.NextRecord();
                }
                csvWriter.NextRecord();
                writer.Flush();
            }
        }
    }
}
