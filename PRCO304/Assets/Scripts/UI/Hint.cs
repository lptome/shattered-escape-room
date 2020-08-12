using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hint : Interactive
{
    public HintManager manager;
    public string hint;
    public float duration;
    private bool triggered = false;


    private void Awake()
    {
        manager = FindObjectOfType<HintManager>();
    }
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
