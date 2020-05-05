using System;
using UnityEngine;


public class Journal : MonoBehaviour
{
    public GameObject journalPanel;
    [SerializeField] Transform entriesParent;
    [SerializeField] JournalSlot[] journalSlots;
    public Menu menu;

    public event Action<JournalEntry> OnLeftClickEvent;
    public event Action<JournalSlot> OnPointerEnterEvent;
    public event Action<JournalSlot> OnPointerExitEvent;

    void Start()
    {
        for (int i = 0; i < journalSlots.Length; i++)
        {
            journalSlots[i].OnLeftClickEvent += OnLeftClickEvent;
            journalSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            journalSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            
        }
    }


    private void OnValidate()
    {
        if (entriesParent != null)
            journalSlots = entriesParent.GetComponentsInChildren<JournalSlot>();

    }

    public bool AddEntry(JournalEntry journalEntry)
    {
        for (int i = 0; i < journalSlots.Length; i++)
        {
            if (journalSlots[i].JournalEntry == null)
            {
                journalSlots[i].JournalEntry = journalEntry;
                menu.EntryAdded();                                          //Tells the Menu class that a new journal entry has been added.
                return true;
            }
        }
        return false;

        
    }
}
