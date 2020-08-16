using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public SettingsMenu menu;
    private float transitionTime = 2f;
    public Animator transition;
    public SoundEffectsManager fxManager;
    public MusicManager musicManager;
    public PlayerMove moveScript;
    public PlayerLook lookScript;
    public Walking bobbingScript;
    public GameObject blackScreen;
    public GameObject thankYouScreen;
    public AudioClip jumpScareTrack;
    public AudioClip creditsTrack;

    private void OnTriggerEnter(Collider player)
    {
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        Destroy(moveScript);
        Destroy(lookScript);
        Destroy(bobbingScript);
        musicManager.PlayTrackNoLoop(jumpScareTrack);
        for (int i = 0; i < 4; i++)
        {
            fxManager.Play("LargeFootsteps");
            yield return new WaitForSeconds(1.5f);
        }
        blackScreen.SetActive(true);
        fxManager.Play("Gunshot");
        musicManager.ChangeTrackLoop(creditsTrack);
        yield return new WaitForSeconds(2f);
        transition.SetTrigger("Start");
        blackScreen.SetActive(false);
        thankYouScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
    
}
