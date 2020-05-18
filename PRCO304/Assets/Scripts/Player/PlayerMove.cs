﻿using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


	public CharacterController controller;
	public Transform groundCheck;
	private Transform tr;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	public GameObject inventory;
	public GameObject journal;
	public SoundEffectsManager soundFXManager;
	public MusicManager musicManager;
	public AudioClip mainTheme;
	
	
	

	private float speed;
	public float walkSpeed = 10f;
	public float sprintSpeed = 14f;
	public float gravity = -9.81f;

	Vector3 velocity;
	bool isGrounded;

	void Start()
	{
		tr = controller.transform;
		musicManager.ChangeTrack(mainTheme);
		
	}
	// Update is called once per frame
	void Update()
	{

		if (EventSystem.current.IsPointerOverGameObject())
			return;

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
				vScale -= 0.5f;
				Vector3 tempScale2 = tr.localScale;
				Vector3 tempPosition2 = tr.position;

				tempScale2.y = Mathf.Lerp(tr.localScale.y, vScale, 5 * Time.deltaTime);
				tr.localScale = tempScale2;
				tr.position = tempPosition2;
			}

			
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
