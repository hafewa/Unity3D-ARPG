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

		float newAngleStart = transform.eulerAngles.y + angleStart;
		float newAngleEnd = transform.eulerAngles.y + angleEnd;

        for (int i = 0; i < numberBulletsPerBurst; ++i)
        {
            if((Random.RandomRange(0f,1f) > bulletTwoChance) && randomBullet)
            {
                obj = BulletManager2.GetNextBullet();
            }
            else
            {
                obj = bulletManager.GetNextBullet();
            }

            if (obj != null)
            {
                Vector3 velocity = MathG.DegreeToVector2D(((newAngleEnd - newAngleStart) / numberBulletsPerBurst * i) + newAngleStart   , 1);
                obj.GetComponent<Bullet>().Reset(pos, new Vector3(velocity.x, 0, velocity.y));
                
            }
        }
        timer = 0;
        canShoot = false;
        return true;
    }
}
