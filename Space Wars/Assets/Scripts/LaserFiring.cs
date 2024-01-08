using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFiring : MonoBehaviour
{
    public void FireLaser(GameObject myLaser)
    {
        if (myLaser != null)
        {
            myLaser.transform.position = this.transform.position;
            myLaser.transform.rotation = this.transform.rotation;
            myLaser.SetActive(true);
        }
    }
}
