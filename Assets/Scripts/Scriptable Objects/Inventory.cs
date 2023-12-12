using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    //public int numberOfKeys;
    public int amountOfCoins;
    public int amountOfArrows;
    public bool keyInInventory = false;
    public bool dungeonKeyInInventory = false;
    public bool foundEmerald = false;
    public bool foundRuby = false;
    public bool foundSaphire = false;
    public bool foundDiamond = false;
    public SignalSender powerUpSignal;
    public SignalSender powerUpSignal2;
    public bool swordRiddleSolved = false;

    public bool CheckForItem(Item item)
    {
        if(items.Contains(item))
        {
            return true;
        }
        return false;
    }

    public void AddItem(Item itemToAdd)
    {
        if(itemToAdd.isKey)
        {
            keyInInventory = true;
            //numberOfKeys++;
        }
        if(itemToAdd.isDungeonKey)
        {
            dungeonKeyInInventory = true;
        }
        if(itemToAdd.isCoin)
        {
            amountOfCoins++;
            powerUpSignal.Raise();
        }
        if(itemToAdd.isArrow)
        {
            if(amountOfArrows >= 3)
            {
                amountOfArrows = 6;
            }
            else
            {
                amountOfArrows += 3;
            }
            powerUpSignal2.Raise();
        }
        else
        {
            if(!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
