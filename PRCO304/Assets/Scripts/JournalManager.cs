using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    [SerializeField] Journal journal;
    [SerializeField] GameObject notesPanel;
    [SerializeField] EntryView entryView;

    private void Awake()
    {
        journal.OnPointerEnterEvent += Highlight;
        journal.OnPointerExitEvent += DeHighlight;
        journal.OnLeftClickEvent += ShowEntry;

        entryView.HideEntry();
    }

    public void Highlight(JournalSlot journalSlot)
    {
        if (journalSlot.JournalEntry != null)
        {
            //highlight entry
        }
    }

    public void DeHighlight(JournalSlot journalSlot)
    {
        //dehighlight entry
    }

    public void ShowEntry(JournalEntry journalEntry)
    {
        if (journalEntry != null)
        {
            entryView.ShowEntry(journalEntry);
        }
    }

}
