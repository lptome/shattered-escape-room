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
    public AudioClip endGameTrack;

    private void OnTriggerEnter(Collider player)
    {
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        Destroy(moveScript);
        Destroy(lookScript);
        Destroy(bobbingScript);
        musicManager.PlayTrackNoLoop(endGameTrack);
        for (int i = 0; i < 4; i++)
        {
            fxManager.Play("LargeFootsteps");
            yield return new WaitForSeconds(1.5f);
        }
        blackScreen.SetActive(true);
        fxManager.Play("Gunshot");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
       // SceneManager.LoadScene(3);
    }
    
}
