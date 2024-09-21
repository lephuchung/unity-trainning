using UnityEngine;

public class JunkSpawnCtrl : MyMonoBehaviour
{
    [Header("Junk Spawn Ctrl")]
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkSpawnPoint junkSpawnPoint;
    public JunkSpawnPoint JunkSpawnPoint { get => junkSpawnPoint; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) { return; }
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ":LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.junkSpawnPoint != null) { return; }
        this.junkSpawnPoint = Transform.FindObjectOfType<JunkSpawnPoint>();
        Debug.Log(transform.name + ":LoadSpawnPoint", gameObject);
    }
}
