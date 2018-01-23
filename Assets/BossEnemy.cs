using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{

    float health;
    public float maxHealth;
    public Slider healthBar;
    public BossEye bossEye;
	public BulletCircle centerCircle;

    void Start()
    {
		healthBar.gameObject.SetActive(true);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		bossEye.Shoot();
		centerCircle.Shoot();
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = health / maxHealth;
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
		healthBar.gameObject.SetActive(false);
    }
}
