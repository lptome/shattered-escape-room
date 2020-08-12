using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlock : Interactive
{

    public Animator anim;
    private bool locked = true;
    private bool open = false;
    private InventoryUI inventoryUI;
    private HintManager hintManager;
    private SoundEffectsManager FXManager;
    public Item key;


    private void Awake()
    {
        hintManager = FindObjectOfType<HintManager>();
        inventoryUI = FindObjectOfType<InventoryUI>();
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
                if (inventoryUI.currentItem == key)
                {
                    Unlock();
                }
                else
                {
                    Locked();
                }
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
    }

    void Locked()
    {
        FXManager.Play("LockedDoor");
        hintManager.DisplayHint("Locked.", 1f);
    }
}
