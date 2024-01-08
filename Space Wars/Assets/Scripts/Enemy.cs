using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int start_hitpoints;
    public int start_strength;
    public float start_speed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Floor"))
        {
            GameData.PlayerHealth--;
            Debug.Log("Player health: " + GameData.PlayerHealth.ToString());
            Destroy(this.gameObject);
        }
    }
}
