using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    public GameObject trigger;
    public bool singleTrigger;
    private SoundEffectsManager manager;
    private string triggerClip;

    private void Start()
    {
        manager = FindObjectOfType<SoundEffectsManager>();
    }
    private void OnTriggerEnter(Collider player)
    {
        if (triggerClip != null)
        {
            manager.Play(triggerClip);
        }
        trigger.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerExit(Collider player)
    {
        if (singleTrigger == true)
        {
            Destroy(trigger);
        }
    }
}
