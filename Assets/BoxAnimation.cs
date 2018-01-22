using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnimation : MonoBehaviour {

	// Use this for initialization

	public bool isOpening;
	private bool isOpen;

	public GameObject[] cubes = new GameObject[8];

	private Vector3[] cubeOrigins = new Vector3[8];

	void Start () 
	{
		for (int i = 0; i < 8; i++)
		{
			cubeOrigins[i] = cubes[i].transform.localPosition;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isOpening)
		{
			for (int i = 0; i < 8; i++)
			{
				Vector3 pos = cubes[i].transform.localPosition;
				Vector3.Lerp(pos, 
					cubeOrigins[i] + new Vector3( Mathf.Sign(pos.x) * 0.25f, 
												  Mathf.Sign(pos.y) * 0.25f,
												  Mathf.Sign(pos.z) * 0.25f),
					1);
			}
		}
		else
		{
			for (int i = 0; i < 8; i++)
			{
				Vector3.Lerp(cubes[i].transform.localPosition,cubeOrigins[i],1);
			}
		}

	}
}
