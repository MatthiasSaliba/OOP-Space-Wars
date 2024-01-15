using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TakingDamage
{
    public void ApplyDamage(int hitpoints);
}

public class Enemy : MonoBehaviour
{
    public int hitpoints;
    public int start_strength;
    public float start_speed;
    
    public int _strength;
    
    void Start()
    {
        _strength = start_strength;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Floor"))
        {
            //GameData.PlayerHealth--;
            //Debug.Log("Player health: " + GameData.PlayerHealth.ToString());
            GameManager.Instance.PlayerDamage();
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
            GetComponent<TakingDamage>().ApplyDamage(hitpoints);
        }
    }
}
