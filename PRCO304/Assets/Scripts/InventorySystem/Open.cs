﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : Interactive
{
    public Animator anim;
    private bool open = false;

    public override void Interact()
    {
        base.Interact();
        OpenDoor();
    }
    void OpenDoor()
    {


        if (open == false)
        {
            anim.Play("Open");
            FindObjectOfType<SoundEffectsManager>().Play("Door");
            open = true;

        }
        else
        {
            anim.Play("Close");
            FindObjectOfType<SoundEffectsManager>().Play("Door");
            open = false;
        }
            

    }

   
}