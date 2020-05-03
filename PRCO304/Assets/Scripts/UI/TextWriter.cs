using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text subtitles;
    private string textToWrite;
    private int charIndex;
    private float timePerCharacter;
    private float timer;

    public void AddWriter(Text subtitles, string textToWrite, float timePerCharacter)
    {
        this.subtitles = subtitles;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        charIndex = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (subtitles != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer += timePerCharacter;
                charIndex++;
                subtitles.text = textToWrite.Substring(0, charIndex);

                if (charIndex >= textToWrite.Length)
                {
                    subtitles = null;
                }
            }
        }
    }
}
