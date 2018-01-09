using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 10;
    public float speed = 10;

    private float life = 0;
    public  float maxLife = 1;

    private Rigidbody bRigidbody;

	// Use this for initialization
	//void Start ()
    //{
    //   //bRigidbody = gameObject.GetComponent<Rigidbody2D>();
    //}
	
	// Update is called once per frame
	void Update ()
    {
        if (life >= maxLife)
        {
            gameObject.SetActive(false);
        }
        else
        {
            life += Time.deltaTime;
        }
	}

    public void Reset()
    {
        life = 0;
        gameObject.SetActive(true);
    }

    public void Reset(Vector3 position, Vector3 velocity)
    {
        gameObject.SetActive(true);
        if (bRigidbody == null)
        {
            bRigidbody = gameObject.GetComponent<Rigidbody>();
        }

        life = 0;
        //bRigidbody.position = pos;
		 bRigidbody.velocity = velocity * speed;
        gameObject.transform.position = position + velocity*2;
    }

	void OnTriggerEnter(Collider other)
	{
        gameObject.SetActive(false);
		if (other.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
        else if (other.tag == "PBullet" && gameObject.tag == "EBullet")
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
	}

	/*
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
        else if (collider.tag == "PBullet" && gameObject.tag == "EBullet")
        {
            collider.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
	*/
}