using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryPickup : MonoBehaviour
{
    [SerializeField] Journal journal;
    [SerializeField] JournalEntry journalEntry;
    [SerializeField] MessageFeedback feedback;
    [TextArea] public string message;
    private float currentTime;

    void Click()
    {
        currentTime = Time.deltaTime;
        journal.AddEntry(journalEntry);
        feedback.ShowMessage(message, currentTime);
    }
}
