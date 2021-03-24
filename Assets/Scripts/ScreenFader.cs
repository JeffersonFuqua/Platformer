using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    private Animator anim;
    public static Action FadeInComplete = delegate { };
    public static Action FadeOutComplete = delegate{ };
    private void OnEnable()
    {
        transform.GetComponent<Canvas>().enabled = true;
        anim = GetComponent<Animator>();
        ResetPlayer.FadeOut += FadeOut;
        ResetPlayer.FadeIn += FadeIn;
        Teleporter.FadeIn += FadeIn;
        Teleporter.FadeOut += FadeOut;
    }
    private void OnDisable()
    {
        ResetPlayer.FadeOut -= FadeOut;
        ResetPlayer.FadeIn -= FadeIn;
        Teleporter.FadeIn -= FadeIn;
        Teleporter.FadeOut -= FadeOut;
    }
    private void FadeIn() { anim.SetTrigger("FadeIn"); }
    private void FadeOut() 
    { 
        anim.SetTrigger("FadeOut"); 
    }
    public void FadeInAnimComplete() { FadeInComplete(); }
    public void FadeOutAnimComplete() { FadeOutComplete(); }
}
