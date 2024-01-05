using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject laser1prefab;
    LaserFiring _firingInstance;
    // Start is called before the first frame update
    void Start()
    {
        _firingInstance = GetComponentInChildren<LaserFiring>();
    }

    // Update is called once per frame
    void Update()
    {
        PointAtMouse();
        
        if (Input.GetMouseButtonDown(0)) 
        {
            _firingInstance.FireLaser(laser1prefab);
        }
    }

    void PointAtMouse()
    {
        Quaternion newrotation = Quaternion.LookRotation(this.transform.position - GameData.MousePosition, Vector3.forward);
        newrotation.x = 0f;
        newrotation.y = 0f;
        newrotation.z = newrotation.z;
        newrotation.w = newrotation.w;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newrotation, Time.deltaTime * 3f);
    }
}
