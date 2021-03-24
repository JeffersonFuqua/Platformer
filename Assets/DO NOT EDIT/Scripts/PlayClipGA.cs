using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClipGA : GameActions
{
    public AudioClip aClip;
    public AudioSource aSource;

    public override void Action()
    {
        aSource.PlayOneShot(aClip);
    }
}
