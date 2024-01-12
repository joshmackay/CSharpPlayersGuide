using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingInventory
{
    public class Pack
    {
        public int MaxWeight { get; }
        public int MaxVolume { get; }
        public int MaxItems { get; }
        public InventoryItem[] Items { get; set; }

        public int ItemCount { get; private set; } = 0;
        public float CurrentItemWeight { get; private set; } = 0f;
        public float CurrentItemVolume { get; private set; } = 0f;

        public Pack(int maxWeight, int maxVolume, int maxItems)
        {
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            MaxItems = maxItems;
            Items = new InventoryItem[maxItems];
        }

        public bool Add(InventoryItem item)
        {
            if (CurrentItemWeight + item.Weight > MaxWeight ||
                CurrentItemVolume + item.Volume > MaxVolume ||
                ItemCount >= MaxItems)
            {
                return false;
            }
            else
            {
                Items[ItemCount] = item;
                ItemCount++;
                CurrentItemVolume += item.Volume;
                CurrentItemWeight += item.Weight;
                return true;
            }
        }
    }
}
