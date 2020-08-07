using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Interactable
{
    public AudioSource source;
    private MessageManager messageManager;
    public Message message;
 

    private void Start()
    {
        messageManager = FindObjectOfType<MessageManager>();
    }

    public override void Interact()
    {
        base.Interact();
        PlayRadio();
    }

    void PlayRadio()
    {
        StartCoroutine(PlayBeep());

    }

    IEnumerator PlayBeep()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;


        //Alternates same audio between pitches to give clue for lever placement.
        source.pitch = 0.7f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 2f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 0.7f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 0.7f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 0.7f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.pitch = 2f;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        Cursor.lockState = CursorLockMode.Locked;
        messageManager.StartMessage(message);

    }
}
