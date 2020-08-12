using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPickup : Interactive
{
    private Journal journal;
    public JournalEntry journalEntry;


    private void Awake()
    {
        journal = FindObjectOfType<Journal>();
    }

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        journal.Add(journalEntry);
        Destroy(this);
    }
}
