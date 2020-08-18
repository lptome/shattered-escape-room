using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] GameObject itemModel;
    [SerializeField] Item item;
    private SoundEffectsManager soundFXManager;
    private HintManager hintManager;
    [SerializeField] private Inventory inventory;


    private bool pickedUp = false;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        soundFXManager = FindObjectOfType<SoundEffectsManager>();
        hintManager = FindObjectOfType<HintManager>(); 
    }
   
    void PickUp()
    {
        soundFXManager.Play("ItemPickup");
        pickedUp = inventory.Add(item);
        if (pickedUp)
        {
            hintManager.HideHint();
            hintManager.DisplayHint(item.itemName + " added to Inventory.", 2f);
            Destroy(itemModel);
        }
        else
        {
            hintManager.DisplayHint("You're carrying too much.", 1f);
        }
        
    }

    void Hover()
    {
        if(!pickedUp)
            hintManager.DisplayHint("Press E to pick up item.", 0.5f);
    }



}
