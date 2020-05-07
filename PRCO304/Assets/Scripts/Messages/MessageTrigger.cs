using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTrigger : Interactable
{
    public Message message;
    public bool singleUse;
 
    public override void Interact()
    {
        base.Interact();
        if(singleUse == true)
        {
            TriggerMessage();
            singleUse = false;
        }
        
    }

    public void TriggerMessage()
    {
        FindObjectOfType<MessageManager>().StartMessage(message);
    }


}
