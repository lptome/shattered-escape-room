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
    private string hoverMessage = "Press E to pick up item.";


    private void Start()
    {
        soundFXManager = GameObject.Find("SoundEffectsManager").GetComponent<SoundEffectsManager>();
        messageManager = GameObject.Find("MessageManager").GetComponent<MessageManager>();
    }
    public override void Interact()
    {
        base.Interact();
        PickUp();
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
