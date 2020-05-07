using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    public AudioManager audioManager;
    private Text messageBox;
    private string textToWrite;
    private int charIndex;
    private float timePerCharacter;
    private float timer;

    public float AddWriter(Text messageBox, string textToWrite, float timePerCharacter)
    {
        this.messageBox = messageBox;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        charIndex = 0;

        return timePerCharacter * textToWrite.Length;
        
    }

    

    // Update is called once per frame
    private void Update()
    {
        if (messageBox != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer += timePerCharacter;
                charIndex++;
                messageBox.text = textToWrite.Substring(0, charIndex);
                audioManager.Play("TextWriter");

                if (charIndex >= textToWrite.Length)
                {
                    messageBox = null;
                    
                }

            }

            
        }
    }

    
}
