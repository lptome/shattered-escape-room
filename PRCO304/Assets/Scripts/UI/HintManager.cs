using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    public GameObject hintPanel;
    public TMP_Text text;
    public Animator hintAnimator;
    private float timer;
    private bool hintOn;

    private void Update()
    {
        //Countdown from hint duration.
        if (hintOn == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                HideHint();
            }
        }

        
    }

    void HideHint()
    {
        hintAnimator.SetBool("isOpen", false);
        hintOn = false;
    }
    public void DisplayHint(string hint, float duration)
    {
        text.text = hint;
        timer = duration; //Start the timer
        hintOn = true;
        hintPanel.SetActive(true);
        hintAnimator.SetBool("isOpen", true);
    }
}
