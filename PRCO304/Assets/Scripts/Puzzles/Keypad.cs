using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : Interactive
{
    public GameObject inputFieldObject;
    public InputField inputField;
    private UIManager UI;
    private MessageManager messageManager;
    private SoundEffectsManager soundEffectsManager;
    private string code = "KRJI";
    private string userInput;
    public DoorUnlock door;
    public Message message;


    private void Update()
    {
        inputField.text = inputField.text.ToUpper();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.HideMouse();
            inputFieldObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return) && !messageManager.messagePanel.activeSelf)
        {
            CheckCode();
        }
    }
    private void Awake()
    {
        UI = FindObjectOfType<UIManager>();
        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        messageManager = FindObjectOfType<MessageManager>();
        
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
            inputFieldObject.SetActive(false);
            UI.HideMouse();
            soundEffectsManager.Play("CorrectCode");
            door.Unlock();
            Destroy(this);
            
        }
        else
        {
            inputFieldObject.SetActive(false);
            UI.HideMouse();
            inputField.text = "____";
            soundEffectsManager.Play("WrongCode");
            messageManager.StartMessage(message);
        }
    }
}
