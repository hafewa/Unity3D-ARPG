using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletManager))]
public class BulletEmitter : MonoBehaviour 
{
	public bool isShooting;
	public BulletManager bulletManager;
	public BulletManager BulletManager2;
	public float bulletTwoChance;
	public bool randomBullet;
	public float bulletDelay = 0.1f;
	protected float timer = 0;
	protected bool canShoot = true;

	protected virtual void Start()
	{
		if (bulletManager == null)
		{
			bulletManager = GetComponent<BulletManager>();
		}
	}

	protected virtual void Update()
	{
		timer += Time.deltaTime;
        if (timer >= bulletDelay)
        {
            canShoot = true;
			if(isShooting)
			{
				Shoot();
			}
        }
	}

	public virtual bool Shoot()
	{
		return true;
	}
}
