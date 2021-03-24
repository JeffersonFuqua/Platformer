using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamDistanceOnLoad : MonoBehaviour
{
    public float cameraOffset;

    public static Action<float> SetOffset = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        SetOffset(cameraOffset);
    }
}
