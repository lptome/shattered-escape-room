using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] GameObject itemModel;
    [SerializeField] Inventory inventory;
    [SerializeField] Item item;
    [SerializeField] MessageFeedback messageFeedback;
    [SerializeField] string message;

    
    void PickUp()
    {
        
        inventory.AddItem(item);
        float currentTime = Time.time;
        messageFeedback.ShowMessage(message, currentTime);
        Destroy(itemModel);

    }
}
