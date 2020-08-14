using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSquareColour : MonoBehaviour
{
    public int index;  //color index
    public Image image;
    public GridPuzzle grid;


    private void Awake()
    {
        image = this.gameObject.GetComponent<Image>();
        index = 1;
    }

    public void ChangeColour()
    {
        //Increment index with each click
        if (index < 6)
        {
            index += 1;
            grid.UpdateIndex(this, index);
        }
        else
        {
            index = 1;
            grid.UpdateIndex(this, index);
        }

        //Change color appropriately
        switch (index)
        {
            case 1:
                image.color = Color.white;
                break;
            case 2:
                image.color = Color.cyan;
                break;
            case 3:
                image.color = Color.green;
                break;
            case 4:
                image.color = Color.yellow;
                break;
            case 5:
                image.color = Color.red;
                break;
            case 6:
                image.color = Color.magenta;
                break;
        }
    }

}
