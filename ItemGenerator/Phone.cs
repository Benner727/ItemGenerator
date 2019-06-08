using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemGenerator
{
    class Phone
    {
        public readonly string Index;
        public readonly string Model;

        public Phone(string index, string model)
        {
            Index = index;
            Model = model;
        }
    }
}
