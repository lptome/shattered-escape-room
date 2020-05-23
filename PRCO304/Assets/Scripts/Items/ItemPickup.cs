using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField] GameObject itemModel;
    [SerializeField] Inventory inventory;
    [SerializeField] Item item;
    private SoundEffectsManager soundFXManager;
    private MessageManager messageManager;
    private ItemTooltip tooltip;
    private string hoverMessage = "Press E to pick up item.";


    private void Start()
    {
        soundFXManager = FindObjectOfType<SoundEffectsManager>();
        messageManager = FindObjectOfType<MessageManager>();
        tooltip = FindObjectOfType<ItemTooltip>();
        
    }
    public override void Interact()
    {
        base.Interact();
    }
    void PickUp()
    {

        soundFXManager.Play("ItemPickup");
        inventory.AddItem(item);
        Destroy(itemModel);
     
        

    }

    void Hover()
    {
        messageManager.HoverMessage(hoverMessage);
        
    }

    
}
