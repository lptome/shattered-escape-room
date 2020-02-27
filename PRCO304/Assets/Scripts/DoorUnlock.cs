using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lockedMessage.activeSelf == true && Time.time >= showText)
        {
            lockedMessage.SetActive(false);
        }
    }



   
    void Click()
    {

        if (selectedPanel.CheckItem(item.itemName))
        {
            locked = false;
            if (item.singleUse == true)
            {
                inventory.RemoveItem(item);
                selectedPanel.HidePanel();
            }
                
                
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
            lockedMessage.SetActive(true);
            showText = Time.time + textDuration;
        }
    }

}
