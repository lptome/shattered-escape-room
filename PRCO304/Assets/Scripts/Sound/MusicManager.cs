using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip defaultTrack;
    private void Awake()
    {
        music.clip = defaultTrack;
        music.Play();
    }

    //Change background music if looping is desired.
    public void ChangeTrackLoop(AudioClip track)
    {
        music.Stop();
        music.clip = track;
        music.Play();
    }

    //Play track until the end and resume previous track.
    public void PlayTrackNoLoop(AudioClip track)
    {
        AudioClip previous = music.clip;
        music.Stop();
        music.clip = track;
        StartCoroutine(NoLoopTrack(previous));
    }

    IEnumerator NoLoopTrack(AudioClip previous)
    {
        music.loop = false;
        music.Play();
        yield return new WaitWhile(()=>music.isPlaying);
        music.loop = true;
        ChangeTrackLoop(previous);
    }
}
