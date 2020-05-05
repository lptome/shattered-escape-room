using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPickup : Interactable
{
    
    public JournalEntry journalEntry;
    private bool triggered = false;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        if (triggered == false)
        {
            Journal.instance.Add(journalEntry);
            triggered = true;
            Debug.Log("PickedUp successfully");
        }
        Debug.Log("Picking up");
        
    }
}
