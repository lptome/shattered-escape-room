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
    private Inventory inventory;
    public Item key;


    private void Awake()
    {
        hintManager = FindObjectOfType<HintManager>();
        inventoryUI = FindObjectOfType<InventoryUI>();
        FXManager = FindObjectOfType<SoundEffectsManager>();
        inventory = FindObjectOfType<Inventory>();
    }


    public override void Interact()
    { 
        
        if (locked == false)
        {
            if (open == false)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
                
        }
        else
        {
            if (key != null)
            {
                if (inventoryUI.currentItem == key)
                {
                    inventory.Remove(key);
                    inventoryUI.UpdateUI();
                    inventoryUI.DeselectItem();
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
    
    public void CloseDoor()
    {
        anim.Play("Close");
        open = false;
        FXManager.Play("Door");
    }
    public void OpenDoor()
    {
        anim.Play("Open");
        open = true;
        FXManager.Play("Door");
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

    public void LockDoor()
    {
        locked = true;
    }
}
