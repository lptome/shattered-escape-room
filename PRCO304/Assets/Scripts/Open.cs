using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public Animator anim;
    void Click()
    {
        if (anim.GetBool("open") == false)
        {
            anim.SetTrigger("open");

        }
        else
            anim.ResetTrigger("open");
    }

   
}
