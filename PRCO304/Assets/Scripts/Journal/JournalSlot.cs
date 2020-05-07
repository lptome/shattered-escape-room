
using UnityEngine;
using UnityEngine.UI;

public class JournalSlot : MonoBehaviour
{
    public Text title;
    JournalEntry journalEntry;
    Button button;
    public Image image;
    public EntryView entryView;
    public Menu menu;

    public void Start()
    {
        button = GetComponentInChildren<Button>();
        button.enabled = false;
        image.enabled = false;
    }
    public void AddEntry(JournalEntry newEntry)
    {
        journalEntry = newEntry;
        title.text = journalEntry.entryName;
        menu.EntryAdded();
        image.enabled = true;
        button.enabled = true;

    }

    public void View()
    {
        if (journalEntry != null)
        {
            entryView.ShowEntry(journalEntry);
        }

    }
}
