using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
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

    public GameObject onDeathParticle;
    public float playerDetectionDistance;
    public LayerMask playerMask;

    public bool detectedPlayer;
    public bool isBox;
    public TriggerBOX boxOpenTrigger;


    // Use this for initialization
    void Start()
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
    void Update()
    {
        Debug.DrawRay(
            transform.position + new Vector3(0, 1, 0),
            ((player.transform.position + new Vector3(0, 1f, 0)) - transform.position).normalized);

        RaycastHit hit;
        Physics.Raycast(
            transform.position + new Vector3(0, 1, 0),
            ((player.transform.position + new Vector3(0, 1f, 0)) - transform.position).normalized,
            out hit,
            playerDetectionDistance,
            playerMask
            );
        if (hit.transform == null)
        {
            healthBarObject.SetActive(false);
            detectedPlayer = false;

            if (detectedPlayer && isBox)
            {
                if (boxOpenTrigger._isOpen)
                {
                    boxOpenTrigger.Trigger();
                }
            }
            return;
        }
        if (!(hit.transform.tag == "Player"))
        {
            healthBarObject.SetActive(false);
            detectedPlayer = false;

            if (detectedPlayer && isBox)
            {
                if (boxOpenTrigger._isOpen)
                {
                    boxOpenTrigger.Trigger();
                }
            }
            return;
        }
        detectedPlayer = true;

        if (detectedPlayer && isBox)
        {
            if (!boxOpenTrigger._isOpen)
            {
                boxOpenTrigger.Trigger();
            }
        }

        foreach (var element in bulletEmitters)
        {
            if (element is BulletToPoint && isTargetingPlayer == true)
            {
                BulletToPoint bulletToPoint = element as BulletToPoint;
                bulletToPoint.ShootPosition = player.transform.position + new Vector3(0, 1, 0);
            }
            element.Shoot();
        }
        //Vector3 newPos = transform.position;
        //newPos.y += Mathf.Sin(Time.timeSinceLevelLoad)/80;
        //transform.position = newPos;

        //Vector3 newRot = transform.eulerAngles;
        //newRot.y += 1 * Time.deltaTime;
        //transform.eulerAngles = newRot;

        healthBarObject.SetActive(true);
        healthBarTransform.anchoredPosition =
            RectTransformUtility.WorldToScreenPoint(
                playerCamera, transform.position + new Vector3(0, 2, 0)
                );


    }

    /*
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PBullet" && isMortal)
        {
            Damage(collider.gameObject.GetComponent<Bullet>().damage);
            collider.gameObject.SetActive(false);
            //print(name + " - TRIGGERED");
        }
    }
    */

    void UpdateHealthBar()
    {
        healthBarSlider.value = health / maxHealth;
    }

    public bool Damage(float damage)
    {
        health = health - damage;
        UpdateHealthBar();

        if (health <= 0)
        {
            Death();
        }

        return true;
    }

    void Death()
    {
        Instantiate(onDeathParticle, transform.position, Quaternion.identity);
        healthBarObject.SetActive(false);
        gameObject.SetActive(false);

        //Destroy(healthBarObject);
        //Destroy(gameObject);
    }

}