using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLook : MonoBehaviour
{


	public float mouseSensitivity = 100f;
	public float range = 4f;
	public LayerMask itemLayer;

	public Transform playerBody;
	public Camera playerCamera;
	public GameObject inventory;
	public GameObject journal;
	public MessageManager messageManager;

	float xRotation = 0f;
	// Use this for initialization
	void Start()
	{

		Cursor.lockState = CursorLockMode.Locked;
		
	}

	// Update is called once per frame
	void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		
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
			if (Input.GetKeyDown(KeyCode.E))
			{
				PickUp();
			}

		//Hover();
		
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
				hit.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
				Debug.Log("Pick up");
			}

		
		
	}

	void Hover()
	{
		
		RaycastHit hit;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range, itemLayer))
		{
			hit.transform.gameObject.SendMessage("Hover", SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			messageManager.StopHovering();
		}

		
	}
	
}
