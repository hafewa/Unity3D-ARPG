using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSphere : BulletEmitter 
{
	public int numberBulletsPerRing = 10;
	public int numberOfRings = 6;
	public float angleSphereStart = 0;
	public float angleSphereEnd = 360;

	public float angleRingStart = 0;
	public float angleRingEnd = 360;

	public override bool Shoot()
	{
		if (!canShoot) { return false; }

		Vector3 oldRot = transform.eulerAngles;
        Vector3 pos = transform.position;
        GameObject currentBullet;

		for (int i = 0; i < numberOfRings; ++i)
        {
			for (int x = 0; x < numberBulletsPerRing; ++x)
    	    {
				currentBullet = bulletManager.GetNextBullet();
            	if (currentBullet != null)
            	{
					Vector3 newCircleRot = new Vector3(
						(angleRingEnd - angleRingStart)/numberBulletsPerRing * x, 
						(angleSphereEnd - angleSphereStart)/numberOfRings * i);

					currentBullet.GetComponent<Bullet>().ResetBasedOnRotation(pos,newCircleRot);
				}
			}
			Vector3 newSphereRot = transform.eulerAngles;
			newSphereRot.y += (angleSphereEnd - angleSphereStart)/numberOfRings;
			transform.eulerAngles = newSphereRot;
		}
		transform.eulerAngles = oldRot;

		timer = 0;
		canShoot = false;
		return true;
	}
}
