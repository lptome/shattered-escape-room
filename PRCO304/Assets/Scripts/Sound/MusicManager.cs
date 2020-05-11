using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;

    public void ChangeTrack(AudioClip track)
    {
        music.Stop();
        music.clip = track;
        music.Play();
    }
}
