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
    public PointTracking headTracking;

    public GameObject stageTwoBody;
    public float speed;
    public GameObject stageOnePosition;
    public GameObject stageOneExitPosition;
    public GameObject stageTwoPosition;

    public GameObject[] eyes;

    enum BossEyesStates
    {
        IDLE,
        STAGE_ONE_ENTRANCE,
        STAGE_ONE,
        STAGE_ONE_EXIT,
        STAGE_TWO_ENTRANCE,
        STAGE_TWO
    }

    [SerializeField]
    BossEyesStates bossState = BossEyesStates.STAGE_ONE_ENTRANCE;

    void Start()
    {
        health = maxHealth;
        transform.localPosition = new Vector3(0, 150, 0);
        eyes = GameObject.FindGameObjectsWithTag("Enemy");
        stageTwoBody.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (bossState)
        {
            case BossEyesStates.IDLE:
                break;
            case BossEyesStates.STAGE_ONE_ENTRANCE:
                if (Move(stageOnePosition.transform.position))
                {
                    bossState = BossEyesStates.STAGE_ONE;
                }
                break;

            case BossEyesStates.STAGE_ONE:
                healthBar.gameObject.SetActive(true);
                bossEye.Shoot();
                centerCircle.Shoot();
                UpdateHealthBar();

                if (HealthPercent() <= 0.75)
                {
                    bossState = BossEyesStates.STAGE_ONE_EXIT;
                }
                break;
            case BossEyesStates.STAGE_ONE_EXIT:
                if (Move(stageOneExitPosition.transform.position, 0.5f))
                {
                    bossState = BossEyesStates.STAGE_TWO_ENTRANCE;
                    stageTwoBody.SetActive(true);
                }
                break;
            case BossEyesStates.STAGE_TWO_ENTRANCE:
                if (Move(stageTwoPosition.transform.position, 8f))
                {
                    bossState = BossEyesStates.STAGE_TWO;
                }
                break;
            case BossEyesStates.STAGE_TWO:

                if (checkIfAllEyesDead())
                {
                    gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }

    bool checkIfAllEyesDead()
    {
        foreach (var item in eyes)
        {
            if (item.activeInHierarchy)
            {
                return false;
            }
        }

        return true;
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

    bool Move(Vector3 pos, float speedMod = 1f)
    {
        transform.Translate((pos - transform.position).normalized * speed * speedMod * Time.deltaTime);
        if (Vector3.Distance(pos, transform.position) <= 1.5f)
        {
            transform.position = pos;
            return true;
        }
        return false;
    }
}
