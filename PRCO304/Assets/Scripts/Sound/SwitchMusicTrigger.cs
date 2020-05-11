using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : Interactable
{

    public AudioClip newTrack;
    public MusicManager musicManager;
    public override void Interact()
    {
        base.Interact();
        SwitchTrack();
    }

    void SwitchTrack()
    {
        musicManager.ChangeTrack(newTrack);
    }
}
