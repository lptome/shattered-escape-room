using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageFeedback : MonoBehaviour
{

    public GameObject feedbackPanel;
    private float showText;
    private float textDuration = 3f;


    void Update()
    {
        if (showText > 0.0f)
        {
            if (feedbackPanel.activeSelf == true && Time.time >= showText)
            {
                feedbackPanel.SetActive(false);
                showText = 0.0f;
            }
        }
        
    }

    public void ShowMessage(string message, float currentTime)
    {
        feedbackPanel.GetComponentInChildren<Text>().text = message;
        showText = textDuration + currentTime;
        feedbackPanel.SetActive(true);
    }
}
