using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActive : MonoBehaviour, ITriggerable 
{
	public bool startActive;
	public float activationTime;

	void Awake()
	{
		gameObject.SetActive(startActive);
	}

	public bool Trigger()
	{
		Invoke("Activate",activationTime);	
		return true;
	}

	void Activate()
	{
		gameObject.SetActive(!startActive);
	}
}
