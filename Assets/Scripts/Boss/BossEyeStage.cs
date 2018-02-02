using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEyeStage : MonoBehaviour
{
    Enemy[] eyes;
	public bool isAllEyesDead;
	public bool hasMoved;
	public float rotationSpeed;
	public bool isRotatingClockwise;
	
    void Start()
    {
        eyes = gameObject.GetComponentsInChildren<Enemy>();
    }

    void Update()
    {
		float modifier = 1f;
		if(isRotatingClockwise)
		{
			modifier = -1f;
		}
		transform.Rotate(new Vector3(0,rotationSpeed * Time.deltaTime * modifier,0));
		if(!isAllEyesDead)
		{
			isAllEyesDead = checkIfAllEyesDead();
		}
    }

    bool checkIfAllEyesDead()
    {
        foreach (var item in eyes)
        {
            if (item.gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
