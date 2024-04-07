using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    private void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        Transform prefabsObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj) { 
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
}
