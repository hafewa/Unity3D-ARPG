using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int cameraMult;
	public GameObject camPoint;
	public GameObject GFX;
	Transform GFXTransform;
	public Transform ModelRoot;

	//PlayerInfo
	
	//bool isGrounded;
	
	//Rigidbody playerRigidbody;
	CharacterController charController;
	PlayerData playerData;
	PlayerUI playerUI;
	BulletToPoint bulletToPoint;
	Animator animator;

	public float gravity;

	public LayerMask aimMask;
	public new GameObject camera;

	public Vector3 velocity = Vector3.zero;
	//Keys

	public float maxHealth = 100;

	[SerializeField]
	private float _health;

	public float health
	{
		get {return _health;}
		set {_health = value;}
	}

	bool wasDamaged = false;

	bool bForward;
	bool bBack;
	bool bRight;
	bool bLeft;
	bool bJump;

	// Use this for initialization
	void Start () 
	{
		GFXTransform = GFX.GetComponent<Transform>();
		//playerRigidbody = GetComponent<Rigidbody>();
		playerData = GetComponent<PlayerData>();
		playerUI = GetComponent<PlayerUI>();

		charController = GetComponent<CharacterController>();

		bulletToPoint = GetComponentInChildren<BulletToPoint>();
		animator = GetComponentInChildren<Animator>();

		_health = maxHealth;

		Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Movement();
		
		if(Input.GetButton("Fire1"))
		{
			//Debug.DrawRay(camera.transform.position,camera.transform.forward * 100,Color.red,1);
			RaycastHit hit; 
			if (Physics.Raycast(camera.transform.position,camera.transform.forward,out hit,100, aimMask))
			{
				bulletToPoint.ShootPosition = hit.point;
				bulletToPoint.Shoot();
			}
			else
			{
				bulletToPoint.ShootPosition = camera.transform.forward * cameraMult;
				bulletToPoint.Shoot();
			}
			//(camera.transform.position, camera.transform.right,100,aimMask);
			//SetGFXRotation();
		}

		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	void Update()
	{
		bForward = Input.GetKey(playerData.forward);
		bBack = Input.GetKey(playerData.back);
		bRight = Input.GetKey(playerData.right);
		bLeft = Input.GetKey(playerData.left);

		wasDamaged = false;
	}

	void Movement()
	{	
		//print(charController.isGrounded);

		velocity.y += -gravity;

		if (bForward)
		{
			SetGFXRotation();
			Vector2 norm = MathG.DegreeToVector2D(camPoint.transform.eulerAngles.y,1);
			MoveByVelocity(norm);
		}
		else if(bBack)
		{
			SetGFXRotation();
			Vector2 norm = MathG.DegreeToVector2D(camPoint.transform.eulerAngles.y - 180,1);
			MoveByVelocity(norm);
		}
		else if(bRight)
		{
			SetGFXRotation();
			Vector2 norm = MathG.DegreeToVector2D(camPoint.transform.eulerAngles.y + 90,1);
			MoveByVelocity(norm);

		}
		else if(bLeft)
		{
			SetGFXRotation();
			Vector2 norm = MathG.DegreeToVector2D(camPoint.transform.eulerAngles.y - 90,1);
			MoveByVelocity(norm);
		}
		else
		{
			velocity = new Vector3(0,velocity.y,0);
		}

		bJump = Input.GetKey(playerData.jump);
		if (bJump && charController.isGrounded)
		{
			velocity.y = playerData.jumpForce;
		}

		bool bSprint = Input.GetKey(playerData.sprint);
		if(bSprint)
		{
			Vector3 newVel = new Vector3(velocity.x, 0, velocity.z);
			newVel *= playerData.SprintMultiplier;
			newVel.y = velocity.y;
			velocity = newVel;
		}

		charController.Move(velocity * Time.fixedDeltaTime);
		if(charController.isGrounded) {velocity.y = 0;}

		if(velocity.magnitude != 0)
		{
			animator.SetBool("IsRunning", true);
		}
		else 
		{
			animator.SetBool("IsRunning", false);
		}
	}

	void SetGFXRotation()
	{
		//TODO Smooth out this transition
		Vector3 newGFXRotation = GFXTransform.eulerAngles;
		newGFXRotation.y = camPoint.GetComponent<Transform>().eulerAngles.y;
		GFXTransform.eulerAngles = newGFXRotation;
		ResetModelTransform();
	}

	void ResetModelTransform()
	{
		Vector3 newModelRotation = ModelRoot.localEulerAngles;
		newModelRotation.y = 90;
		ModelRoot.localEulerAngles = newModelRotation;

		Vector3 newPosition = ModelRoot.localPosition;
		newPosition = new Vector3(0,-1,0);
		ModelRoot.localPosition = newPosition;


	}

	void MoveByVelocity(Vector3 norm)
	{
		Vector3 newVel = new Vector3(norm.x, 0, -norm.y) * playerData.MovementSpeed;
		newVel.y = velocity.y;
		velocity = newVel;
	}

	public void Damage(float damage)
	{
		if(wasDamaged){return;}

		//print("Player - Damaged " + damage);
		_health -= damage;
		playerUI.UpdateHealthBar();
		wasDamaged = true;
		//Death
		if (_health <= 0)
		{
			_health = 0;
			LevelManager.LoadScene(0);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//if (hit.gameObject.tag == "EBullet")
		//{
		//	Bullet bull = hit.gameObject.GetComponent<Bullet>();
		//	Damage(bull.damage);
		//	bull.gameObject.SetActive(false);
		//}
	}
}