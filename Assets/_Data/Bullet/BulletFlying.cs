using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlying : MonoBehaviour
{
    [SerializeField] protected int movespeed = 10;
    [SerializeField] protected Vector3 direction = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}
