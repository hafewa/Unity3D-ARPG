using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BulletManager))]
public class BulletEmitter : MonoBehaviour 
{
	public BulletManager bulletManager;
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
        }
	}

	public virtual bool Shoot()
	{
		return true;
	}
}
