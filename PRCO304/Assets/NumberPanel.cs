using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPanel : Interactive
{
    public GameObject inputPanel;
    public Text input1, input2, input3;
    public DoorUnlock door;
    public UIManager UI;
    private string correctCombination = "111";



    public override void Interact()
    {
        base.Interact();
        OpenWheel();
    }

    void OpenWheel()
    {
        UI.ShowMouse();
        inputPanel.SetActive(true);
    }

    public void CheckCode() 
    {
        string string1 = input1.text.ToString();
        string string2 = input2.text.ToString();
        string string3 = input3.text.ToString();

        if ((string1 + string2 + string3).Equals(correctCombination))
        {
            inputPanel.SetActive(false);
            UI.HideMouse();
            door.Unlock();
        }
    }
}
