using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSpecification : MonoBehaviour
{
    public AudioSource ClickSound;
    public static int Gamediff;
    public static string gr;
    public static int GridSize;
    public void OPenColorSelector()
    {
        Debug.Log("ColorSelector");
        SceneManager.LoadScene("ColorSelector");
    }
    public void Update()
    {
        gr = GameObject.Find("Label").GetComponent<TextMeshProUGUI>().text;

        GridSize = int.Parse(gr);
    }
    public void DiffEasy()
    {
        ClickSound.Play(0);
        Gamediff = 0;
        Invoke("OPenColorSelector", 0.2f);
    }
    public void DiffMedium()
    {
        ClickSound.Play(0);
        Gamediff = 1;
        Invoke("OPenColorSelector", 0.2f);
    }
    public void DiffHard()
    {
        ClickSound.Play(0);
        Gamediff = 2;
        Invoke("OPenColorSelector", 0.2f);
    }
}
