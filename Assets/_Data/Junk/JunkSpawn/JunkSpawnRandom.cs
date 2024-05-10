using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnRandom : MyMonoBehaviour
{
    [Header("Junk Spawn Random")]
    [SerializeField] protected JunkSpawnCtrl junkSpawnCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnCtrl();
    }

    protected virtual void LoadJunkSpawnCtrl()
    {
        if (this.junkSpawnCtrl != null) return;
        this.junkSpawnCtrl = GetComponent<JunkSpawnCtrl>();
        Debug.Log(transform.name + ": LoadJunkSpawnCtrl", gameObject);
    }

    protected override void Start()
    {
        // this.JunkSpawning();
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;

        Transform ranPoint = this.junkSpawnCtrl.JunkSpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkSpawnCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);
        // Invoke(nameof(this.JunkSpawning), 1f);

    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
