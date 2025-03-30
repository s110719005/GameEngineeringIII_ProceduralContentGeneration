using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public delegate void PropDelegate();
    public static PropDelegate OnPropGet;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        gameObject.SetActive(false);
        OnPropGet?.Invoke();
    }
}
