using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPickup : MonoBehaviour
{
    [SerializeField] Journal journal;
    [SerializeField] JournalEntry journalEntry;
    
    void Click()
    {
        journal.AddEntry(journalEntry);
        
    }
}
