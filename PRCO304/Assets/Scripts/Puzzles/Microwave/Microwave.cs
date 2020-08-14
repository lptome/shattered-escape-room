using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Microwave : Interactive
{
    public GameObject microwavePanel;
    public UIManager UI;
    public SoundEffectsManager FXManager;
    public TMP_Text text1, text2, text3, text4;
    private bool solved = false;
    private bool open = false;
    public Animator animator;
    public MessageManager messageManager;
    public Message message;


    public override void Interact()
    {
        base.Interact();
        if (!solved)
        {
            OpenPanel();
        }
        else
        {
            if (open == false)
            {
                OpenMicrowave();
            }
            else
            {
                CloseMicrowave();
            }
            
        }
        
    }
    public void CheckCode()
    {
        //Grab digits from display
        int digit1 = Int32.Parse(text1.text);
        int digit2 = Int32.Parse(text2.text);
        int digit3 = Int32.Parse(text3.text);
        int digit4 = Int32.Parse(text4.text);

        //Check if code is correct;
        if (digit1 == 1 && digit2 == 7 && digit3 == 3 && digit4 == 5)
        {
            solved = true;
            FXManager.Play("CorrectCode");
            microwavePanel.SetActive(false);
            UI.HideMouse();
            OpenMicrowave();
        }
        else
        {
            messageManager.StartMessage(message);
            microwavePanel.SetActive(false);
            UI.HideMouse();
            FXManager.Play("WrongCode");
        }

    }

    void OpenPanel()
    {
        microwavePanel.SetActive(true);
        UI.ShowMouse();
    }

    void OpenMicrowave()
    {
        open = true;
        animator.Play("Open");
    }

    void CloseMicrowave()
    {
        open = false;
        animator.Play("Close");
    }

}
