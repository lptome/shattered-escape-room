using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject journalPanel;
    public GameObject inventoryPanel;
    public GameObject tooltipPanel;
    public GameObject entryPanel;
    public GameObject inputField;
    public SoundEffectsManager audioManager;

    public Journal journal;
    public EntryView entryView;

    public MessageManager messageManager;

    private bool journalEnabled;
    private bool inventoryEnabled;
    private bool complete = false;
    private bool entryAdded = false;
   
    void Start()
    {
        journalPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
      

        if (inventoryEnabled == false)
        {
            tooltipPanel.SetActive(false);
        }
        if (journalEnabled == false)
        {
            entryPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.L) && inputField.activeSelf == false)
        {
            ToggleJournal();
        }

        if (Input.GetKeyDown(KeyCode.I) && inputField.activeSelf == false)
        {
            ToggleInventory();    
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryEnabled == true)
            {
                inventoryPanel.SetActive(false);
                inventoryEnabled = !inventoryEnabled;
            }
            
            if (journalEnabled == true)
            {
                journalPanel.SetActive(false);
                journalEnabled = !journalEnabled;
            }
            HideMouse();
        }

        
    }

    public void ToggleInventory()
    {
        if (journalEnabled == true)
        {
            journalEnabled = false;
        }
        journalPanel.SetActive(false);
        inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true)
        {
            inventoryPanel.SetActive(true);
            ShowMouse();
        }
        else
        {
            inventoryPanel.SetActive(false);
            HideMouse();

        }
    }

    public void ToggleJournal()
    {
        if (inventoryEnabled == true)
        {
            inventoryEnabled = false;
        }
        inventoryPanel.SetActive(false);
        journalEnabled = !journalEnabled;

        if (journalEnabled == true)
        {
            journalPanel.SetActive(true);

            if (entryAdded == true)
            {
                int lastEntry = journal.entries.Count - 1;
                entryView.ShowEntry(journal.entries[lastEntry]);
            }
            else if (journal.entries.Count != 0)
            {
                int currentEntry = entryView.GetCurrentEntry();
                entryView.ShowEntry(journal.entries[currentEntry]);
                ShowMouse();
                
            }
            ShowMouse();
        }
        else
        {
           
            journalPanel.SetActive(false);
            HideMouse();
            

        }
    }

    public void WritingComplete()
    {
        complete = true;

        if (entryAdded == true)
        {
            ToggleJournal();
            entryAdded = false;
            complete = false;
        }
    }


    public void EntryAdded()
    {
        entryAdded = true;
    }

    public void ShowMouse()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

   
}
