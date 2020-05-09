using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text messageBox;
    public GameObject messagePanel;
    public UIManager menu;
    public AudioManager audioManager;
    private bool allDone = false;


    private void Update()
    {
        if(allDone == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DisplayNextMessage();
            }
        }

    }
    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartMessage(Message message)
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        sentences.Clear();

        foreach(string sentence in message.sentences)
        {
            sentences.Enqueue(sentence);
        }

        
        DisplayNextMessage();
        
    }

    public void DisplayNextMessage()
    {
        allDone = false;
        messagePanel.SetActive(true);
        if (sentences.Count == 0)
        {
            EndMessage();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeMessage(sentence));
    }

    public void EndMessage()
    {
        sentences.Clear();
        messagePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        menu.WritingComplete();

    }

    IEnumerator TypeMessage(string sentence)
    {
        messageBox.text = "";
        foreach(char letter in sentence.ToCharArray())
        {   
            audioManager.Play("TextWriter");
            messageBox.text += letter;           
            yield return null;
        
        }
        allDone = true;
    }

   
}
