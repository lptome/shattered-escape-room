using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLook : MonoBehaviour
{


	public float mouseSensitivity = 100f;
	public float range = 6f;
	public LayerMask itemLayer;

	public Transform playerBody;
	public Camera playerCamera;
	public MessageManager messageManager;

	float xRotation = 0f;

	void Start()
	{

		Cursor.lockState = CursorLockMode.Locked;
		
	}

	void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
			
			//Get Mouse Input.
			float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
			float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

			xRotation -= mouseY;
			xRotation = Mathf.Clamp(xRotation, -60f, 60f); //Limit vertical rotation so player can't rotate vertically.

			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

			playerBody.Rotate(Vector3.up * mouseX);

			if (Input.GetMouseButtonDown(0))
			{
				Click();
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				PickUp();
			}
		Hover();	
	}

	void Click()
	{
		
			RaycastHit hit;
			if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
			{
				hit.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
			}
		
	}

	void PickUp()
	{
		RaycastHit hit;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range, itemLayer))
		{
			hit.transform.gameObject.SendMessage("PickUp", SendMessageOptions.DontRequireReceiver);		
		}	
	}

	void Hover()
	{		
		RaycastHit hit;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range, itemLayer))
		{
			hit.transform.gameObject.SendMessage("Hover", SendMessageOptions.DontRequireReceiver);
		}
	}	
}
