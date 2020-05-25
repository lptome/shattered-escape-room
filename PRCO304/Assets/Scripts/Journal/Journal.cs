using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    #region Singleton
    public static Journal instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Journal found.");
            return;
        }

        instance = this;
    }

    #endregion 

    public delegate void OnEntryAdded();
    public OnEntryAdded onEntryAddedCallback;

    public int space = 10;

    public List<JournalEntry> entries = new List<JournalEntry>();

    public bool Add (JournalEntry entry)
    {
        if (entries.Count >= space)
        {
            return false;
        }
       
        entries.Add(entry);

        if (onEntryAddedCallback != null)
        {
            onEntryAddedCallback.Invoke();
        }
            
        

        return true;
    }
   
}
