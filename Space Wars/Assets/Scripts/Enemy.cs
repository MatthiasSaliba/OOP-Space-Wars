using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitpoints;
    public int start_strength;
    public float start_speed;
    
    private int _strength;
    
    void Start()
    {
        _strength = start_strength;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Floor"))
        {
            GameData.PlayerHealth--;
            Debug.Log("Player health: " + GameData.PlayerHealth.ToString());
            Destroy(this.gameObject);
        }
        
        if (other.gameObject.tag=="Laser")
        {
            _strength--;
            if (_strength <= 0)
            {
                GameData.Score += hitpoints;
                Debug.Log("Score: " + GameData.Score.ToString());
                Destroy(this.gameObject);
            }
        }
    }
}
