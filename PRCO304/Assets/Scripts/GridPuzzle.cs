using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridPuzzle : MonoBehaviour
{
    private int[] correctIndices = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
    private int[] indices = new int[16];
    public ChangeSquareColour[] blocks;
    public DoorUnlock door;
    public SoundEffectsManager soundEffectsManager;
    public GameObject gridPanel;

    private void Awake()
    {
        blocks = GetComponentsInChildren<ChangeSquareColour>();
    }

    //This will be called from each individual square when the index changes.
    public void UpdateIndex(ChangeSquareColour square, int index)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i] == square)
            {
                indices[i] = index;
            }
        }
    }
    private void Update()
    {
        if (indices.SequenceEqual(correctIndices))
        {
            soundEffectsManager.Play("CorrectCode");
            door.Unlock();
            Destroy(gridPanel);
            Destroy(this);
        }
    }
}
