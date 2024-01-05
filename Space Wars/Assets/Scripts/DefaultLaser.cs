using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DefaultLaser : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {     
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
    
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    
}
