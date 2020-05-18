using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JournalEntry : ScriptableObject
{
  
    public string entryName;

    [TextArea(3, 20)]
    public string description;

   

}
