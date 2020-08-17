using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSafe : Interactive
{
    public Animator anim;
    private SoundEffectsManager fxManager;
    private bool open = false;
    private bool locked = true;
    public GameObject safeScreen;

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

        if (locked == false)
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

    public void Unlock()
    {
        fxManager.Play("CorrectCode");
        safeScreen.GetComponent<Material>().color = new Color(0f, 95f, 10f);
        locked = false;
    }

}
