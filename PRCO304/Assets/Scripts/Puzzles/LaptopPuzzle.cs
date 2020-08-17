using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopPuzzle : MonoBehaviour
{
    private string password;
    public OpenSafe safe;
    public InputField inputField;
   

    void CheckPassword()
    {
        if (inputField.text.Equals(password))
        {
            safe.Unlock();
        }
    }

}
