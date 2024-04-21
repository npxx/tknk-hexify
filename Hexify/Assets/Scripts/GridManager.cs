using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int n;
    public int[,,] grid;
    HexGen h1;
    public int player;
    void Start()
    {
        h1 = GetComponent<HexGen>();
        n = h1.maplength;
        grid = new int[2*n + 1,2*n + 1,2 * n + 1];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
