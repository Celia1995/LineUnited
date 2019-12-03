using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public UiManager uiManager;
    bool IsGamePaused = false;

    public void ResumeGame()
    {
        IsGamePaused = false;
        uiManager.SetActivePausePanel(false);
        Time.timeScale = 1f;
    }
    
    public void PauseGame()
    {
        IsGamePaused = true;
        uiManager.SetActivePausePanel(true);
        Time.timeScale = 0;

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
 