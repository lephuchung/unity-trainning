using System;
using UnityEngine;

public enum ItemCode
{
    NoItem = 0,
    IronOre = 1,
    GoldOre = 2,
    TitanOre = 3,
    CopperSword = 4,
}

public class ItemCodeParse
{
    public static ItemCode FromString(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
}