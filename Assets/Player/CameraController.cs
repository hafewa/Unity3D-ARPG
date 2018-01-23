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

    public float maxAngleUp;
    public float maxAngleDown;
    public float cameraSpeed;
    int isCameraInverted = -1;

    Vector3 camOriginPosLocal;
    Vector3 rayCastPos;
    public GameObject fakeCamera;
    public GameObject player;
    public LayerMask maskForCamera;
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

        //print("Sign = " + Mathf.Sign(newRotationCamera.x) + " Value: " + (newRotationCamera.x));

        if (newRotationCamera.x > 180)
        {
            if (newRotationCamera.x < 360 - maxAngleUp)
            {
                //print("Too small");
                newRotationCamera.x = 360 - maxAngleUp;
            }
        }
        else
        {
            if (newRotationCamera.x > maxAngleDown)
            {
                //print("Too large");
                newRotationCamera.x = maxAngleDown;
            }
        }
        currentCamera.transform.eulerAngles = newRotationCamera;

        Vector3 newRotationPoint = camPoint.transform.eulerAngles;
        newRotationPoint.y += Input.GetAxis("Mouse X") * mouseSensativityX;
        camPoint.transform.eulerAngles = newRotationPoint;


        Vector3 dir = player.transform.position - fakeCamera.transform.position;
        Debug.DrawLine(player.transform.position, player.transform.position + -dir.normalized * 10);
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, -dir.normalized, out hit, 10, maskForCamera))
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
            transform.localPosition = Vector3.Lerp(transform.localPosition, player.transform.localPosition - new Vector3(0, 2.4f, 0), cameraSpeed * Time.deltaTime);

        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, camOriginPosLocal, cameraSpeed * Time.deltaTime);
        }

    }
}
