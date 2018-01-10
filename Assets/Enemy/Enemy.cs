using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    BulletManager bulletManager;
    GameObject player;

    public BulletManager.BulletPattern pattern = BulletManager.BulletPattern.CIRCLE;

    public int numBurstBullets;
    public float angleStart;
    public float angleEnd;

    private float health;
    public float maxHealth;

    public bool isMortal = true;

	// Use this for initialization
	void Start ()
    {
        bulletManager = GetComponentInChildren<BulletManager>();
        player = GameObject.Find("Player");
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (pattern)
        {
            case BulletManager.BulletPattern.CIRCLE:
                if(bulletManager.Shoot(BulletManager.BulletPattern.CIRCLE, numBurstBullets, angleStart, angleEnd))
				{
					//numBurstBullets++;
				}
                break;
            case BulletManager.BulletPattern.TRACE:
                bulletManager.Shoot(player.gameObject.transform.position);
                break;
        }


		Vector3 newPos = transform.position;
		newPos.y += Mathf.Sin(Time.timeSinceLevelLoad)/80;
		transform.position = newPos;

		Vector3 newRot = transform.eulerAngles;
		newRot.y += 20 * Time.deltaTime;
		transform.eulerAngles = newRot;

		
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PBullet" && isMortal)
        {
            damage(collider.gameObject.GetComponent<Bullet>().damage);
            collider.gameObject.SetActive(false);
            print(name + " - TRIGGERED");
        }
    }
    

    void damage(float dam)
    {
        health = health - dam;
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}