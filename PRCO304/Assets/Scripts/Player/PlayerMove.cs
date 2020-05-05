using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


	public CharacterController controller;
	public Transform groundCheck;
	public Transform tr;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	public GameObject inventory;
	public GameObject journal;
	public AudioManager audioManager;
	
	
	

	private float speed;
	public float walkSpeed = 10f;
	public float sprintSpeed = 14f;
	public float gravity = -9.81f;

	Vector3 velocity;
	bool isGrounded;

	void Start()
	{
		tr = controller.transform;
		audioManager.Play("MainTheme");
		
	}
	// Update is called once per frame
	void Update()
	{
		float vScale = 1.3f;

			isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

			if (isGrounded && velocity.y < 0)
			{
				velocity.y = -2f;

			}

			if (isGrounded && Input.GetKey(KeyCode.LeftShift))
			{
				speed = sprintSpeed;
			}
			else if (isGrounded)
			{
				speed = walkSpeed;
			}

			if  (Input.GetKey(KeyCode.LeftControl))
			{
			vScale = 0.5f;
			Vector3 tempScale = tr.localScale;
			Vector3 tempPosition = tr.position;

			tempScale.y = Mathf.Lerp(tr.localScale.y, vScale, 5 * Time.deltaTime);
			tr.localScale = tempScale;
			tr.position = tempPosition;
			}

			if (!IsPaused())
			{
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");


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
	}

	bool IsPaused()
	{
		if (inventory.activeInHierarchy == true || journal.activeInHierarchy == true)
			return true;
		else return false;
	}

}
