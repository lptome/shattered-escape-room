using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hint : Interactive
{
    public UIManager manager;
    public string hint;
    public float duration;
    private bool triggered = false;


    public override void Interact()
    {
        base.Interact();
        Trigger();
        
    }
    public void Trigger()
    {
        if (triggered == false)
        {
            manager.DisplayHint(hint, duration);
            triggered = true;
        }
     
    }
}
