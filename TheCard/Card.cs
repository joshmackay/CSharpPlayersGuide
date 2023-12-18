using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    internal class Card
    {
        public Color Color { get; set; }
        public Rank Rank { get; set; }
        public Card(Color color, Rank rank)
        {
            Color = color;
            Rank = rank;
        }
    }
}
