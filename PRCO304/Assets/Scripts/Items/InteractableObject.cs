using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : Interactable
{
    [SerializeField] Item itemNeeded;
    [SerializeField] Item itemGiven;
    [SerializeField] Inventory inventory;
    [SerializeField] SelectedPanel selectedPanel;
    public MessageManager messageManager;
    

    public GameObject popupMessage;
    
    //These are used to store the object appearance before and after an item is used.
    public GameObject initialObject;        
    public GameObject finalObject;



   
    //Determines whether object is destroyed once the correct item is used on it.
    public bool destructable;




    private void Start()
    {
        
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

            
           // messageManager.StartMessage(message1.message);

            if (itemGiven != null)
            {
                inventory.AddItem(itemGiven);
                selectedPanel.SelectItem(itemGiven);
            }

            finalObject.SetActive(true);
        }

        else
        {
           // messageManager.StartMessage(message2.message);
        }
    }
}
