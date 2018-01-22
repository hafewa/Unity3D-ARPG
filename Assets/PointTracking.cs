using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTracking : MonoBehaviour {

	public bool isTracking;
	public GameObject objectToTrack;
	public string tagOfObjectToTrack;

	// Update is called once per frame
	void Update () 
	{
		if(isTracking)
		{
			transform.LookAt(objectToTrack.transform.position, transform.up);
		}
		
	}
}
