using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlock : MonoBehaviour
{

    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    public Animator anim;
    private bool locked = true;
    public GameObject lockedMessage;
    private float showText;
    private float textDuration = 3f;
    public SelectedPanel selectedPanel;


    // Update is called once per frame
    void Update()
    {
        if (showText > 0.0f)
        {
            if (lockedMessage.activeSelf == true && Time.time >= showText)
            {

                lockedMessage.SetActive(false);
                showText = 0.0f;
            }
        }
        
    }



   
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
            lockedMessage.GetComponent<Text>().text = "Unlocked!";
            lockedMessage.SetActive(true);
            showText = Time.time + textDuration;


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
            lockedMessage.GetComponent<Text>().text = "It's locked.";
            lockedMessage.SetActive(true);
            showText = Time.time + textDuration;
        }
    }

}
