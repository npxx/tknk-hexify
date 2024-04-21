using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridValue : MonoBehaviour
{
    // Start is called before the first frame update
    GridManager g1;
    public int n;
    public int x, y, z;
    void Start()
    {
        n = 0;
        g1 = GetComponentInParent<GridManager>();

        {

             
        }
       
    }


    
    public void setval(int n)
    {
        g1.grid[x, y, z] = n;
        for(int i = 0;i<(2*g1.n + 1);i++)
        {
            for (int j = 0; j < (2 * g1.n + 1); j++)
            {
                for (int k = 0; k < (2 * g1.n + 1); k++)
                {
                    g1.grid[i, j, k] = -g1.grid[i, j, k];
                }
            }
        }
    }

    private void Update()
    {
        n = g1.grid[x, y, z];
    }
}
