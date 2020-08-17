using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactive
{
    public Animator anim;
    public SoundEffectsManager soundEffects;

    public bool faceUp = true;

    private void Start()
    {
        soundEffects = FindObjectOfType<SoundEffectsManager>();
    }
    public override void Interact()
    {
        base.Interact();
        SwitchLever();
    }

    void SwitchLever()
    {
        faceUp = !faceUp;

        if (anim.GetBool("faceUp") == false)
        {
            anim.SetTrigger("faceUp");

        }
        else
            anim.ResetTrigger("faceUp");

        soundEffects.Play("LeverPull");
    }
}
