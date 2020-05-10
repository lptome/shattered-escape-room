using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : Interactable
{
    public Animator anim;

    public override void Interact()
    {
        base.Interact();
        OpenDoor();
    }
    void OpenDoor()
    {

        
        if (anim.GetBool("open") == false)
        {
            anim.SetTrigger("open");

        }
        else
            anim.ResetTrigger("open");
    }

   
}
