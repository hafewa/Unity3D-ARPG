using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Camera currentCamera;

    //Rotate around this point
    public GameObject camPoint;
    public float mouseSensativityX = 5f;
    public float mouseSensativityY = 1f;

    public LayerMask mask;
    public float cameraSpeed;
    int isCameraInverted = -1;

    Vector3 camOriginPosLocal;
	Vector3 rayCastPos;
	public GameObject fakeCamera;
    public GameObject player;
    void Start()
    {
        currentCamera = GetComponent<Camera>();

        camOriginPosLocal = currentCamera.gameObject.transform.localPosition;
		
        //StartCoroutine(fixCamera());
    }

    public bool canSeePlayer;


    IEnumerator fixCamera()
    {

		return null;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newRotationCamera = currentCamera.transform.eulerAngles;
        newRotationCamera.x += Input.GetAxis("Mouse Y") * mouseSensativityY * isCameraInverted;
        currentCamera.transform.eulerAngles = newRotationCamera;

        Vector3 newRotationPoint = camPoint.transform.eulerAngles;
        newRotationPoint.y += Input.GetAxis("Mouse X") * mouseSensativityX;
        camPoint.transform.eulerAngles = newRotationPoint;

        Vector3 dir = player.transform.position - fakeCamera.transform.position;
        Debug.DrawLine(player.transform.position, player.transform.position + -dir.normalized * 10);
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, -dir.normalized, out hit, 10))
        {
            if (hit.collider.tag != "fakeCamera")
            {
                canSeePlayer = false;
            }
            else
            {
                canSeePlayer = true;
            }
        }
        if (!canSeePlayer)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, player.transform.localPosition - new Vector3(0,2.4f,0), cameraSpeed * Time.deltaTime);
           
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, camOriginPosLocal, cameraSpeed * Time.deltaTime);
        }

    }
}
