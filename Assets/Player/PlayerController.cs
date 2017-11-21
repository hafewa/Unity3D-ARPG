using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject camPoint;
	public GameObject GFX;
	Transform GFXTransform;

	//PlayerInfo
	
	float groundCheckDistance = 0.1f;
	
	bool isGrounded;
	
	Rigidbody playerRigidbody;

	PlayerData playerData;

	//Keys

	// Use this for initialization
	void Start () 
	{
		GFXTransform = GFX.GetComponent<Transform>();
		playerRigidbody = GetComponent<Rigidbody>();
		playerData = GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement();

		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void Movement()
	{
		bool bForward = Input.GetKey(playerData.forward);
		bool bBack = Input.GetKey(playerData.back);
		bool bRight = Input.GetKey(playerData.right);
		bool bLeft = Input.GetKey(playerData.left);

		if (bForward)
		{
			SetGFXRotation();
			Vector2 norm = MathG.DegreeToVector(camPoint.transform.eulerAngles.y,1);
			MoveByVelocity(norm);
		}
		else if(bBack)
		{
			SetGFXRotation();
			Vector2 norm = MathG.DegreeToVector(camPoint.transform.eulerAngles.y - 180,1);
			MoveByVelocity(norm);
		}
		else if(bRight)
		{
			SetGFXRotation();
			Vector2 norm = MathG.DegreeToVector(camPoint.transform.eulerAngles.y + 90,1);
			MoveByVelocity(norm);

		}
		else if(bLeft)
		{
			SetGFXRotation();
			Vector2 norm = MathG.DegreeToVector(camPoint.transform.eulerAngles.y - 90,1);
			MoveByVelocity(norm);
		}
		else
		{
			playerRigidbody.velocity = new Vector3(0,playerRigidbody.velocity.y,0);
		}

		bool bJump = Input.GetKey(playerData.jump);
		if (bJump && isGrounded)
		{
			playerRigidbody.AddForce(new Vector3(0,playerData.jumpForce,0));
			isGrounded = false;
		}

		bool bSprint = Input.GetKey(playerData.sprint);
		if(bSprint)
		{
			Vector3 newVel = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
			newVel *= playerData.SprintMultiplier;
			newVel.y = playerRigidbody.velocity.y;
			playerRigidbody.velocity = newVel;
		}
	}

	void SetGFXRotation()
	{
		//TODO Smooth out this transition
		Vector3 newGFXRotation = GFXTransform.eulerAngles;
		newGFXRotation.y = camPoint.GetComponent<Transform>().eulerAngles.y;
		GFXTransform.eulerAngles = newGFXRotation;
	}

	void MoveByVelocity(Vector3 norm)
	{
		Vector3 newVel = new Vector3(norm.x, 0, -norm.y) * playerData.MovementSpeed * Time.deltaTime;
		newVel.y = playerRigidbody.velocity.y;
		playerRigidbody.velocity = newVel;
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
	}
}

