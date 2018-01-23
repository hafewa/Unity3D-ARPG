using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSphere : BulletEmitter 
{
	public int numberBulletsPerRing = 10;
	public int numberOfRings = 6;
	public float angleSphereStart = 0;
	//360 will have doubles
	public float angleSphereEnd = 180;
	public float angleRingStart = 0;
	public float angleRingEnd = 360;
	public bool isRotating;
	public bool resetRotation;
	public Vector3 rotationSpeed;
	
	public override bool Shoot()
	{
		if (!canShoot) { return false; }

        Vector3 pos = transform.position;
        GameObject currentBullet;

		if(isRotating)
		{
			transform.Rotate(rotationSpeed * Time.deltaTime);
		}
		if(resetRotation)
		{
			resetRotation = false;
			transform.eulerAngles = Vector3.zero;
		}

		for (int i = 0; i < numberOfRings; ++i)
        {
			for (int x = 0; x < numberBulletsPerRing; ++x)
    	    {
				currentBullet = bulletManager.GetNextBullet();
            	if (currentBullet != null)
            	{
					Vector3 newCircleRot = new Vector3(
						transform.eulerAngles.x + 
						(angleRingEnd - angleRingStart)/numberBulletsPerRing * x, 
						transform.eulerAngles.y + 
						(angleSphereEnd - angleSphereStart)/numberOfRings * i);

					currentBullet.GetComponent<Bullet>().ResetBasedOnRotation(pos,newCircleRot);
				}
			}
			Vector3 newSphereRot = transform.eulerAngles;
			newSphereRot.y += (angleSphereEnd - angleSphereStart)/numberOfRings;
		}

		timer = 0;
		canShoot = false;
		return true;
	}
}
