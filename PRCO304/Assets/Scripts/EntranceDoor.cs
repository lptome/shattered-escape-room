using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{

    public Animator anim;
    private bool locked = false;
    public GameObject lockedMessage;
    private float showText;
    private float textDuration = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lockedMessage.activeSelf == true && Time.time >= showText)
        {
            lockedMessage.SetActive(false);
        }
    }



   
    void Click()
    {
        if (locked == false)
        {
            if (anim.GetBool("open") == false)
            {
                anim.SetTrigger("open");
            }
            else
                anim.ResetTrigger("open");
        }
        else
        {
            lockedMessage.SetActive(true);
            showText = Time.time + textDuration;
        }
    }

}
