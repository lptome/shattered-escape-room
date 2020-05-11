using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    public Animator anim;
    public SoundEffectsManager audioManager;

    public bool faceUp = true;

    private void Start()
    {
        audioManager = FindObjectOfType<SoundEffectsManager>();
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

        audioManager.Play("LeverPull");
    }
}
