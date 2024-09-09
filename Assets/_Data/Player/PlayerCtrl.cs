using UnityEngine;

public class PlayerCtrl : MyMonoBehaviour
{
    private static PlayerCtrl instance;

    public static PlayerCtrl Instance => instance;

    [SerializeField] protected ShipCtrl currentShip;

    public ShipCtrl CurrentShip => currentShip;

    [SerializeField] protected PlayerPickup playerPickup;

    public PlayerPickup PlayerPickup => playerPickup;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl is allowed to exist!");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + " LoadPlayerPickup", gameObject);
    }
}
