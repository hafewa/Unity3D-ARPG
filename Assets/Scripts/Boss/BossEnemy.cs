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

    public BossEyeStage[] eyesStages;

    public AudioClip deathSong;
    enum BossEyesStates
    {
        IDLE,
        STAGE_ONE_ENTRANCE,
        STAGE_ONE,
        STAGE_ONE_EXIT,
        STAGE_TWO_ENTRANCE,
        STAGE_TWO,
        STAGE_THREE,
        DEATH
    }

    [SerializeField]
    BossEyesStates bossState = BossEyesStates.STAGE_ONE_ENTRANCE;

    void Start()
    {
        health = maxHealth;
        transform.localPosition = new Vector3(0, 150, 0);
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

                if (HealthPercent() <= 0.75)
                {
                    healthBar.gameObject.SetActive(false);
                    bossState = BossEyesStates.STAGE_ONE_EXIT;
                }
                break;
            case BossEyesStates.STAGE_ONE_EXIT:
                if (Move(stageOneExitPosition.transform.position, 0.5f))
                {
                    bossState = BossEyesStates.STAGE_TWO_ENTRANCE;
                    stageTwoBody.SetActive(true);
                    headTracking.isTracking = false;
                    headTracking.gameObject.transform.eulerAngles = new Vector3(-90, 0, 0);
                }
                break;
            case BossEyesStates.STAGE_TWO_ENTRANCE:
                if (Move(stageTwoPosition.transform.position, 8f))
                {
                    bossState = BossEyesStates.STAGE_TWO;
                }
                break;
            case BossEyesStates.STAGE_TWO:
                foreach (var item in eyesStages)
                {
                    if (item.isAllEyesDead && !item.hasMoved)
                    {
                        gameObject.transform.Translate(new Vector3(0, -15, 0));
                        item.hasMoved = true;
                    }
                }
                for (int i = 0; i < 3 ; i++)
                {
                    if(eyesStages[i].hasMoved)
                    {
                        eyesStages[i].gameObject.GetComponent<BulletCircle>().isShooting = false;
                        eyesStages[i + 1].gameObject.GetComponent<BulletCircle>().isShooting = true;
                    }
                }

                if (checkIfAllEyesDead())
                {
                    bossState = BossEyesStates.STAGE_THREE;
                    headTracking.isTracking = true;
                    healthBar.gameObject.SetActive(true);
                    health = maxHealth * 0.25f;
                    UpdateHealthBar();
                }
                break;
            case BossEyesStates.STAGE_THREE:
                bossEye.Shoot();
                centerCircle.Shoot();
                break;
            case BossEyesStates.DEATH:
                Move(stageOneExitPosition.transform.position,0.1f);
                break;
            default:
                break;
        }
    }

    bool checkIfAllEyesDead()
    {
        foreach (var item in eyesStages)
        {
            if (!item.isAllEyesDead)
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
        bossEye.gameObject.SetActive(false);
        bossState = BossEyesStates.DEATH;
        GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().Play(deathSong);
        GameManager.gameState = GameManager.GameStates.ENDING;
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
