
using UnityEngine;
using UnityEngine.UI;

public class JournalSlot : MonoBehaviour
{
    public Text title;
    JournalEntry journalEntry;
    public EntryView entryView;

    public void AddEntry(JournalEntry newEntry)
    {
        journalEntry = newEntry;
        title.text = journalEntry.entryName;
    }

    public void View()
    {
        if (journalEntry != null)
        {
            entryView.ShowEntry(journalEntry);
        }

    }
}
