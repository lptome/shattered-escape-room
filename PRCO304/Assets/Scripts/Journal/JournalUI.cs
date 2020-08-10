using UnityEngine;

public class JournalUI : MonoBehaviour
{
    public Transform entriesParent;

    Journal journal;

    JournalSlot[] slots;
    void Start()
    {
        journal = Journal.instance;
        journal.onEntryAddedCallback += UpdateUI;

        slots = entriesParent.GetComponentsInChildren<JournalSlot>();

    }

    
    

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < journal.entries.Count)
            {
                slots[i].AddEntry(journal.entries[i]);
            }
        }
    }
}
