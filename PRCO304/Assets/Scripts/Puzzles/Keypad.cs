using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : Interactable
{
    public GameObject inputFieldObject;
    public InputField inputField;
    private UIManager UI;
    private SoundEffectsManager soundEffectsManager;
    private string code = "IKRJ";
    private string userInput;
    public DoorUnlock door;
    public Hint hint;


    private void Update()
    {
        inputField.text = inputField.text.ToUpper();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.HideMouse();
            inputFieldObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckCode();
        }
    }
    private void Start()
    {
        UI = FindObjectOfType<UIManager>();
        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        
    }
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
            soundEffectsManager.Play("CorrectCode");
            Destroy(this);
            
        }
        else
        {
            soundEffectsManager.Play("WrongCode");
            hint.Trigger();
        }
    }
}
