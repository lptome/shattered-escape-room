using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlock : Interactive
{

    public Animator anim;
    private bool locked = true;
    private bool open = false;
    //public SelectedPanel panel;
    public GameObject selectedPanel;
    private SoundEffectsManager FXManager;
    public Item key;


    private void Start()
    {
        FXManager = FindObjectOfType<SoundEffectsManager>();
    }


    public override void Interact()
    { 
        
        if (locked == false)
        {
            if (open == false)
            {
                anim.Play("Open");
                open = true;
                FXManager.Play("Door");
            }
            else
            {
                anim.Play("Close");
                open = false;
                FXManager.Play("Door");
            }
                
        }
        else
        {
            if (key != null)
            {
                //if (selectedPanel.activeSelf == true && panel.CheckItem(key.itemName))
                //{
                //    Unlock();
                //}
                //else
                //{
                //    Locked();
                //}
            }
            else
            {
                Locked();
            }
            
            
            
        }
    }

    public void Unlock()
    {
        locked = false;
        FXManager.Play("UnlockDoor");
        selectedPanel.SetActive(false);     
    }

    void Locked()
    {
        FXManager.Play("LockedDoor");
        Debug.Log("Hint");
        FindObjectOfType<UIManager>().DisplayHint("Locked.", 0.5f);
    }
}
