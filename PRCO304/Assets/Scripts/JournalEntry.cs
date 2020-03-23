using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JournalEntry : ScriptableObject
{
    public string entryName;
    public string entryDate;
    public string description;
    public Sprite icon;

}
