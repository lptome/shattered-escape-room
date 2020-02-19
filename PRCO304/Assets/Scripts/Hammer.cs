using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject hammerModel;
    public Inventory inventory;
    public Item hammer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Click()
    {

        Destroy(hammerModel);
        inventory.AddItem(hammer);
    }
}
