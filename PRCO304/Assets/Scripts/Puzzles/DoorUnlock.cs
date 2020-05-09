using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlock : Interactable
{

    public Animator anim;
    private bool locked = true;



   
    public override void Interact()
    { 

        if (locked == false)
        {
            if (anim.GetBool("open") == false)
            {
                anim.SetTrigger("open");
                
            }
            else
                anim.ResetTrigger("open");
        }
        else
        {
            
        }
    }

    public void Unlock()
    {
        locked = false;
    }
}
