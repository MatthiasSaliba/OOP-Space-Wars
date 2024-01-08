using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : DefaultLaser
{
    // Start is called before the first frame update
    protected override void OnEnable()
    {
        speed = 30f;
        base.OnEnable();
        rb.drag = 0.5f;
    }
}
