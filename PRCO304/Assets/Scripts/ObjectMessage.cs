using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMessage : MonoBehaviour
{

    [SerializeField] MessageFeedback feedback;
    [TextArea] public string message;
    public bool singleView;
    private float currentTime;
    private bool triggered = false;

    void Click()
    {
        if (singleView == false)
        {
            currentTime = Time.deltaTime;
            feedback.ShowMessage(message, currentTime);
        }
        else
        {
            if (triggered == false)
            {
                currentTime = Time.deltaTime;
                feedback.ShowMessage(message, currentTime);
                triggered = true;
            }
        }
    }
}
