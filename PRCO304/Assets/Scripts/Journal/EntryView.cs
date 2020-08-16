
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntryView : MonoBehaviour
{
    [SerializeField] TMP_Text entryName;
    [SerializeField] TMP_Text entryDescription;
    public Journal journal;
    private int currentEntry;

    public void ShowEntry(JournalEntry journalEntry)
    {
        entryName.text = journalEntry.entryName;
        entryDescription.text = journalEntry.description;
        currentEntry = journal.entries.IndexOf(journalEntry);
        gameObject.SetActive(true);
    }

    public void HideEntry()
    {
        gameObject.SetActive(false);
    }

    public int GetCurrentEntry()            //Returns the last entry to be opened.
    {
        return currentEntry;
    }
}
