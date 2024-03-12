using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   GameOverScreen gameOverScreen;
   WinScreen winScreen;

    void Start()
    {
        gameOverScreen = FindObjectOfType<GameOverScreen>();
        winScreen= FindObjectOfType<WinScreen>();
      

        gameOverScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
      
    }
    void LateUpdate()
    {
        if (winScreen.isWinScreenActive)
        {
            winScreen.gameObject.SetActive(true);
        }
        if (gameOverScreen.isGameOverScreenActive)
        {
           gameOverScreen.gameObject.SetActive(true); 
        }

    }

}
