using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Camera playerCamera;
	private Rigidbody playerRigidbody;
	private PlayerData playerData;

	public GameObject attackCollider;


	bool isAttacking = false;
	float attackTimer = 0;
	float attackTime = 0.5f;
	

	

	KeyCode forward = KeyCode.W;
	KeyCode right = KeyCode.D;
	KeyCode left = KeyCode.A;
	KeyCode back = KeyCode.S;

	bool isJumping = false;

	// Use this for initialization
	void Start () 
	{
		playerRigidbody = GetComponent<Rigidbody>();
		playerData = GetComponent<PlayerData>();

		playerCamera = GetComponentInChildren<Camera>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		attackCollider.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerInput();

		//Jumping
		if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
		{
			playerRigidbody.AddForce(new Vector3(0,playerData.jumpForce,0));
			isJumping = true;
		}

		//Attack
		if (Input.GetMouseButtonDown(0))
		{
			attackCollider.SetActive(true);
			isAttacking = true;
		}

		if(isAttacking)
		{
			attackTimer += Time.deltaTime;

			if (attackTimer >= attackTime)
			{
				attackTimer = 0;
				isAttacking = false;
				attackCollider.SetActive(false);
			}
		}
	}

	//Player input
	void playerInput()
	{
		bool bForward = Input.GetKey(forward);
		bool bBack = Input.GetKey(back);
		bool bRight = Input.GetKey(right);
		bool bLeft = Input.GetKey(left);

		turnPlayer();
		turnCamera();


		//Forward and back movement
		if (bForward)
		{
			Vector2 norm = MathG.DegreeToVector(transform.eulerAngles.y,1);
			applyMovementForce(norm);
		}
		else if (bBack)
		{
			Vector2 norm = MathG.DegreeToVector(transform.eulerAngles.y - 180,1);
			applyMovementForce(norm);
		}
		//Strafeing movement
		else if(bRight)
		{
			Vector2 norm = MathG.DegreeToVector(transform.eulerAngles.y + 90,1);
			applyMovementForce(norm);
		}
		else if (bLeft)
		{
			Vector2 norm = MathG.DegreeToVector(transform.eulerAngles.y - 90,1);
			applyMovementForce(norm);
		}

		//if (Input.GetKey(KeyCode.LeftShift))
		//{
		//	playerRigidbody.velocity *= 2;
		//}

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void applyMovementForce(Vector3 norm)
	{
			Vector3 newVel = new Vector3(norm.x, 0, -norm.y) * 
								playerData.MovementSpeed * Time.deltaTime;

			//playerRigidbody.velocity += newVel;
			playerRigidbody.AddForce(newVel);
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

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Ground")
		{
			isJumping = false;
		}
	}
}
