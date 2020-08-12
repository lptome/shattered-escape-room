using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    private GameObject hintPanel;
    private float timer;
    private bool hintOn;
    private Animator hintAnimator;

    private void Awake()
    {
        hintPanel = GameObject.Find("/UI/Canvas/Panel/Hint Panel");
        hintAnimator = hintPanel.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Countdown from hint duration.
        timer -= Time.deltaTime;

        if (timer <= 0 && hintOn == true)
        {
            HideHint();
        }
    }

    void HideHint()
    {
        hintAnimator.SetBool("isOpen", false);
        hintOn = false;
    }
    public void DisplayHint(string hint, float duration)
    {
        hintPanel.GetComponentInChildren<Text>().text = hint;
        timer = duration; //Start the timer
        hintOn = true;
        hintPanel.SetActive(true);
        hintAnimator.SetBool("isOpen", true);

    }
}
