using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemFactory = new ItemFactory();

            itemFactory.GenerateItems();
            itemFactory.SaveItems("items.csv");
        }
    }
}
