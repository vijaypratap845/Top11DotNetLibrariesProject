﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONNewtonSoft
{
    public class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
    public class Program
    {
        public void GetData()
        {
            Product product = new Product();

            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            string output = JsonConvert.SerializeObject(product);
            //{
            //  "Name": "Apple",
            //  "ExpiryDate": "2008-12-28T00:00:00",
            //  "Price": 3.99,
            //  "Sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}
            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
            Console.WriteLine(output);
            Console.WriteLine(deserializedProduct.Name);
            Console.ReadLine();
           
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetData();
        }
    }
}
