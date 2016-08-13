using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class InventoryItems
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool CraftItem { get; set; } //whether or not item is a crafting ingredient

    public InventoryItems(int id, string name, bool craftItem)
    {
        ID = id;
        Name = name;
        CraftItem = craftItem;
    }
}

