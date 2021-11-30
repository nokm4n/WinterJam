using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
	// Start is called before the first frame update
	public float mousesense = 100f;
	public Transform playerBody;
	float xRotation = 0f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		/*Debug.Log(Pause_menu.GameIsPause);
		if (!Pause_menu.GameIsPause)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Debug.Log(Pause_menu.GameIsPause);
		}*/
		float mouseX = Input.GetAxis("Mouse X") * mousesense * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mousesense * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}
}
