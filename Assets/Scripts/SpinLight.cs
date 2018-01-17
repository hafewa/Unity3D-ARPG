using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLight : MonoBehaviour {
	public float rotateSpeed;

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate( new Vector3(0,rotateSpeed * Time.deltaTime,0));
	}
}
