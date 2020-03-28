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
    public string finalItem;        //Name of the item that can be formed by combining it with another item, can be null.
    

}
