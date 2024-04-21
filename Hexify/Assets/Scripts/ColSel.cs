using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColSel : MonoBehaviour
{
    public static int playID;
    public AudioSource click;

    public void OPenMainGame() 
    {
        SceneManager.LoadScene("Main Game"); 
    }

      public void BlackClick()
        {
            click.Play();
            Debug.Log("Blekkk Sprite Clicked");
            playID = 0;
            Invoke("OPenMainGame", 0.2f);
        }
        
      public void WhiteClick()
        {
            click.Play();
            Debug.Log("Whiteeee");
            playID = 1;
            Invoke("OPenMainGame", 0.2f);
        }
    }



