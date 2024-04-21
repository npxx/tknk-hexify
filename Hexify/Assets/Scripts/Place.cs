using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

struct ex
{
    Vector3 a;
        Vector3 b;
}
public class Place : MonoBehaviour
{
    public GameObject Prefab1;
    public GameObject PreFab2;
    private Camera view;
    public GridValue value;
    public GridManager gm;
    public GameObject g1;
    public static int numberOfPiecesLeft = 0;
    RaycastHit hit;
    float timer;
    public static int whoPlayer;

    public AudioSource InstantiateSound;
    // Start is called before the first frame update
    void Start()
    {
        timer = -2f;
        view = Camera.main;
        if (ColSel.playID == 0)
        {
            gm.player = 0;
        }
        else
        {
            gm.player = 1;
        }
        int n = gm.n + 1;
        numberOfPiecesLeft = 3 * n * n - 3 * n + 1;

    }

    void Update()

    {
        timer += Time.deltaTime;
        if (timer > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                timer = -2f;

                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 150f));
                Vector3 direction = worldMousePosition - Camera.main.transform.position;
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 150f))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    value = hit.collider.gameObject.GetComponentInParent<GridValue>();

                    if (value.n == 0)
                    {
                        //Debug.Log(value);
                        if (gm.player == 0)
                        {
                            InstantiateSound.Play(0);
                            Instantiate(Prefab1, new Vector3(hit.transform.position.x, hit.transform.position.y + 5, hit.transform.position.z), Quaternion.identity, g1.transform);
                            if (GameSpecification.Gamediff ==1)
                            { 
                            StartCoroutine(Medium(hit.transform.gameObject, 1));
                        }
                            if (GameSpecification.Gamediff == 0)
                            {
                                StartCoroutine(Easy(hit.transform.gameObject, 1));
                            }
                            whoPlayer = 0;
                        }
                        if (gm.player == 1)
                        {
                            InstantiateSound.Play(0);
                            Instantiate(PreFab2, new Vector3(hit.transform.position.x, hit.transform.position.y + 5, hit.transform.position.z), Quaternion.identity, g1.transform);
                            if (GameSpecification.Gamediff == 1)
                            {

                                StartCoroutine(Medium(hit.transform.gameObject, 0));
                            }
                            if (GameSpecification.Gamediff == 0)
                            {

                                StartCoroutine(Easy(hit.transform.gameObject, 0));
                            }
                            whoPlayer = 1;

                        }
                        numberOfPiecesLeft--;


                    }


                }
            }
        }
    }

    IEnumerator Easy(GameObject x, int i)
    {
       
 
        Debug.Log("ok");
        yield return new WaitForSeconds(1);
        Debug.Log("ok1");

        List<Vector3> list = new List<Vector3>();


        var colliders = Physics.OverlapSphere(x.transform.position, 1.5f);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.name == "default")
            {
                list.Add(new Vector3(collider.transform.parent.position.x, collider.transform.parent.position.y + 2f, collider.transform.parent.position.z));
                Debug.Log(collider.gameObject.transform.parent.localPosition);
                if (collider.gameObject.GetComponentInParent<GridValue>().n != 0)
                {
                    list.RemoveAt(list.Count - 1);
                }


            }
        }
        if (list.Count == 0)
        {
            var colliders1 = Physics.OverlapSphere(x.transform.position, 2f);
            foreach (var collider in colliders1)
            {
                if (collider.gameObject.name == "default")
                {
                    list.Add(new Vector3(collider.transform.parent.position.x, collider.transform.parent.position.y + 2f, collider.transform.parent.position.z));
                    Debug.Log(collider.gameObject.transform.parent.localPosition);
                    if (collider.gameObject.GetComponentInParent<GridValue>().n != 0)
                    {
                        list.RemoveAt(list.Count - 1);
                    }


                }
            }
        }



        Debug.Log(list.Count);


        if (i == 1)
        {
            Instantiate(PreFab2, list[Random.Range(0, list.Count)], Quaternion.identity, g1.transform);

        }
        else
        {
            Instantiate(Prefab1, list[Random.Range(0, list.Count)], Quaternion.identity, g1.transform);
        }
        numberOfPiecesLeft--;


    }

    IEnumerator Medium(GameObject x, int i)
    {
        int Flag = 1;
        yield return new WaitForSeconds(1);
        List<Vector3> list = new List<Vector3>();
        List<Vector3> ls = new List<Vector3>();
        ls.Add( new Vector3(0, 1, -1));
        ls.Add(  new Vector3(0, -1, 1));
        ls.Add(new Vector3(1, 0, -1));
        ls.Add(new Vector3(-1, 0, 1));
        ls.Add(new Vector3(1, -1, 0));
        ls.Add(new Vector3(-1, 1, 0));
        List<Vector3> vecs = new List<Vector3>();
        vecs.Add(new Vector3(-0.9f, 1, 1.535f));
        vecs.Add(new Vector3(-0.9f, 1, -1.535f));
        vecs.Add(new Vector3(0.9f,1,1.535f));
        vecs.Add(new Vector3(0.9f, 1, -1.535f));
        vecs.Add(new Vector3(1.8f,1,0));
        vecs.Add(new Vector3(-1.8f,1,0));
        int cs = 0;


        foreach (var item in ls)
        {
            if (value.x + item.x * 3 < 0 || value.x + item.x * 3 > 2 * gm.n || value.y + item.y * 3 < 0 || value.y + item.y * 3 > 2 * gm.n || value.z + item.z * 3 < 0 || value.z + item.z * 3 > 2 * gm.n)
            {
                continue;
            }
            else
            {
                int[] arr = new int[4];
                for (int k = 0; k <= 3; k++)
                {

                    if (gm.grid[value.x + (int)(k * item.x), value.y + (int)(k * item.y), value.z + (int)(k * item.z)] == gm.grid[value.x, value.y, value.z])
                    {
                        arr[k] = 1;
                    }
                    else
                    {
                        arr[k] = 0;
                    }
                }
                int count = 0;
                int count2 = 0;
                int posx = 0;
                for (int z = 0; z <= 3; z++)
                {
                    if (arr[z] == 1)
                    {
                        count++;
                    }
                    else if (arr[z] == 0) 
                    {
                        count2++;
                        posx = z;
                    }
                }

                if (count == 3 && Flag ==1&& count2 == 1)
                {
                    if (i == 1)
                    {
                        Instantiate(PreFab2, new Vector3(x.transform.position.x + vecs[cs].x * posx*g1.transform.localScale.x, x.transform.position.y + vecs[cs].y * posx, x.transform.position.z + vecs[cs].z * posx *g1.transform.localScale.z), Quaternion.identity, g1.transform);
                        Debug.Log(new Vector3(x.transform.position.x, x.transform.position.y + vecs[cs].y * posx, x.transform.position.z + vecs[cs].z * posx * x.transform.localScale.z));
                    }
                    else
                    {
                        Instantiate(Prefab1, new Vector3(x.transform.position.x + vecs[cs].x * posx * g1.transform.localScale.x, x.transform.position.y + vecs[cs].y * posx, x.transform.position.z + vecs[cs].z * posx * g1.transform.localScale.z), Quaternion.identity, g1.transform);
                    }
                    Flag = 0;
                }


            }
            cs++;

        }
        
        
        var colliders = Physics.OverlapSphere(x.transform.position, 1.5f);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.name == "default")
            {
                list.Add(new Vector3(collider.transform.parent.position.x, collider.transform.parent.position.y + 2f, collider.transform.parent.position.z));
               // Debug.Log(collider.gameObject.transform.parent.localPosition);
                if (collider.gameObject.GetComponentInParent<GridValue>().n != 0)
                {
                    list.RemoveAt(list.Count - 1);
                }
                
                

            }
        }
        if (Flag == 1)
        {
            if (i == 1)
            {
                Instantiate(PreFab2, list[Random.Range(0, list.Count)], Quaternion.identity, g1.transform);
            }
            else
            {
                Instantiate(Prefab1, list[Random.Range(0, list.Count)], Quaternion.identity, g1.transform);
            }
        }

    
    }

}

