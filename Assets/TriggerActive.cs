using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActive : MonoBehaviour, ITriggerable 
{
	public bool startActive;

	void Start()
	{
		gameObject.SetActive(startActive);
	}

	public bool Trigger()
	{
		gameObject.SetActive(!startActive);
		return true;
	}
}
