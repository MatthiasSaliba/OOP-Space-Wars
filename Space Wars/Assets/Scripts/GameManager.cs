using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Text playerScoreText;

    [SerializeField] Text healthText;

    SaveLoadManager mySaveLoadManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mySaveLoadManager = new SaveLoadManager();
        GameData.Score = 0;
        GameData.PlayerHealth = 10;
        mySaveLoadManager.LoadData();
        playerScoreText.text = "Score: " + GameData.Score.ToString();
        healthText.text = "Health: " + GameData.PlayerHealth.ToString();
    }

    public void OnEnemyDie()
    {
        GameData.Score++;
        playerScoreText.text = "Score: " + GameData.Score.ToString();
        mySaveLoadManager.SaveData();
        if (SceneManager.GetActiveScene().name.Contains("Level1"))
        {
            if (GameData.Score >= 30)
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }

    public void PlayerDamage()
    {
        GameData.PlayerHealth--;
        mySaveLoadManager.SaveData();
        healthText.text = "Health: " + GameData.PlayerHealth.ToString();
        if (GameData.PlayerHealth <= 0)
        {
            //mySaveLoadManager.DeleteFile();
            SceneManager.LoadScene("GameOver");
        }
    }
}
