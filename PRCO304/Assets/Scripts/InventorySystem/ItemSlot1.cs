using UnityEngine;
using UnityEngine.UI;

public class ItemSlot1 : MonoBehaviour
{

    Item item;
    Button button;
    public Image image;
    public UIManager menu;

    public void Start()
    {
        button = GetComponentInChildren<Button>();
        button.enabled = false;
        image.enabled = false;
    }

    public void AddItem(Item itemToAdd)
    {
        item = itemToAdd;
        menu.ItemAdded();
        image.enabled = true;
        button.enabled = true;
    }
}