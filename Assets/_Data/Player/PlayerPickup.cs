public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickUp(ItemPickupable itemPickupable)
    {
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
