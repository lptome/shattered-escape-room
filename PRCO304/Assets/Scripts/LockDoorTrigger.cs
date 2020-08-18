using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorTrigger : MonoBehaviour
{
    public DoorUnlock door;

    private void OnTriggerEnter(Collider player)
    {
        door.LockDoor();
        door.CloseDoor();
        Destroy(this);
    }
}
