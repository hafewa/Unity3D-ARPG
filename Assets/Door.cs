using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float moveUpDistance;
	public float moveSpeed;
	public bool isMovingUp;
	public bool isMovingDown;
	public float snappingDistance = 0.1f;

	private Vector3 originPos;
	private Vector3 movePos;

	void Start()
	{
		originPos = transform.position;	
	}

	// Update is called once per frame
	void Update () 
	{
		movePos = originPos + new Vector3(0,moveUpDistance,0);
		if(isMovingUp)
		{
			//Move to pos
			transform.Translate(transform.up.normalized * moveSpeed * Time.deltaTime);

			if(Vector3.Distance(transform.position, movePos) <= snappingDistance)
			{
				transform.position = movePos;
				isMovingUp = false;
			}
		}
		else if (isMovingDown)
		{
			transform.Translate(-transform.up.normalized * moveSpeed * Time.deltaTime);

			if(Vector3.Distance(transform.position, originPos) <= snappingDistance)
			{
				transform.position = originPos;
				isMovingDown = false;
			}
		}
		
	}
}
