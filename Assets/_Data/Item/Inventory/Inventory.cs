using System.Collections.Generic;
using UnityEngine;

public class Inventory : MyMonoBehaviour
{
    [SerializeField] protected int maxSlots = 70;
    [SerializeField] protected int maxAddCount = 999;
    [SerializeField] protected List<ItemInventory> items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.IronOre, 12);
        //this.AddItem(ItemCode.CopperSword, 3);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        if (addCount > this.maxAddCount) Debug.LogError("Can't add too many item, max: " + this.maxAddCount);

        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);
        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxAddCount; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                itemExist = this.CreateDummyItem(itemProfile);
                this.items.Add(itemExist);
            }
            newCount = itemExist.itemCount + addRemain;
            itemMaxStack = this.GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                newCount = itemMaxStack;
            }
            itemExist.itemCount = newCount;
            addRemain -= newCount;
            if (addRemain < 1) break;
        }
        return true;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        List<ItemInventory> matchingItems = this.items.FindAll((item) => item.itemProfile.itemCode == itemCode);
        foreach (var itemInventory in matchingItems)
        {
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;

        }
        return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;
        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    protected virtual ItemInventory CreateDummyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };
        return itemInventory;
    }

    protected virtual bool AddResource(ItemInventory itemInventory, int addCount)
    {
        Debug.Log("Add Resource");
        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;
        itemInventory.itemCount = newCount;
        return true;
    }

    protected virtual bool AddEquipment(ItemInventory itemInventory)
    {
        Debug.Log("Add Equipment");
        itemInventory.itemCount = 1;
        return true;
    }

    public virtual bool DeductItem(ItemCode itemCode, int minusCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - minusCount;
        if (newCount < 0) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool TryDeductItem(ItemCode itemCode, int minusCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - minusCount;
        if (newCount < 0) return false;
        return true;
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
