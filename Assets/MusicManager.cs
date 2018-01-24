using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static GameObject instance;

    public AudioClip mainMenu;
    public AudioClip hangerEntrance;
    public AudioClip hangerBattle;
    public AudioClip elevator;
    public AudioClip cave;
    public AudioClip preBoss;
    public AudioClip bossStage1;
    public AudioClip bossStage2;
    public AudioClip bossDeath;
    public AudioClip ending;

    AudioClip playingClip;
    public AudioSource audioSource;

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
        audioSource.Play();
    }
    // Update is called once per frame

	public void Play(AudioClip clip)
	{
		audioSource.clip = clip;
		audioSource.Play();
	}

	public void Stop()
	{
		audioSource.Stop();
	}

	public void Pause()
	{
		audioSource.Pause();
	}

	public void UnPause()
	{
		audioSource.UnPause();
	}
}
