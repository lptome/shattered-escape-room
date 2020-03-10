using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] Item itemNeeded;
    [SerializeField] Item itemGiven;
    [SerializeField] Inventory inventory;
    [SerializeField] SelectedPanel selectedPanel;

    public GameObject popupMessage;
    
    //These are used to store the object appearance before and after an item is used.
    public GameObject initialObject;        
    public GameObject finalObject;       
    
    

    //These two strings can be changed in the editor per necessary, default text displays a description of the object,
    //interactText displays a message once the correct item is used on the object.
    [TextArea] public string defaultText;
    [TextArea] public string interactText;

    //Determines whether object is destroyed once the correct item is used on it.
    public bool destructable;

    //Setting up GUI text.
    private float showText;
    private float textDuration = 3f;


    void Update()
    {
        if (showText > 0.0f)
        {
            if (popupMessage.activeSelf == true && Time.time >= showText)
            {

                popupMessage.SetActive(false);
                showText = 0.0f;

            }
        }
        
    }

    void Click()
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
                Destroy(gameObject);
            }
            popupMessage.GetComponent<Text>().text = interactText;
            popupMessage.SetActive(true);
            showText = Time.time + textDuration;

            if (itemGiven != null)
            {
                inventory.AddItem(itemGiven);
                selectedPanel.SelectItem(itemGiven);
            }

            finalObject.SetActive(true);
        }

        else
        {
            popupMessage.GetComponent<Text>().text = defaultText;
            popupMessage.SetActive(true);
            showText = Time.time + textDuration;
        }
    }
}
