using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        gameObject.SetActive(false);
        //Add point
    }
}
