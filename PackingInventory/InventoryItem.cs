using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingInventory
{
    public class InventoryItem
    {
        public float Weight { get; set; }
        public float Volume { get; set; }

        public InventoryItem(float weight, float volume)
        {
            Weight = weight;
            Volume = volume;
        }

    }
}
