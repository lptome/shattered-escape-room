using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MicrowaveMinutes : MonoBehaviour
{
    private SoundEffectsManager soundEffects;
    private int digit;
    public TMP_Text text;

    private void Start()
    {
        soundEffects = FindObjectOfType<SoundEffectsManager>();
        digit = 0;
    }
    public void Increase()
    {
        if (digit < 9)
        {
            digit += 1;
        }
        else
        {
            digit = 0;
        }
        PlaySound();
        UpdateDisplay();
    }

    public void Decrease()
    {
        if (digit > 0)
        {
            digit -= 1;
        }
        else
        {
            digit = 9;
        }
        PlaySound();
        UpdateDisplay();
    }

    void PlaySound()
    {
        soundEffects.Play("ButtonPress");
    }
    void UpdateDisplay()
    {
        text.text = digit.ToString();
    }
}
