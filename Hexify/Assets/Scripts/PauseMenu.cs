using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GIP = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Button pb;
    public Button resume_g;
    public Button retry_g;
    public Button quit_g;

    void OnEnable()
    {
        //Register Button Events
        pb.onClick.AddListener(() => buttonCallBack(pb));
        resume_g.onClick.AddListener(() => buttonCallBack(resume_g));
        retry_g.onClick.AddListener(() => buttonCallBack(retry_g));
        quit_g.onClick.AddListener(() => buttonCallBack(quit_g));
        pb.enabled = true;

    }

    public GameObject PM;
    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == pb)
        {
            Debug.Log("Clicked: " + buttonPressed.name);
            //PM = GameObject.Find("PauseMenu");
            PM.SetActive(true);
            pb.enabled = false;
            Time.timeScale = 0;
        }
        else if (buttonPressed == resume_g)
        {
            Debug.Log("Clicked: " + buttonPressed.name);
            PM.SetActive(false);
            pb.enabled = true;
            Time.timeScale = 1;
        }
        else if (buttonPressed == retry_g)
        {
            Debug.Log("Clicked: " + buttonPressed.name);
            Time.timeScale = 1;
            SceneManager.LoadScene("Win");
            SceneManager.LoadScene("MainMenu");
        }
        else if (buttonPressed == quit_g)
        {
            Debug.Log("Clicked: " + buttonPressed.name);
            Application.Quit();
        }



    }

}
