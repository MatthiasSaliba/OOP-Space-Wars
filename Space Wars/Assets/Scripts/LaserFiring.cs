using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFiring : MonoBehaviour
{
    public void FireLaser(GameObject myLaser)
    {
        if (myLaser != null)
        {
            Instantiate(myLaser, this.transform.position, this.transform.rotation);
        }
    }
}
