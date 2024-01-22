using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] List<Button> buttons; // List of buttons
    SaveLoadManager mySaveLoadManager; // SaveLoadManager instance

    // Start is called before the first frame update
    void Start()
    {
        mySaveLoadManager = new SaveLoadManager(); // Instantiate SaveLoadManager
        foreach (var button in buttons)
        {
            // Assuming button names are "Start", "Exit", "Highscore" for respective functionality
            if (button.name == "Start")
            {
                button.onClick.AddListener(StartGame);
            }
            else if (button.name == "Exit")
            {
                button.onClick.AddListener(QuitGame);
            }
            else if (button.name == "Highscore")
            {
                button.onClick.AddListener(ViewHighscore);
            } 
            else if (button.name == "Home")
            {
                button.onClick.AddListener(GoHome);
            }

            // Add a generic listener for all buttons
            button.onClick.AddListener(() => PrintMsg(button.name));
        }
    }

    void StartGame()
    {
        Debug.Log("You have clicked the start button");
        SceneManager.LoadScene("Level1");
        mySaveLoadManager.DeleteFile();
    }
    
    void ViewHighscore()
    {
        Debug.Log("You have clicked the highscore button");
        SceneManager.LoadScene("Highscore");
    }

    void GoHome()
    {
        Debug.Log("You have clicked the home button");
        SceneManager.LoadScene("WelcomeScene");
    }

    void QuitGame()
    {
        Debug.Log("You have clicked the exit button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
    }

    void PrintMsg(string buttonName)
    {
        Debug.Log(buttonName + " has been clicked");
    }
}

