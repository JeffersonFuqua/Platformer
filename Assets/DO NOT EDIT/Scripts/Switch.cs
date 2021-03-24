using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool bTogglable;
    public List<GameActions> switchActions;
    private bool bTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !bTriggered)
        {
            bTriggered = true;
            for (int x = 0; x < switchActions.Count; x++)
                switchActions[x].Action();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && bTogglable)
            bTriggered = false;
    }
}
