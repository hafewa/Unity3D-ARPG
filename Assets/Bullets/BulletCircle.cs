using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCircle : BulletEmitter 
{
	public int numberBulletsPerBurst = 8;
	public float angleStart = 0;
	public float angleEnd = 360;

	public override bool Shoot()
    {
        if (!canShoot) { return false; }

        Vector3 pos = gameObject.transform.position;
        GameObject obj;

		angleStart += transform.eulerAngles.y;
		angleEnd += transform.eulerAngles.y;

        for (int i = 0; i < numberBulletsPerBurst; ++i)
        {
            obj = bulletManager.GetNextBullet();
            if (obj != null)
            {
                Vector3 velocity = MathG.DegreeToVector2D(((angleEnd - angleStart) / numberBulletsPerBurst * i) + angleStart, 1);
                obj.GetComponent<Bullet>().Reset(pos, new Vector3(velocity.x, 0, velocity.y));
            }
        }
        canShoot = false;
        timer = 0;
        
        return true;
    }
}
