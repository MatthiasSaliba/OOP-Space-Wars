using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject laser1prefab;
    [SerializeField] GameObject laser2prefab;
    LaserFiring _firingInstance;

    [SerializeField] private float movementSpeed = 2f;
    private Vector2 movementDirection;
    private Rigidbody2D rb;

    [SerializeField] private float laserFiringPeriod1;
    [SerializeField] private float laserFiringPeriod2;
    Coroutine myFiringCoroutine1, myFiringCoroutine2;
    
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
            if (myFiringCoroutine1 == null)
            {
                myFiringCoroutine1 = StartCoroutine(fireContinuously(laser1prefab));
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(myFiringCoroutine1);
            myFiringCoroutine1 = null;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            _firingInstance.FireLaser(laser2prefab);
            if (myFiringCoroutine2 == null) myFiringCoroutine2 = StartCoroutine(specialFire(laser2prefab));
        }
        if (Input.GetMouseButtonUp(1))
        {
            StopCoroutine(myFiringCoroutine2);
            myFiringCoroutine2 = null;
        }
        
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(this.transform.position.x, GameData.XMin, GameData.XMax);
        playerPos.y = Mathf.Clamp(this.transform.position.y, GameData.YMin, GameData.YMax);
        transform.position = playerPos;
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed * Time.fixedDeltaTime;
    }
    
    IEnumerator fireContinuously(GameObject mybulletPrefab)
    {
        while (true)
        {
            _firingInstance.FireLaser(mybulletPrefab);
            yield return new WaitForSeconds(laserFiringPeriod1);
        }
    }
    
    IEnumerator specialFire(GameObject mybulletPrefab)
    {
        while (true)
        {
            _firingInstance.FireLaser(mybulletPrefab);
            yield return new WaitForSeconds(laserFiringPeriod2);
        }
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
