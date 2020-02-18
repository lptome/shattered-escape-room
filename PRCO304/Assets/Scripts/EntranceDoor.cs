using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{

    public Animator anim;
    private bool locked = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnMouseDown()
    {


        if (anim.GetBool("open") == false)
        {
            anim.SetTrigger("open");
        }
        else
            anim.ResetTrigger("open");




    }

}
