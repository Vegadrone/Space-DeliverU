using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Transform playButton;
    Transform quitButton;
    AudioSource playButtonSound;
    AudioSource quitButtonSound;


    private void Start() 
    {   
        playButton = this.gameObject.transform.GetChild(0);
        quitButton = this.gameObject.transform.GetChild(1);
        playButtonSound = playButton.GetComponent<AudioSource>();
        quitButtonSound = quitButton.GetComponent<AudioSource>();
    }
    public void PlayGame()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playButtonSound.Play();
    }
    public void QuitGame()
    {  
        quitButtonSound.Play();
        Application.Quit();
    }
}
