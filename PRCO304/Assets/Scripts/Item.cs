using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite Icon;
    public bool singleUse;          //Whether the item is destroyed/consumed upon usage
    

}
