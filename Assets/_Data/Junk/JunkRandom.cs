using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JunkRandom : MyMonoBehaviour
{
    [SerializeField] protected JunkSpawnCtrl JunkSpawnCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnCtrl();
    }

    protected virtual void LoadJunkSpawnCtrl()
    {
        if (this.JunkSpawnCtrl != null) return;
        this.JunkSpawnCtrl = GetComponent<JunkSpawnCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.JunkSpawnCtrl.JunkSpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.JunkSpawnCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);

    }
}
