using Google.Protobuf.WellKnownTypes;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class colx : MonoBehaviour
{
    // Start is called before the first frame update
    GridValue value;
    private void OnCollisionEnter(Collision collision)
    {
        value = collision.gameObject.GetComponentInParent<GridValue>();
        value.setval(1);
    }
}
