using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Camera currentCamera;
	// Use this for initialization
	
	//Rotate around this point
	public GameObject camPoint;

	public float mouseSensativityX = 5f;
	public float mouseSensativityY = 1f;

	int isCameraInverted = -1;

	void Start () 
	{
		currentCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newRotationCamera = currentCamera.transform.eulerAngles;
		newRotationCamera.x += Input.GetAxis("Mouse Y") * mouseSensativityY * isCameraInverted;
		currentCamera.transform.eulerAngles = newRotationCamera;

		Vector3 newRotationPoint = camPoint.transform.eulerAngles;
		newRotationPoint.y += Input.GetAxis("Mouse X") * mouseSensativityX;
		camPoint.transform.eulerAngles = newRotationPoint;
	}
}
