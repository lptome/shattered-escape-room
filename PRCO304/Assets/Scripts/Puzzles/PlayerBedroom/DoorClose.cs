using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public GameObject trigger;
    public DoorUnlock door;
    public Animator animator;

    private void OnTriggerEnter(Collider player)
    {
        animator.Play("Close");
        FindObjectOfType<SoundEffectsManager>().Play("Door");
        door.LockDoor();
        Destroy(this);
    }
}
