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
    public GameObject gridPuzzle;
    public GameObject microwavePuzzle;
    public GameObject keypadPuzzle;
    public GameObject numberWheelPuzzle;
    public GameObject puzzlesParent;
    public Hint inventoryHint;
    public Hint journalHint;
   

    public Journal journal;
    public EntryView entryView;

    public MessageManager messageManager;

    private bool entryAdded = false;
   

    void Start()
    {
        journalPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    void Update()
    {

        if (!inventoryPanel.activeSelf)
        {
            tooltipPanel.SetActive(false);
        }
        if (!journalPanel.activeSelf)
        {
            entryPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (journalPanel.activeSelf)
            {
                CloseJournal();
            }
            else if (!inputField.activeSelf)
            {
                OpenJournal();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPanel.activeSelf)
            {
                CloseInventory();
            }
            else if (!inputField.activeSelf)
            {
                OpenInventory();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.activeSelf)
            {
                ClosePauseMenu();
            }
            else if (!inputField.activeSelf)
            {
                OpenPauseMenu();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryPanel.activeSelf)
            {
                CloseInventory();

            }          
            else if (journalPanel.activeSelf)
            {
                CloseJournal();
                journalHint.Trigger();
            }
            else if(gridPuzzle.activeSelf)
            {
                CloseGridPuzzle();
            }
            else if (microwavePuzzle.activeSelf)
            {
                CloseMicrowavePuzzle();
            }
            else if (numberWheelPuzzle.activeSelf)
            {
                CloseNumberWheelPuzzle();
            }
            else if (keypadPuzzle.activeSelf)
            {
                CloseKeypadPuzzle();
            }
            else if (pauseMenu.activeSelf)
            {
                ClosePauseMenu();
            }
            else
            {
                OpenPauseMenu();
            }
        }

        
    }

    void OpenInventory()
    {
        if (puzzlesParent.activeSelf)
        {
            DisablePuzzlesParent();
        }
        if (journalPanel.activeSelf)
        {
            CloseJournal();
        }
        inventoryHint.Trigger();
        inventoryPanel.SetActive(true);
        ShowMouse();
    }

    void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        EnablePuzzlesParent();
        HideMouse();
    }

    void OpenJournal()
    {
        if (puzzlesParent.activeSelf)
        {
            DisablePuzzlesParent();
        }
        else if (inventoryPanel.activeSelf)
        {
            CloseInventory();
        }
        journalPanel.SetActive(true);
        ShowMouse();
    }

    void CloseJournal()
    {
        journalPanel.SetActive(false);
        EnablePuzzlesParent();
        HideMouse();
    }

    public void OpenGridPuzzle()
    {
        gridPuzzle.SetActive(true);
        ShowMouse();
    }

    public void CloseGridPuzzle()
    {
        gridPuzzle.SetActive(false);
        HideMouse();
    }

    public void OpenMicrowavePuzzle()
    {
        microwavePuzzle.SetActive(true);
        ShowMouse();
    }

    public void CloseMicrowavePuzzle()
    {
        microwavePuzzle.SetActive(false);
        HideMouse();
    }

    public void OpenKeypadPuzzle()
    {
        keypadPuzzle.SetActive(true);
        ShowMouse();
    }

    public void CloseKeypadPuzzle()
    {
        keypadPuzzle.SetActive(false);
        HideMouse();
    }

    public void OpenNumberWheelPuzzle()
    {
        numberWheelPuzzle.SetActive(true);
        ShowMouse();
    }

    public void CloseNumberWheelPuzzle()
    {
        numberWheelPuzzle.SetActive(false);
        HideMouse();
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        ShowMouse();
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        HideMouse();
    }

    public void EnablePuzzlesParent()
    {
        puzzlesParent.SetActive(true);
    }

    public void DisablePuzzlesParent()
    {
        puzzlesParent.SetActive(false);
    }
    

    
    public void WritingComplete()
    {
        if (entryAdded == true)
        {
            int lastEntry = journal.entries.Count - 1;
            entryView.ShowEntry(journal.entries[lastEntry]);
            OpenJournal();
            entryAdded = false;
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
