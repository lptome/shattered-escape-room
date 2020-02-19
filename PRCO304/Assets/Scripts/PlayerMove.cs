using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


	public CharacterController controller;
	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	public GameObject menu;

	public float speed;
	public float walkSpeed = 12f;
	public float sprintSpeed = 18f;
	public float gravity = -9.81f;

	Vector3 velocity;
	bool isGrounded;

	void Start()
	{
		menu = GameObject.Find("Inventory");
	}
	// Update is called once per frame
	void Update()
	{


			isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

			if (isGrounded && velocity.y < 0)
			{
				velocity.y = -2f;

			}

			if (Input.GetKey(KeyCode.LeftShift))
			{
				speed = sprintSpeed;
			}
			else
			{
				speed = walkSpeed;
			}

			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");


			Vector3 move = transform.right * x + transform.forward * z;

			controller.Move(move * speed * Time.deltaTime);

			velocity.y += gravity * Time.deltaTime;



			controller.Move(velocity * Time.deltaTime);

	}

	bool IsPaused()
	{
		if (menu.activeInHierarchy == true)
			return true;
		else return false;
	}
}
