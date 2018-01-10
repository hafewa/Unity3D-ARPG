using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public GameObject bullet;

    public int maxBullets = 10;
    private int numBullets = 0;
    List<GameObject> bullets = new List<GameObject>();
    bool willGrow = true;

    public GameObject GetNextBullet()
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