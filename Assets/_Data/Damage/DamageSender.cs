using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MyMonoBehaviour
{
    [SerializeField] protected float damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        Debug.Log("sendmg");
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
        this.DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
