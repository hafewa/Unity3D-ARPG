using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour, ITriggerable 
{
	public AudioClip song;
	public bool doesTriggerOnStart;

	void Start()
	{
		Trigger();
	}

	public bool Trigger()
	{
		GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().Play(song);
		return true;
	}
}
