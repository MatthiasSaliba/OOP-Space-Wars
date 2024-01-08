using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLaser : DefaultLaser
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SpecialFire();
        
    }
    
    protected void SpecialFire()
    {
        rb.drag = 0.1f;
    }
}
