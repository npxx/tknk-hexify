using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource ClickSound;
    public void OPenMainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
    public void OPenGameSpecification()
    {
        Debug.Log("GameSpecification");
        SceneManager.LoadScene("GameSpecification");
    }
    public void OPenInstruction()
    {
        Debug.Log("Instructions");
        SceneManager.LoadScene("Instructions");
    }
    public void StartGame()
    {
        ClickSound.Play(0);
        Invoke("OPenGameSpecification",0.2f) ;
    }

    public void Instructions()
    {
        ClickSound.Play(0);
        Invoke("OPenInstruction",0.2f);
    }
    public void Exit()
    {
        ClickSound.Play(0);
        Debug.Log("Quit");
        Application.Quit();

    }
    public void MainMenuOpen() 
    { 
        ClickSound.Play(0);
        Invoke("OPenMainMenu", 0.2f);
    }
}

