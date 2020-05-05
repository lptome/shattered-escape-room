﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageFeedback : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    public Menu menu;
    public GameObject feedbackPanel;
    private float textDuration;


    void Update()
    {
        if (textDuration != 0f)
        {

            textDuration -= Time.deltaTime;

            if (textDuration <= 0f)
            {

                menu.WritingComplete();                                     //Tells the Menu class that the TextWriter is finished.
                feedbackPanel.SetActive(false);                             //Disables subtitles and resets text to null.
                feedbackPanel.GetComponentInChildren<Text>().text = null;
                
            }
            
        }
        
    }

    public void ShowMessage(string message, float currentTime)
    {
        feedbackPanel.SetActive(true);
        
        textDuration = textWriter.AddWriter(feedbackPanel.GetComponentInChildren<Text>(), message, 0.03f);
        Debug.Log(textDuration);
        
        
    }

    public void Complete()
    {
        menu.WritingComplete();
    }
}
