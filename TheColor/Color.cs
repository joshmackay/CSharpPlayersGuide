using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheColor
{
    public class Color
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static Color White { get; set; } = new Color(255, 255, 255);

        public static Color Black { get; set; } = new Color(0, 0, 0);

        public static Color Red { get; set; } = new Color(255, 0, 0);

        public static Color Orange { get; set; } = new Color(255, 165, 0);

        public static Color Yellow { get; set; } = new Color(255, 255, 0);

        public static Color Green { get; set; } = new Color(0, 128, 0);

        public static Color Blue { get; set; } = new Color(0, 0, 255);

        public static Color Purple { get; set; } = new Color(128, 0, 128);

    }
}
