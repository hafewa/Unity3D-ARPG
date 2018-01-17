using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    GameObject player;
    BulletEmitter[] bulletEmitters;
    private float health;
    public float maxHealth;
    public bool isTargetingPlayer;

    public bool isMortal = true;


    RectTransform healthBarTransform;
    Camera playerCamera;
    public GameObject healthBarPrefab;
    Slider healthBarSlider;
    GameObject healthBarObject;



	// Use this for initialization
	void Start ()
    {
        bulletEmitters = GetComponentsInChildren<BulletEmitter>();

        player = GameObject.Find("Player");
        health = maxHealth;

        healthBarObject = Instantiate(healthBarPrefab, 
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>()
        );
        healthBarTransform = healthBarObject.GetComponent<RectTransform>();
        healthBarSlider = healthBarObject.GetComponent<Slider>();

        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

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
        
        healthBarTransform.anchoredPosition = 
            RectTransformUtility.WorldToScreenPoint(
                playerCamera,transform.position + new Vector3(0,2,0)
                );
        
		
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PBullet" && isMortal)
        {
            damage(collider.gameObject.GetComponent<Bullet>().damage);
            collider.gameObject.SetActive(false);
            //print(name + " - TRIGGERED");
        }
    }
    
    void UpdateHealthBar()
    {
        healthBarSlider.value = health/maxHealth;
    }
    
    void damage(float dam)
    {
        health = health - dam;
        UpdateHealthBar();

        if(health <= 0)
        {
            healthBarObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

}