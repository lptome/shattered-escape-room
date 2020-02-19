using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{


	public float mouseSensitivity = 100f;
	public float range = 4f;

	public Transform playerBody;
	public Camera playerCamera;

	float xRotation = 0f;
	// Use this for initialization
	void Start()
	{

		Cursor.lockState = CursorLockMode.Locked;

	}

	// Update is called once per frame
	void Update()
	{

		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

		playerBody.Rotate(Vector3.up * mouseX);

		if (Input.GetMouseButtonDown(0))
		{
			Click();
		}
	}

	void Click()
	{
		RaycastHit hit;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
		{
			hit.transform.gameObject.SendMessage("Click", SendMessageOptions.DontRequireReceiver);
		}
	}
}
