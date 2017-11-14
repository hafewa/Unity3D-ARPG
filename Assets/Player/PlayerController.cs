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
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerInput();
	}

	//Player input
	void playerInput()
	{
		bool bForward = Input.GetKey(forward);
		bool bBack = Input.GetKey(back);
		bool bRight = Input.GetKey(right);
		bool bLeft = Input.GetKey(left);

		if (bForward && bRight)
		{
			playerRigidbody.velocity =
				new Vector3(1,0,1) * playerData.MovementSpeed * Time.deltaTime;
		}
		else if (bForward && bLeft)
		{
			playerRigidbody.velocity =
				new Vector3(-1,0,1) * playerData.MovementSpeed * Time.deltaTime;
		}
		else if (bBack && bRight)
		{
			playerRigidbody.velocity =
				new Vector3(1,0,-1) * playerData.MovementSpeed * Time.deltaTime;
		}
		else if (bBack && bLeft)
		{
			playerRigidbody.velocity =
				new Vector3(-1,0,-1) * playerData.MovementSpeed * Time.deltaTime;
		}
		else if (bForward)
		{
			playerRigidbody.velocity = 
				new Vector3(0,0,1) * playerData.MovementSpeed * Time.deltaTime;
		}
		else if (bBack)
		{
			playerRigidbody.velocity = 
				new Vector3(0,0,-1) * playerData.MovementSpeed * Time.deltaTime;
		}
		else if (bRight)
		{
			playerRigidbody.velocity = 
				new Vector3(1,0,0) * playerData.MovementSpeed * Time.deltaTime;
		}
		else if (bLeft)
		{
			playerRigidbody.velocity = 
				new Vector3(-1,0,0) * playerData.MovementSpeed * Time.deltaTime;
		}
		else
		{
			playerRigidbody.velocity = new Vector3();
		}

		if (Input.GetKey(KeyCode.LeftShift))
		{
			playerRigidbody.velocity *= 2;
		}
	}
}
