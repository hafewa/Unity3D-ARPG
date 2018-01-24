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

    public float speed;
    public GameObject stageOnePosition;

    enum BossEyesStates
    {
        IDLE,
        ENTRANCE,
        STAGEONE,
        STAGETWO
    }

    BossEyesStates bossState = BossEyesStates.ENTRANCE;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        switch (bossState)
        {
            case BossEyesStates.IDLE:
                break;
            case BossEyesStates.ENTRANCE:
                transform.Translate((stageOnePosition.transform.position - transform.position).normalized * speed * Time.deltaTime);

                if(Vector3.Distance(stageOnePosition.transform.position, transform.position) <= 0.1f)
                {
                    transform.position = stageOnePosition.transform.position;
                    bossState = BossEyesStates.STAGEONE;
                }
                break;

            case BossEyesStates.STAGEONE:
                healthBar.gameObject.SetActive(true);
                bossEye.Shoot();
                centerCircle.Shoot();
                UpdateHealthBar();

                if(HealthPercent() <= 0.75)
                {
                    bossState = BossEyesStates.STAGETWO;
                }

                break;

            default:
                break;
        }
    }

    void UpdateHealthBar()
    {
        healthBar.value = HealthPercent();
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

    float HealthPercent()
    {
        return health / maxHealth;
    }

    void Death()
    {
        healthBar.gameObject.SetActive(false);
    }
}
