using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool bTogglable;
    public bool bOnlyOnEnter;
    public List<GameActions> switchActions;
    public List<GameActions> feedBackActions;
    private bool bTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!bTriggered || bTogglable)
            {
                bTriggered = true;
                for (int x = 0; x < switchActions.Count; x++)
                    switchActions[x].Action();
                for (int x = 0; x < feedBackActions.Count; x++)
                    feedBackActions[x].Action();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && bTogglable)
        {
            for (int x = 0; x < feedBackActions.Count; x++)
                feedBackActions[x].Action();

            if (bOnlyOnEnter) return;
            for (int x = 0; x < switchActions.Count; x++)
                switchActions[x].Action();
        }
    }
}
