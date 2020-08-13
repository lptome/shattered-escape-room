using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MicrowaveMinutes : MonoBehaviour
{
    private int digit;
    public TMP_Text text;

    private void Start()
    {
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
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        text.text = digit.ToString();
    }
}
