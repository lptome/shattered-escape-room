using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTrigger : Interactable
{
    public Message message;
    public bool singleUse;
    private bool triggered;



    public override void Interact()
    {
        base.Interact();
        if (singleUse == true)
        {
            if (triggered == false)
            {
                TriggerMessage();
                triggered = true;
            }
        }
        else
        {
            TriggerMessage();
        }

    }

    public void TriggerMessage()
    {
        FindObjectOfType<MessageManager>().StartMessage(message);
    }


}
