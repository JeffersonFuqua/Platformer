using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Checkpoint : MonoBehaviour
{
    public static Action<Vector3> RespawnPoint = delegate { };

    private void OnEnable()
    {
        transform.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        RespawnPoint(transform.position);
    }
}
