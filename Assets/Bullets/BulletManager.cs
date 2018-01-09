using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public GameObject bullet;

    public int maxBullets = 10;
    private int numBullets = 0;
    List<GameObject> bullets = new List<GameObject>();
    bool willGrow = true;

    float timer = 0;
    public float bulletDelay = 0.1f;
    bool canShoot = true;

    public enum BulletPattern
    {
        CIRCLE,
        TRACE
    }

    // Use this for initialization
    //void Start ()
    //{
    //}

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= bulletDelay)
        {
            canShoot = true;
        }
	}

    public bool Shoot(Vector3 pos)
    {
        if (!canShoot) { return false; }
        GameObject bull = getNextBullet();
        if ( bull != null)
        {
            Vector3 velocity = MathG.NormalVector( pos - transform.position);
            bull.GetComponent<Bullet>().Reset(gameObject.transform.position, velocity);
            canShoot = false;
            timer = 0;
            return true;
        }
        return false;
    }

    public bool Shoot(BulletPattern pattern, int num = 8, float angleStart = 0, float angleEnd = 360)
    {
        if (!canShoot) { return false; }

        Vector3 pos = gameObject.transform.position;
        GameObject obj;

		angleStart += transform.eulerAngles.y;
		angleEnd += transform.eulerAngles.y;

        switch (pattern)
        {
            case BulletPattern.CIRCLE:
                for (int i = 0; i < num; ++i)
                {
                    obj = getNextBullet();
                    if (obj != null)
                    {
						Vector3 velocity = MathG.DegreeToVector2D(((angleEnd - angleStart) / num * i) + angleStart, 1);
                        obj.GetComponent<Bullet>().Reset(pos, new Vector3(velocity.x, 0, velocity.y) );
                    }
                }
                canShoot = false;
                timer = 0;
                break;
        }
        
        return true;
    }



    public GameObject getNextBullet()
    {
        for (int i = 0; i < numBullets; ++i)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = Instantiate(bullet);
            bullets.Add(obj);
            ++numBullets;
            if(numBullets >= maxBullets){ willGrow = false; }
            return obj;
        }
        return null;
    } 
}