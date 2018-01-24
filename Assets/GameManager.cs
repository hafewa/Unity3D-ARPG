using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static public string currentCheckpoint;
	static GameObject instance;
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
}
