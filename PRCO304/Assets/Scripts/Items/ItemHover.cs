using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHover : MonoBehaviour
{

    [SerializeField] MessageFeedback messageFeedback;
    [SerializeField] string message;
    
   
    void Hover()
    {
        float currentTime = Time.time;
        messageFeedback.ShowMessage(message, currentTime);
    }
}
