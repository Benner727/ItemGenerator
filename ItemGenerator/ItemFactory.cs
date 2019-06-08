using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ItemGenerator
{
    class ItemFactory
    {
        private List<Phone> _phoneList = new List<Phone>();
        private List<Product> _productList = new List<Product>();
        private List<Color> _colorList = new List<Color>();

        public List<Item> ItemList = new List<Item>();

        public ItemFactory()
        {
            LoadPhones("phones.txt");
            LoadProducts("products.txt");
            LoadColors("colors.txt");
            LoadDesigns("designs.txt");
        }

        void LoadPhones(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    _phoneList.Add(new Phone(line.Substring(0, 4), line.Substring(5).ToUpper()));
                }
            }
            catch
            {
                throw new FileNotFoundException("Error: " + filePath + " does not exist.");
            }
        }

        void LoadProducts(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var values = line.Split(',').Select(sValue => sValue.Trim()).ToArray();
                    _productList.Add(new Product(values[0], values[1], values[2],
                        float.Parse(values[3]), float.Parse(values[4]),
                        bool.Parse(values[5]), bool.Parse(values[6]), bool.Parse(values[7])));
                }
            }
            catch
            {
                throw new FileNotFoundException("Error: " + filePath + " does not exist.");
            }
        }

        void LoadColors(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    for (var i = 0; i < 3; ++i)
                    {
                        _colorList.Add(new Color(line.Substring(0, 2), line.Substring(3), (ColorType)Enum.Parse(typeof(ColorType), i.ToString())));
                    }
                }

            }
            catch
            {
                throw new FileNotFoundException("Error: " + filePath + " does not exist.");
            }
        }

        void LoadDesigns(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    _colorList.Add(new Color(line.Substring(0, 2), line.Substring(3), ColorType.Design));

                }
            }
            catch
            {
                throw new FileNotFoundException("Error: " + filePath + " does not exist.");
            }
        }

        public void GenerateItems()
        {
            foreach (var phone in _phoneList)
            {
                foreach (var product in _productList)
                {
                    if (product.Category == "PROTECTIVE")
                    {
                        foreach (var color in _colorList)
                        {
                            if ((product.SubClass == "ARMOR BOX" || product.SubClass == "CLIP")
                                && color.ColorType != ColorType.Solid)
                                continue;

                            ItemList.Add(new Item(phone, product, color));
                        }
                    }
                    else if (product.Category == "SCREEN CARE")
                    {
                        ItemList.Add(new Item(phone, product));
                    }
                }
            }

            if (ItemList.Count != ItemList.Distinct().Count())
            {
                // Duplicates exist
                throw new InvalidOperationException("Error: Duplicate Items Found.");
            }
        }

        public void SaveItems(string filePath)
        {
            try
            {
                using (var file = File.CreateText(filePath))
                {
                    file.WriteLine("Item Number,Product Line,Category,SubClass,Item Description,Price,Cost,Tangible?,Serial?,Tax?");

                    foreach (var item in ItemList)
                    {
                        file.WriteLine(item);
                    }
                }
            }
            catch
            {
                throw new InvalidOperationException("Error: Unable to save items to csv.");
            }
        }
    }
}
