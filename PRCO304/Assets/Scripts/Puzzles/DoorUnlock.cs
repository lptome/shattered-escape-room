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
            FindObjectOfType<SoundEffectsManager>().Play("LockedDoor");
            FindObjectOfType<UIManager>().DisplayHint("Locked.", 0.5f);
        }
    }

    public void Unlock()
    {
        locked = false;
        anim.Play("Open");
    }
}
