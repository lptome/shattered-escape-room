using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{


	public float mouseSensitivity = 100f;
	public float range = 4f;

	public Transform playerBody;
	public Camera playerCamera;
	public GameObject inventory;
	public GameObject journal;


	float xRotation = 0f;
	// Use this for initialization
	void Start()
	{

		Cursor.lockState = CursorLockMode.Locked;
		
	}

	// Update is called once per frame
	void Update()
	{

		if (!IsPaused()) 
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
	}

	void Click()
	{
		if (!IsPaused())
		{
			RaycastHit hit;
			if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
			{
				hit.transform.gameObject.SendMessage("Click", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	bool IsPaused()
	{
		if (inventory.activeInHierarchy == true || journal.activeInHierarchy == true)
			return true;
		else return false;
	}
}
