using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementRotation : GameActions
{
    public Vector3 rotationIncrement;
    public float rotationSpeed;
    private Transform localTrans;
    private bool bRotating;
    private void OnEnable()
    {
        localTrans = transform;
    }
    public override void Action()
    {
        if (bRotating) return;
        StartCoroutine("RotateObject");
    }
    IEnumerator RotateObject()
    {
        bRotating = true;
        Vector3 desiredRotation = localTrans.localRotation.eulerAngles + rotationIncrement;
        float incrementRate = 0;

        while(incrementRate != 1)
        {
            yield return new WaitForEndOfFrame();
            incrementRate += Time.deltaTime * rotationSpeed;
            incrementRate = Mathf.Clamp(incrementRate, 0, 1);
            localTrans.localRotation = Quaternion.Lerp(localTrans.localRotation, Quaternion.Euler(desiredRotation), incrementRate);
        }
        bRotating = false;
    }
}
