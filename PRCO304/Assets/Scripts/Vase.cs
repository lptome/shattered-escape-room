using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public GameObject vaseModel;
    public Inventory inventory;
    public Item vase;
    
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
        Destroy(vaseModel);
        inventory.AddItem(vase);
    }
}
