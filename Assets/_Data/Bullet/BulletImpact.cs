using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.bulletCtrl.Shooter) return;
        this.bulletCtrl.DamageSender.Send(other.transform);
    }
}
