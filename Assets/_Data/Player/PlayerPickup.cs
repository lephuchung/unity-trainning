using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickUp(ItemPickupable itemPickupable)
    {
        Debug.Log("ItemPickup");
        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
