﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryView : MonoBehaviour
{
    [SerializeField] Text entryName;
    [SerializeField] Text entryDate;
    [SerializeField] Text entryDescription;

    public void ShowEntry(JournalEntry journalEntry)
    {
        entryName.text = journalEntry.entryName;
        entryDate.text = journalEntry.entryDate;
        entryDescription.text = journalEntry.description;

        gameObject.SetActive(true);
    }

    public void HideEntry()
    {
        gameObject.SetActive(false);
    }
}