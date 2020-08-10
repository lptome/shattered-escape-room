using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject journalPanel;
    public GameObject inventoryPanel;
    public GameObject tooltipPanel;
    public GameObject entryPanel;
    public GameObject inputField;
    public GameObject hintPanel;
    public GameObject pauseMenu;
    public Animator hintAnimator;
    private SoundEffectsManager audioManager;
    private ItemTooltip tooltip;
    private float timer;
    private bool hintOn = false;
    public Hint inventoryHint;
    public Hint journalHint;
   

    public Journal journal;
    public EntryView entryView;

    public MessageManager messageManager;

    private bool journalEnabled;
    private bool inventoryEnabled;
    private bool entryAdded = false;
   

    void Start()
    {
        journalPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        audioManager = FindObjectOfType<SoundEffectsManager>();
        tooltip = FindObjectOfType<ItemTooltip>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && hintOn == true)
        {
            hintAnimator.SetBool("isOpen", false);
            hintOn = false;
        }


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
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryEnabled == true)
            {
                inventoryPanel.SetActive(false);
                inventoryEnabled = !inventoryEnabled;
            }          
            else if (journalEnabled == true)
            {
                journalPanel.SetActive(false);
                journalEnabled = !journalEnabled;
                journalHint.Trigger();
            }
            else
            {
                TogglePauseMenu();
            }
            HideMouse();
        }

        
    }
    
    void TogglePauseMenu()
    {
        if (pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);
            HideMouse();
        }
        else
        {
            pauseMenu.SetActive(true);
            ShowMouse();
        }
    }

    void ToggleInventory()
    {
        inventoryHint.Trigger();

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

    void ToggleJournal()
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
                entryAdded = false;
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
        if (entryAdded == true)
        {
            ToggleJournal();
            entryAdded = false;
        }
    }


    public void EntryAdded()
    {
        entryAdded = true;
    }

    public void ItemAdded()
    {

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

    public void DisplayHint(string hint, float duration)
    {
        hintPanel.GetComponentInChildren<Text>().text = hint;
        timer = duration;
        hintOn = true;
        hintPanel.SetActive(true);
        hintAnimator.SetBool("isOpen", true);
        
    }
    
}
