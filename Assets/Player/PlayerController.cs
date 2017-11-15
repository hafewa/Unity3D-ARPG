using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Camera playerCamera;
	private Rigidbody playerRigidbody;
	private PlayerData playerData;

	

	KeyCode forward = KeyCode.W;
	KeyCode right = KeyCode.D;
	KeyCode left = KeyCode.A;
	KeyCode back = KeyCode.S;

	// Use this for initialization
	void Start () 
	{
		playerRigidbody = GetComponent<Rigidbody>();
		playerData = GetComponent<PlayerData>();

		playerCamera = GetComponentInChildren<Camera>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerInput();
		turnPlayer();
		turnCamera();
	}

	//Player input
	void playerInput()
	{
		bool bForward = Input.GetKey(forward);
		bool bBack = Input.GetKey(back);
		bool bRight = Input.GetKey(right);
		bool bLeft = Input.GetKey(left);


		if (bForward)
		{
			Vector2 norm = MathG.DegreeToVector(transform.eulerAngles.y,1);

			playerRigidbody.velocity = 
				new Vector3(norm.x, 0, -norm.y) 
				* playerData.MovementSpeed * Time.deltaTime;
		}
		else if (bBack)
		{
			Vector2 norm = MathG.DegreeToVector(transform.eulerAngles.y - 180,1);

			playerRigidbody.velocity = 
				new Vector3(norm.x, 0, -norm.y) * 
				playerData.MovementSpeed * Time.deltaTime;
		}
		else
		{
			playerRigidbody.velocity = new Vector3();
		}

		if (Input.GetKey(KeyCode.LeftShift))
		{
			playerRigidbody.velocity *= 2;
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void turnPlayer()
	{
		Vector3 newRotation = transform.eulerAngles;
		newRotation.y += Input.GetAxis("Mouse X") * playerData.mouseSensativityX;

		transform.eulerAngles = newRotation;
	}

	void turnCamera()
	{
		Vector3 newRotation = playerCamera.transform.eulerAngles;
		newRotation.x += Input.GetAxis("Mouse Y") * playerData.mouseSensativityY * playerData.isCameraInverted;

		playerCamera.transform.eulerAngles = newRotation;
	}
}
