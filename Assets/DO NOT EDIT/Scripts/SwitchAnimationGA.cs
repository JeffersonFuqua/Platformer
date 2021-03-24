using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimationGA : GameActions
{
    public Animation anim;
    public AnimationClip onClip,offClip;
    public bool bPlayed;

    private void OnEnable()
    {
        onClip.legacy = true;
        offClip.legacy = true;
        
    }
    public override void Action()
    {
        if(bPlayed)
        {
            bPlayed = false;
            anim.AddClip(offClip, offClip.name);
            anim.clip = offClip;
            anim.Play();
        }
        else
        {
            bPlayed = true;
            anim.AddClip(onClip, onClip.name);
            anim.clip = onClip;
            anim.Play();
        }
    }
}
