using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageFeedback : MonoBehaviour
{

    public GameObject feedbackMessage;
    private float showText;
    private float textDuration = 3f;


    void Update()
    {
        if (showText > 0.0f)
        {
            if (feedbackMessage.activeSelf == true && Time.time >= showText)
            {
                feedbackMessage.SetActive(false);
                showText = 0.0f;
            }
        }
        
    }

    public void ShowMessage(string message, float currentTime)
    {
        feedbackMessage.GetComponent<Text>().text = message;
        showText = textDuration + currentTime;
        feedbackMessage.SetActive(true);
    }
}
