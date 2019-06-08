using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemGenerator
{
    public enum ColorType
    {
        Solid,
        Bling,
        Glitter,
        Design
    }

    class Color
    {
        public readonly string Index;
        public readonly string Name;
        public readonly ColorType ColorType;

        public Color(string index, string name, ColorType colorType)
        {
            Index = index;
            Name = name;
            ColorType = colorType;
        }
    }
}
