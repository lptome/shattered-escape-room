using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPanel : MonoBehaviour
{
    [SerializeField] Transform selectedSlotsParent;
    [SerializeField] SelectedSlot[] selectedSlots;
    public GameObject selectedPanel;

    private void OnValidate()
    {
        selectedSlots = selectedSlotsParent.GetComponentsInChildren<SelectedSlot>();
    }

    public bool SelectItem(Item item)
    {
        selectedPanel.SetActive(true);
        selectedSlots[0].Item = item;
        return true;
    }

    // Checks which item is currently selected by grabbing the item name.
    public bool CheckItem(string itemName)
    {
        if (selectedSlots[0].Item.itemName == itemName)
            return true;
        else return false;
    }

    public void HidePanel()
    {
        selectedPanel.SetActive(false);
    }
}
