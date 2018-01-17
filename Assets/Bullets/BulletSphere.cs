using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSphere : BulletEmitter 
{
	public int numberBulletPerCircle = 10;
	public int numberOfCircles = 6;
	public float angleSphereStart = 0;
	public float angleSphereEnd = 360;

	public float angleCircleStart = 0;
	public float angleCircleEnd = 360;

	public override bool Shoot()
	{
		if (!canShoot) { return false; }

		Vector3 oldRot = transform.eulerAngles;
        Vector3 pos = transform.position;
        GameObject currentBullet;

		for (int i = 0; i < numberOfCircles; ++i)
        {
			for (int x = 0; x < numberBulletPerCircle; ++x)
    	    {
				currentBullet = bulletManager.GetNextBullet();
            	if (currentBullet != null)
            	{
					Vector3 newCircleRot = new Vector3(
						(angleCircleEnd - angleCircleStart)/numberBulletPerCircle * x, 
						(angleSphereEnd - angleSphereStart)/numberBulletPerCircle * i);

					currentBullet.GetComponent<Bullet>().ResetBasedOnRotation(pos,newCircleRot);
				}
			}
			Vector3 newSphereRot = transform.eulerAngles;
			newSphereRot.y += (angleSphereEnd - angleSphereStart)/numberOfCircles;
			transform.eulerAngles = newSphereRot;
		}
		transform.eulerAngles = oldRot;

		timer = 0;
		canShoot = false;
		return true;
	}
}
