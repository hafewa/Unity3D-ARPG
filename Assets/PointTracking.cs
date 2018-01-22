using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTracking : MonoBehaviour {

	public bool isTracking;
	private GameObject _objectToTrack;
	public string tagOfObjectToTrack;
	void Start()
	{
		_objectToTrack = GameObject.FindGameObjectWithTag(tagOfObjectToTrack);
	}
	void Update () 
	{
		if(isTracking)
		{
			transform.LookAt(_objectToTrack.transform.position, transform.up);
		}
		
	}
}
