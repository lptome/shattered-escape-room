using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSwitch : Interactive
{
    public FanRotation fanScript;
    public GameObject cord;
    public MessageTrigger trigger;

    public override void Interact()
    {
        base.Interact();
        TryTurnOn();
    }

    void TryTurnOn()
    {
        if (cord.activeSelf == true)
        {
            FindObjectOfType<SoundEffectsManager>().Play("ButtonPress");
            FindObjectOfType<SoundEffectsManager>().Play("CorrectCode");
            fanScript.TurnOn();
            Destroy(trigger);
            Destroy(this);
        }
        else
        {
            FindObjectOfType<SoundEffectsManager>().Play("ButtonPress");
        }
    }
}
