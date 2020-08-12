using UnityEngine;

public class JournalUI : MonoBehaviour
{
    public Transform entriesParent;

    private Journal journal;

    JournalSlot[] slots;

    private void Awake()
    {
        journal = FindObjectOfType<Journal>();
        slots = entriesParent.GetComponentsInChildren<JournalSlot>();
    }
    void Start()
    {
        journal.onEntryAddedCallback += UpdateUI;
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
