using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForward : BulletEmitter 
{
	public override bool Shoot()
    {
		if (!canShoot) { return false; }
		GameObject bull = bulletManager.GetNextBullet();
		if(bull != null)
		{
			bull.GetComponent<Bullet>().
				ResetBasedOnRotation(transform.position,transform.TransformDirection(transform.forward));
			timer = 0;
			canShoot = false;
			return true;
		}

		return false;
	}
}
