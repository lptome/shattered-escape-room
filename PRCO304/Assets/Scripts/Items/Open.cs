using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : Interactable
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
            open = true;

        }
        else
        {
            anim.Play("Close");
            open = false;
        }
            

    }

   
}
