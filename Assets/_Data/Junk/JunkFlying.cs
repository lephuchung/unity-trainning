using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFlying : ParentFlying
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 0.5f;
    }
}
