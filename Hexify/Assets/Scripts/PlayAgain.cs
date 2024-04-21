using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
    {
    public AudioSource ClickSound;
    public void OPenColorSelector()
    {
        Debug.Log("ColorSelector");
        SceneManager.LoadScene("ColorSelector");
    }
    public void OPenMainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
    public void Retry()
    {
        ClickSound.Play(0);
        Invoke("OPenColorSelector", 0.2f);
    }
    public void Menu()
    {
        ClickSound.Play(0);
        Invoke("OPenMainMenu", 0.2f);
    }
}
