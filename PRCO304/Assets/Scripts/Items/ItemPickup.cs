using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField] GameObject itemModel;
    [SerializeField] Inventory inventory;
    [SerializeField] Item item;
    public AudioManager audioManager;


    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    void PickUp()
    {

        audioManager.Play("ItemPickup");
        inventory.AddItem(item);
        Destroy(itemModel);

    }
}
