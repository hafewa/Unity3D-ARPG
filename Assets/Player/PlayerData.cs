using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour 
{
	[SerializeField]
	private float _movementSpeed = 100f;

	public float MovementSpeed
	{
		get{return _movementSpeed;}
		set{_movementSpeed = value;}
	}

	private float _sprintMultiplier = 2f;
	public float SprintMultiplier
	{
		get{return _sprintMultiplier;}
		set{_sprintMultiplier = value;}
	}

	public float jumpForce = 100;

	public KeyCode forward = KeyCode.W;
	public KeyCode back = KeyCode.S;
	public KeyCode left = KeyCode.A;
	public KeyCode right = KeyCode.D;
	public KeyCode jump = KeyCode.Space;
	public KeyCode sprint = KeyCode.LeftShift;
}
