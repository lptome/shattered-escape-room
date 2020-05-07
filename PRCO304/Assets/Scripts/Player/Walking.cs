using UnityEngine.EventSystems;
using UnityEngine;

public class Walking : MonoBehaviour
{

    private float timer = 0.0f;
    public float bobbingSpeed = 0.1f;
    public float bobbingIntensity = 0.08f;
    public float midpoint = 1.65f;
    private bool bPos = true;
    public AudioManager audioManager;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        float waveslice = 0.0f;
        float footstep = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       

        Vector3 position = transform.localPosition;
        

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            footstep = Mathf.Cos(timer);

            if (footstep < 0 && bPos)
                audioManager.Play("Footsteps");

            if (footstep > 0 && !bPos)
                audioManager.Play("Footsteps");

            bPos = footstep >= 0;

            timer += bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer -= (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingIntensity;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            position.y = midpoint + translateChange;
            //audioManager.Play("Footsteps");

        }
        else
        {
            position.y = midpoint;
        }

        transform.localPosition = position;
    }



}