using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleObject : Interactable
{
    //The correct item needed to interact with the object.
    [SerializeField] Item itemNeeded;

    //This is NOT the item the player uses to interact with the object, that check is done through the selected item panel. 
    //The itemGiven variable serves to add an item to the player's inventory if the puzzle's solution results in a new item being recovered.
    [SerializeField] Item itemGiven;

    [SerializeField] Inventory inventory;
    [SerializeField] SelectedPanel selectedPanel;
    private MessageManager messageManager;
    private SoundEffectsManager soundEffectsManager;

    //A message that will tell the player the item is incorrect.
    public Message wrongItemMessage;
    public Message defaultMessage;
    
    //These are used to store the object appearance before and after an item is used.
    public GameObject initialObject;        
    public GameObject finalObject;



   
    //Determines whether object is destroyed once the correct item is used on it.
    public bool destructable;



   
    private void Start()
    {
        messageManager = FindObjectOfType<MessageManager>();
        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
    }

    public override void Interact()
    {
        base.Interact();
        ClickObject();
    }

    void ClickObject()
    {
        if (selectedPanel.isActiveAndEnabled && selectedPanel.CheckItem(itemNeeded.itemName))
        {
            if (itemNeeded.singleUse == true)
            {
                inventory.RemoveItem(itemNeeded);
                selectedPanel.HidePanel();
            }

            if (destructable == true)
            {
                initialObject.SetActive(false);
            }

            

            if (itemGiven != null)
            {
                inventory.AddItem(itemGiven);
                
            }

            finalObject.SetActive(true);
            selectedPanel.HidePanel();
            soundEffectsManager.Play("ObjectInteract");
        }

        else if (selectedPanel.isActiveAndEnabled && wrongItemMessage != null)
        {
            messageManager.StartMessage(wrongItemMessage);
            selectedPanel.HidePanel();
        }

        else if (defaultMessage != null)
        {
            messageManager.StartMessage(defaultMessage);
        }
    }
}
