using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlying : ParentFlying
{
    protected override void ResetValue()
    {
        base.ResetValue(); 
        this.moveSpeed = 10f;
    }
}
