using UnityEngine;

public class DamageSender : MyMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateImpactFX();
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

    protected virtual void CreateImpactFX()
    {
        string fxName = this.GetImpactFx();

        Vector3 hitPosition = transform.position;
        Quaternion hitRotation = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPosition, hitRotation);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string GetImpactFx()
    {
        return FXSpawner.impact1;
    }
}
