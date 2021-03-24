using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CMF;

public class ResetPlayer : MonoBehaviour
{
    public AdvancedWalkerController advanceWalker;
    public static Action FadeIn = delegate{};
    public static Action FadeOut = delegate{};

    private Transform player;
    private Vector3 respawnLocation;
    private Quaternion playerRot;
    private bool bFadeOut,bFadeIn, bRespawning;

    private void OnEnable()
    {
        advanceWalker = GetComponent<AdvancedWalkerController>();
        player = transform;
        respawnLocation = player.position;
        KillZone.ResetPlayer += RespawnPlayer;
        Checkpoint.RespawnPoint += SetRespawnLocation;
        ScreenFader.FadeOutComplete += FadeOutComplete;
        ScreenFader.FadeInComplete += FadeInComplete;
    }
    private void OnDisable()
    {
        KillZone.ResetPlayer -= RespawnPlayer;
        Checkpoint.RespawnPoint -= SetRespawnLocation;
        ScreenFader.FadeOutComplete -= FadeOutComplete;
        ScreenFader.FadeInComplete -= FadeInComplete;
    }
    private void RespawnPlayer()
    {
        if (bRespawning) return;
        bRespawning = true;
        StartCoroutine("WaitForFadeIn");
    }
    private void SetRespawnLocation(Vector3 value,Quaternion rotValue)
    {
        respawnLocation = value;
        playerRot = rotValue;
    }
    private void FadeOutComplete() { bFadeOut = true; }
    private void FadeInComplete() { bFadeIn = true; }
    IEnumerator WaitForFadeIn()
    {
        bFadeOut = false;
        FadeOut();        
        while (!bFadeOut)
            yield return new WaitForEndOfFrame();
        float cachedSpeed = advanceWalker.movementSpeed;
        advanceWalker.movementSpeed = 0;
        player.position = respawnLocation;
        player.rotation = playerRot;
        bFadeIn = false;
        FadeIn();
        while (!bFadeIn)
            yield return new WaitForEndOfFrame();
        advanceWalker.movementSpeed = cachedSpeed;
        bRespawning = false;
    }
}
