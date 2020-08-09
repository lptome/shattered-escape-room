using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : Interactive
{

    public AudioClip newTrack;
    private MusicManager musicManager;
    public override void Interact()
    {
        base.Interact();
        SwitchTrack();
    }

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }
    void SwitchTrack()
    {
        musicManager.ChangeTrack(newTrack);
    }
}
