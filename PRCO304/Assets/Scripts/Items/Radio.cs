using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Interactable
{
    public AudioSource source;
    public override void Interact()
    {
        base.Interact();
        PlayRadio();
    }

    void PlayRadio()
    {
        StartCoroutine(PlayBeep());

    }

    IEnumerator PlayBeep()
    {
        source.pitch = 0.7f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 2f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 0.7f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 0.7f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 0.7f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 2f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
    }
}
