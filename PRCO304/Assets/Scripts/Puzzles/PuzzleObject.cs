using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleObject : Interactive
{
    //The correct item needed to interact with the object.
    [SerializeField] Item itemNeeded;

    //This is NOT the item the player uses to interact with the object, that check is done through the selected item panel. 
    //The itemGiven variable serves to add an item to the player's inventory if the puzzle's solution results in a new item being recovered.
    [SerializeField] Item itemGiven;

    public Inventory inventory;
    private InventoryUI inventoryUI;
    private GameObject selectedItem;
    private MessageManager messageManager;
    private SoundEffectsManager soundEffectsManager;

    //A message that will tell the player the item is incorrect.
    public Message wrongItemMessage;
    public Message defaultMessage;
    
    //These are used to store the object appearance before and after an item is used.
    public GameObject initialObject;        
    public GameObject finalObject;






   
    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        messageManager = FindObjectOfType<MessageManager>();
        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        inventoryUI = FindObjectOfType<InventoryUI>();
        selectedItem = GameObject.Find("/UI/Canvas/Panel/Selected Panel");
    }

    public override void Interact()
    {
        base.Interact();
        ClickObject();
    }

    void ClickObject()
    {
   
        if (selectedItem.activeSelf)
        {
            if (inventoryUI.currentItem == itemNeeded)
            {
                if (itemNeeded.singleUse == true)
                {
                    inventory.Remove(inventoryUI.currentItem);
                    inventoryUI.UpdateUI();
                    selectedItem.SetActive(false);
                }

                initialObject.SetActive(false);

                if (itemGiven != null)
                {
                    inventory.Add(itemGiven);

                }

                finalObject.SetActive(true);
                selectedItem.SetActive(false);
                inventoryUI.currentItem = null;
                soundEffectsManager.Play("ObjectInteract");
            }
            else if ( wrongItemMessage != null)
            {
                messageManager.StartMessage(wrongItemMessage);
                selectedItem.SetActive(false);
            }
        }

        else if (defaultMessage != null)
        {
            messageManager.StartMessage(defaultMessage);
        }
    }
}
