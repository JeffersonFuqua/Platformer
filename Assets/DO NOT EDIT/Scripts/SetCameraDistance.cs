using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraDistance : MonoBehaviour
{
    private void OnEnable(){ SetCamDistanceOnLoad.SetOffset += SetOffset; }
    private void OnDisable(){ SetCamDistanceOnLoad.SetOffset -= SetOffset; }
    private void SetOffset(float value) { transform.localPosition = new Vector3(0, 0, value); }
}
