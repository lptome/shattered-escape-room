using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGridPuzzle : Interactive
{
    public UIManager UI;
    public override void Interact()
    {
        base.Interact();
        OpenGrid();
    }

    void OpenGrid()
    {
        UI.OpenGridPuzzle();
    }
}
