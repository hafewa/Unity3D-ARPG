using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEye : MonoBehaviour,IDamageable {

	public BossEnemy bossEnemy;
	public BulletCircle bulletCircleEye;
	public BulletToPoint bulletToPointEye;
	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	public void Shoot () 
	{
		bulletCircleEye.Shoot();
		bulletToPointEye.ShootPosition = player.transform.position + new Vector3(0,1,0);
		bulletToPointEye.Shoot();
	}

	public bool Damage(float damage)
	{	
		bossEnemy.Damage(damage);
		return true;
	}
}
