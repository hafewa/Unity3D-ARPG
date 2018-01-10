using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletToPoint : BulletEmitter 
{
	[SerializeField]
	private Vector3 _shootPosition;

	public Vector3 ShootPosition
	{
		get { return _shootPosition; }
		set { _shootPosition = value; } 
	}

	public override bool Shoot()
    {
        if (!canShoot) { return false; }
        GameObject bull = bulletManager.GetNextBullet();
        if ( bull != null)
        {
            Vector3 velocity = MathG.NormalVector( _shootPosition - transform.position);
            bull.GetComponent<Bullet>().Reset(gameObject.transform.position, velocity);
            canShoot = false;
            timer = 0;
            return true;
        }
        return false;
    }
}
