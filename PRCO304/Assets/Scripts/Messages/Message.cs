using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Message
{
    public string name;

    [TextArea(3, 5)]
    public string[] sentences;

}
