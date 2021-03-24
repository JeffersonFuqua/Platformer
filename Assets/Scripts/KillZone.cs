using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class KillZone : MonoBehaviour
{
    public static Action ResetPlayer = delegate { };

    private void OnEnable()
    {
       transform.GetComponent<MeshRenderer>().enabled = false;
        transform.GetComponent<Collider>().isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            ResetPlayer();

    }
#if UNITY_EDITOR
    private void Reset()
    {
        transform.GetComponent<MeshRenderer>().material = Resources.Load("Materials/TransRed", typeof(Material)) as Material;
    }
#endif
}
