using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : Interactive
{
    public GameObject objectToDestroy;
    public SoundEffectsManager soundEffects;
    public override void Interact()
    {
        base.Interact();
        DestroyObject();
    }

    void DestroyObject()
    {
        soundEffects.Play("ItemPickup");
        Destroy(objectToDestroy);
    }
}
