using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemDescriptionText;

    public void ShowTooltip(Item item)
    {
        ItemNameText.text = item.itemName;
        ItemDescriptionText.text = item.itemDescription;

        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
