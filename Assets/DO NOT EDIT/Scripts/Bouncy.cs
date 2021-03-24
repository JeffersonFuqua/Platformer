using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float bounceTime;
    public static Action<float> Bounce = delegate { };
    private bool bActive;
    private void OnTriggerEnter(Collider other)
    {
        if (bActive) return;
        if (other.CompareTag("Player"))
            Bounce(bounceTime);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) bActive = false;
    }
}
