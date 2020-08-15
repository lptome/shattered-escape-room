using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : Interactive
{
    public Animator anim;
    private SoundEffectsManager fxManager;
    private bool open = false;

    private void Awake()
    {
        fxManager = FindObjectOfType<SoundEffectsManager>();
    }
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
            fxManager.Play("Door");
            open = true;

        }
        else
        {
            anim.Play("Close");
            fxManager.Play("Door");
            open = false;
        }
            

    }
    
  
   
}
