using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] GameObject itemModel;
    [SerializeField] Item item;
    private SoundEffectsManager soundFXManager;
    private UIManager UIManager;


    private bool pickedUp;

    private void Start()
    {
        soundFXManager = FindObjectOfType<SoundEffectsManager>();
        UIManager = FindObjectOfType<UIManager>();
        
    }
   
    void PickUp()
    {
        soundFXManager.Play("ItemPickup");
        pickedUp = Inventory.instance.Add(item);
        if (pickedUp)
        {
            Destroy(itemModel);
        }
        else
        {
            UIManager.DisplayHint("You're carrying too much.", 1f);
        }
        
    }

    void Hover()
    {
        UIManager.DisplayHint("Press E to pick up item.", 0.5f);
        
    }

    
}
