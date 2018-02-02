using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static public string currentCheckpoint;
    static public GameStates gameState;

	static GameObject instance;

    public string setCheckpointOnStart;
    public bool setCheckPoint;

    public enum GameStates
    {
        RUNNING,
        ENDING,
        EXITING
    }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = gameObject;
        }
        else if (gameObject != instance)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (setCheckPoint)
        {
            currentCheckpoint = setCheckpointOnStart;
        }
    }
}
