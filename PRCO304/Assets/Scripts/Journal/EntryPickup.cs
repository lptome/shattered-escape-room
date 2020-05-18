using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPickup : Interactable
{
    
    public JournalEntry journalEntry;


    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Journal.instance.Add(journalEntry);
        Destroy(this);
    }
}
