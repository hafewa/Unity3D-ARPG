using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ITriggerable {

	public float moveDistance;
	public float moveSpeed;
	public bool isMovingUp;
	public bool isMovingDown;
	public bool isUp;
	public bool isDown;
	public float snappingDistance = 0.1f;

	private Vector3 originPos;
	private Vector3 movePos;

	void Start()
	{
		if(isUp)
		{
			originPos = transform.position - new Vector3(0,moveDistance,0);
			movePos = transform.position;
		}
		else
		{
            originPos = transform.position;
            movePos = originPos + new Vector3(0, moveDistance, 0);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(isMovingUp)
		{
			//Move to pos
			isDown = false;
			transform.Translate(transform.up.normalized * moveSpeed * Time.deltaTime);

			if(Vector3.Distance(transform.position, movePos) <= snappingDistance)
			{
				transform.position = movePos;
				isMovingUp = false;
				isUp = true;
			}
		}
		else if (isMovingDown)
		{
			isUp = false;
			transform.Translate(-transform.up.normalized * moveSpeed * Time.deltaTime);
			
			if(Vector3.Distance(transform.position, originPos) <= snappingDistance)
			{
				transform.position = originPos;
				isMovingDown = false;
				isDown = true;
			}
		}
		
	}

	public bool Trigger()
	{
		if (isUp)
		{
			isMovingDown = true;
			return true;
		}
		else if (isDown)
		{
			isMovingUp = true;
			return true;
		}

		return false;
	}
}
