using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlock : Interactable
{

    public Animator anim;
    private bool locked = true;
    private bool open = false;



   
    public override void Interact()
    { 

        if (locked == false)
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
        else
        {
            
        }
    }

    public void Unlock()
    {
        locked = false;
        anim.Play("Open");
    }
}
