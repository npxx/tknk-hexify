using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGen : MonoBehaviour
{
    public GameObject hexTilePrefab;
    GridValue gv;
   
    public float tileXoffset=1.8f;
    float titleZoffset=1.565f;
    public int maplength;
     
    void Start()
    {
        maplength = GameSpecification.GridSize;
        maplength--;
        CreateHexTileMap();

        Bounds parentBounds = GetBounds(transform);
        Bounds windowBounds = GetWindowBounds();

        transform.localScale = new Vector3(
            windowBounds.size.y / parentBounds.size.z,
            transform.localScale.y,
            windowBounds.size.y / parentBounds.size.z
        );
    }

    void CreateHexTileMap()
    {
        GameObject checker;
        for(int z = -maplength;z<=maplength;z++){
            
            for(int x=-(maplength - Mathf.Abs(z)/2);x<=(maplength - Mathf.Abs(z)/2);x++)
            {

                if (z % 2 == 0)
                {
                    checker = Instantiate(hexTilePrefab, new Vector3(x * tileXoffset, 0, z * titleZoffset), Quaternion.identity, gameObject.transform);
                   gv = checker.GetComponent<GridValue>();
                   
                    
                    gv.z = -z;
                    if (gv.z >= 0)
                    {
                        gv.x = x + (int)gv.z/2 - 2*(int)(gv.z/2);
                    }
                    else
                    {
                        gv.x = x +(int)((-gv.z + 1)/2);
                    }
                    gv.y = -(gv.x + gv.z);
                    gv.x += maplength;
                    gv.y += maplength;
                    gv.z += maplength;
                  
                }
                else
                {
                    if (x != (maplength - Mathf.Abs(z) / 2))
                    {
                        checker =Instantiate(hexTilePrefab, new Vector3(x * tileXoffset + tileXoffset / 2, 0, z * titleZoffset), Quaternion.identity, gameObject.transform);
                        gv = checker.GetComponent<GridValue>();
                      
                        
                        gv.z = -z;
                        if (gv.z >= 0)
                        {
                            gv.x = x + (int)gv.z/2- 2*(int)(gv.z/2);
                        }
                        else
                        {
                            gv.x = x + (int)((-gv.z + 1)/2);
                        }
                        gv.y = -(gv.x + gv.z);
                        gv.x += maplength;
                        gv.y += maplength;
                        gv.z += maplength;

                    }
                }
            }
        }
    }

    private Bounds GetBounds(Transform transform)
    {
        Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
        Bounds bounds = new Bounds(transform.position, Vector3.zero);

        foreach (Renderer renderer in renderers)
            bounds.Encapsulate(renderer.bounds);

        return bounds;
    }

    private Bounds GetWindowBounds()
    {
        Camera camera = Camera.main;
        float distance = camera.transform.position.y;
        float height = 2f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float width = height * camera.aspect;
        Vector3 center = camera.transform.position + camera.transform.forward * distance;
        Vector3 size = new Vector3(width, height, 0f);
        Bounds bounds = new Bounds(center, size);

        return bounds;
    }
}
