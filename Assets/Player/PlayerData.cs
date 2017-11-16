using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour 
{

	[SerializeField]
	private float _movementSpeed = 0.5f;

	public float jumpForce = 100;

	public float mouseSensativityX = 5f;
	public float mouseSensativityY = 1f;
	
	//1 for invert / -1 for nonInverted
	public int isCameraInverted = -1;

	public float MovementSpeed
	{
    	get 
		{ 
			return _movementSpeed; 
		}
    	set 
		{ 
			_movementSpeed = value; 
		}
	}

}
