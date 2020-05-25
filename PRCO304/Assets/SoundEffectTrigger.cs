using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectTrigger : Interactable
{
    public string soundEffect;
    public override void Interact()
    {
        base.Interact();
        Play();
    }

    void Play()
    {
        FindObjectOfType<SoundEffectsManager>().Play(soundEffect);
    }
}

