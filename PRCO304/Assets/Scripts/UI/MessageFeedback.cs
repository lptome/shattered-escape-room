using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageFeedback : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    public GameObject feedbackPanel;
    private float showText;
    private float textDuration = 6f;


    void Update()
    {
        if (showText > 0.0f)
        {
            if (feedbackPanel.activeSelf == true && Time.time >= showText)
            {
                feedbackPanel.SetActive(false);
                feedbackPanel.GetComponentInChildren<Text>().text = null;
                showText = 0.0f;
            }
        }
        
    }

    public void ShowMessage(string message, float currentTime)
    {
        feedbackPanel.SetActive(true);
        textWriter.AddWriter(feedbackPanel.GetComponentInChildren<Text>(), message, 0.03f);
        showText = textDuration + currentTime;
        
        
    }
}
