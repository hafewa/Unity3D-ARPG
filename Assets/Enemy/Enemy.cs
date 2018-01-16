using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    GameObject player;
    BulletEmitter[] bulletEmitters;
    private float health;
    public float maxHealth;
    public bool isTargetingPlayer;

    public bool isMortal = true;

	// Use this for initialization
	void Start ()
    {
        bulletEmitters = GetComponentsInChildren<BulletEmitter>();

        player = GameObject.Find("Player");
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (var element in bulletEmitters)
        {
            if (element is BulletToPoint && isTargetingPlayer == true)
            {
                BulletToPoint bulletToPoint = element as BulletToPoint;
                bulletToPoint.ShootPosition = player.transform.position + new Vector3(0,1,0);
            }
            element.Shoot();
        }

		//Vector3 newPos = transform.position;
		//newPos.y += Mathf.Sin(Time.timeSinceLevelLoad)/80;
		//transform.position = newPos;

		Vector3 newRot = transform.eulerAngles;
		newRot.y += 1 * Time.deltaTime;
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