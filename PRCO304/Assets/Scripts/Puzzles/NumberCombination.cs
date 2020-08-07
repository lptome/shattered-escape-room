using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberCombination : MonoBehaviour
{
    private int digit;
    public Text input;

    private void Start()
    {
        digit = 0;
    }
    
    public void ChangeNumber()
    {
        digit += 1;
        if (digit > 9)
            digit = 0;
        input.text = digit.ToString();
        FindObjectOfType<SoundEffectsManager>().Play("ButtonPress");
    }
}
