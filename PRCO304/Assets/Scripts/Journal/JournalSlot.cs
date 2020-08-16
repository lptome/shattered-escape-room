
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalSlot : MonoBehaviour
{
    public TMP_Text title;
    JournalEntry journalEntry;
    [SerializeField] Button button;
    public Image image;
    public EntryView entryView;
    public UIManager menu;

    private void Awake()
    {
        button = GetComponentInChildren<Button>();
    }

    private void Start()
    {
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
