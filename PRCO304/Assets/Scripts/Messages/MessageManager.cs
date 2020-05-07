using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextWriter textWriter;
    public Text messageBox;
    public GameObject messagePanel;
    public Menu menu;
    private float textDuration;
    private bool allDone;


    private void Update()
    {
        if (textDuration != 0f)
        {
            textDuration -= Time.deltaTime;

            if (textDuration <= 0)
            {
                allDone = true;
                
            }
        }
        if (messagePanel.activeInHierarchy == true && allDone == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Next entry");
                allDone = false;
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

        sentences.Clear();

        foreach(string sentence in message.sentences)
        {
            sentences.Enqueue(sentence);
        }

        
        DisplayNextMessage();
    }

    public void DisplayNextMessage()
    {
        messagePanel.SetActive(true);
        if (sentences.Count == 0)
        {
            EndMessage();
            return;
        }

        string sentence = sentences.Dequeue();
       
        textDuration = textWriter.AddWriter(messageBox, sentence, 0.03f);
    }

    public void EndMessage()
    {
        messagePanel.SetActive(false);
        menu.WritingComplete();

    }

   
}
