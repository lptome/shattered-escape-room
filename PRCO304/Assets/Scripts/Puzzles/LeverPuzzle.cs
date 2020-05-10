using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : Interactable
{
    public Lever lever1;
    public Lever lever2;
    public Lever lever3;
    public Lever lever4;
    public Lever lever5;
    public Lever lever6;
    public override void Interact()
    {
        base.Interact();
        CheckCombination();
    }

    void CheckCombination()
    {
        bool pos1 = lever1.faceUp;
        bool pos2 = lever2.faceUp;
        bool pos3 = lever3.faceUp;
        bool pos4 = lever4.faceUp;
        bool pos5 = lever5.faceUp;
        bool pos6 = lever6.faceUp;


        //Compares the position of each lever to the correct combination and opens the stairs if it is correct.

        if ((pos1 == false) && (pos2 == true) && (pos3 == false) && (pos4 == false) && (pos5 == false) && (pos6 == true))
        {
            OpenStairs();
        }
        else
        {
            Debug.Log("Combination incorrect.");
        }
    }

    void OpenStairs()
    {

        Debug.Log("Combination is correct.");

    }
}
