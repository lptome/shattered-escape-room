using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlock : MonoBehaviour
{

    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] MessageFeedback feedback;
    public Animator anim;
    private bool locked = true;
    private float currentTime;
    public SelectedPanel selectedPanel;



   
    void Click()
    {

        if (selectedPanel.isActiveAndEnabled && selectedPanel.CheckItem(item.itemName))
        {
            locked = false;
            if (item.singleUse == true)
            {
                inventory.RemoveItem(item);
                selectedPanel.HidePanel();
            }
            string message = "Unlocked!";
            currentTime = Time.time;
            feedback.ShowMessage(message, currentTime);
        }
            

        if (locked == false)
        {
            if (anim.GetBool("open") == false)
            {
                anim.SetTrigger("open");
                
            }
            else
                anim.ResetTrigger("open");
        }
        else
        {
            string message = "It's locked.";
            currentTime = Time.time;
            feedback.ShowMessage(message, currentTime);
        }
    }

}
