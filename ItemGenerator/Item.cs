using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemGenerator
{
    class Item
    {
        public string SKU { get; private set; }
        public string Description { get; private set; }

        public readonly Phone Phone;
        public readonly Product Product;
        public readonly Color Color;

        public Item(Phone phone, Product product, Color color = null)
        {
            Phone = phone;
            Product = product;
            Color = color;

            CreateSKU();
            CreateDescription();
        }

        public class Comparer : IEqualityComparer<Item>
        {
            public bool Equals(Item one, Item two)
            {
                if (one == null || two == null)
                    return false;

                return (one.SKU == two.SKU);
            }

            public int GetHashCode(Item obj)
            {
                if (obj == null)
                    return 0;

                return (obj.SKU == null ? 0 : obj.SKU.GetHashCode());
            }
        }

        void CreateSKU()
        {
            if (Product.ProductLine == "ACCESSORY")
                SKU = "1";

            if (Product.Category == "PROTECTIVE")
            {
                SKU += "1";

                if (Product.SubClass == "ARMOR BOX")
                    SKU += "0";
                else if (Product.SubClass == "SILICONE")
                    SKU += "1";
                else if (Product.SubClass == "WALLET")
                    SKU += "2";
                else if (Product.SubClass == "CLIP")
                    SKU += "3";

                switch (Color.ColorType)
                {
                    case ColorType.Solid:
                        SKU += "1";
                        break;
                    case ColorType.Bling:
                        SKU += "2";
                        break;
                    case ColorType.Glitter:
                        SKU += "3";
                        break;
                    case ColorType.Design:
                        SKU += "4";
                        break;
                }

                SKU += Phone.Index + Color.Index;
            }
            else if (Product.Category == "SCREEN CARE")
            {
                SKU += "2";

                if (Product.SubClass == "SCREEN")
                    SKU += "01";
                else if (Product.SubClass == "TEMPERED")
                    SKU += "11";

                SKU += Phone.Index + "00";
            }
        }

        void CreateDescription()
        {
            Description = Phone.Model + " " + Product.SubClass;

            if (Product.Category == "PROTECTIVE")
                Description += " - " + Color.ColorType.ToString().ToUpper() + " " + Color.Name;
        }

        public override string ToString()
        {
            return string.Join(",", SKU, 
                Product.ProductLine, Product.Category, Product.SubClass, 
                Description, Product.Price, Product.Cost,
                Product.Tangible, Product.Serialized, Product.Taxed);
        }
    }
}
