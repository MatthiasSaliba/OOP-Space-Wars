using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject laser1prefab;
    LaserFiring _firingInstance;

    [SerializeField] private float movementSpeed = 2f;
    private Vector2 movementDirection;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _firingInstance = GetComponentInChildren<LaserFiring>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PointAtMouse();
        
        if (Input.GetMouseButtonDown(0)) 
        {
            _firingInstance.FireLaser(laser1prefab);
        }
        
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }

    void PointAtMouse()
    {
        Quaternion newrotation = Quaternion.LookRotation(this.transform.position - GameData.MousePosition, Vector3.forward);
        newrotation.x = 0f;
        newrotation.y = 0f;
        newrotation.z = newrotation.z;
        newrotation.w = newrotation.w;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newrotation, Time.deltaTime * 5f);
    }
}
