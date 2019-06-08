using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemGenerator
{
    class Product
    {
        public readonly string ProductLine;
        public readonly string Category;
        public readonly string SubClass;
        public readonly float Price;
        public readonly float Cost;
        public readonly bool Tangible;
        public readonly bool Serialized;
        public readonly bool Taxed;

        public Product(string productLine, string category, string subClass,
            float price, float cost,
            bool tangible = true, bool serialized = true, bool taxed = true)
        {
            ProductLine = productLine;
            Category = category;
            SubClass = subClass;
            Price = price;
            Cost = cost;
            Tangible = tangible;
            Serialized = serialized;
            Taxed = taxed;
        }
    }
}
