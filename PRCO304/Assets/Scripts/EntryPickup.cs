using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryPickup : MonoBehaviour
{
    [SerializeField] Journal journal;
    [SerializeField] JournalEntry journalEntry;
    private bool triggered = false;

    void Click()
    {
        if (triggered == false)
        {
            journal.AddEntry(journalEntry);
            triggered = true;
        }
        
    }
}
