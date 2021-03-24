using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : GameActions
{
    public bool bIndependent;
    public Transform targetLocation;
    private Transform player;

    public static Action FadeIn = delegate { };
    public static Action FadeOut = delegate { };

    private void OnEnable()
    {
        ScreenFader.FadeOutComplete += FadeOutComplete;
        if (targetLocation == null) Debug.LogError("Target location has not been set.");
    }
    private void OnDisable()
    {
        ScreenFader.FadeOutComplete -= FadeOutComplete;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            if (bIndependent) Action();
        }
    }
    public override void Action()
    {
        FadeOut();
    }
    private void FadeOutComplete()
    {
        if (player == null) return;
        player.position = targetLocation.position;
        FadeIn();
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (targetLocation != null)
        {
            Gizmos.color = new Color(0, 1, 0, 0.5f);

            Gizmos.DrawLine(transform.position, targetLocation.position);
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one) * Matrix4x4.Translate(-transform.position);
            Gizmos.DrawCube(transform.position, transform.localScale);
            Gizmos.matrix = Matrix4x4.TRS(targetLocation.position, targetLocation.rotation, Vector3.one) * Matrix4x4.Translate(-targetLocation.position);
            Gizmos.DrawCube(targetLocation.position, targetLocation.localScale);
        }
        else
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
#endif
}
