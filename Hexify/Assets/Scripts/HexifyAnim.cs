using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexifyAnim : MonoBehaviour
{
    public Sprite wog, wg;
    int framecount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        framecount++;
        if (framecount >= 50 && framecount <= 200)
        {
            this.gameObject.GetComponent<Image>().sprite = wg;
        }
        else
        {
            framecount %= 300;
            this.gameObject.GetComponent<Image>().sprite = wog;
        }


    }
}
