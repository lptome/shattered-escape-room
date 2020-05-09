using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : Interactable
{
    public GameObject inputFieldObject;
    public InputField inputField;
    public UIManager UI;
    private string code = "IKRJ";
    private string userInput;
    public DoorUnlock door;



   
    public override void Interact()
    {
        base.Interact();
        EnterCode();
    }

    public void EnterCode()
    {
        UI.ShowMouse();
        inputFieldObject.SetActive(true);
        

    }

    public void CheckCode()
    {
        userInput = inputField.text;
        if (userInput == code)
        {
            door.Unlock();
            inputFieldObject.SetActive(false);
            UI.HideMouse();
            Debug.Log("Correct code!");
            
        }
        else
        {
            Debug.Log("Incorrect code.");
            //show wrong code error.
        }
    }
}
