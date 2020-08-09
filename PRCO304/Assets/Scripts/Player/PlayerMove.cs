using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


	public CharacterController controller;
	public Transform groundCheck;
	private Transform tr;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	private float speed;
	public float walkSpeed = 4f;
	public float sprintSpeed = 6f;
	public float gravity = -9.81f;

	Vector3 velocity;
	bool isGrounded;

	void Start()
	{
		tr = controller.transform;
		
	}
	// Update is called once per frame
	void Update()
	{
		Debug.Log(speed);
		//Disable movement if UI is open.
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		float vScale = 1.3f;
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		//Return true if player is in contact with the ground.
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		//Update speed if command is held down.
		if (isGrounded)
		{
			//Do not enable sprinting when crouching.
			if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
            {
				speed = sprintSpeed;
			}	
            else
            {
				speed = walkSpeed;
			}

		}
	

		if  (Input.GetKey(KeyCode.LeftControl))
		{
			Crouch(vScale, x, z);
        }
        else
        {
			Move(vScale, x, z);
        }
	
	}


	void Move(float vScale, float x, float z)
    {
		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * speed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;

		Vector3 tempScale = tr.localScale;
		Vector3 tempPosition = tr.position;

		tempScale.y = Mathf.Lerp(tr.localScale.y, vScale, 5 * Time.deltaTime);
		tr.localScale = tempScale;
		tr.position = tempPosition;

		controller.Move(velocity * Time.deltaTime);
	}
	void Crouch(float vScale, float x, float z)
    {
		vScale -= 0.5f;
		Move(vScale, x, z);		
	}

}
