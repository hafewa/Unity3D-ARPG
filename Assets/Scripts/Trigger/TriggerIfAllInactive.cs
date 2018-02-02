using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIfAllInactive : MonoBehaviour {

	public GameObject[] objects;
	public GameObject[] triggerObjects;
	private bool isTriggered;
	
	// Update is called once per frame
	void Update () 
	{
		if(isTriggered){return;}
		foreach (var item in objects)
		{
			if(item.activeInHierarchy)
			{
				return;
			}
		}

		foreach (var item in triggerObjects)
		{
			item.GetComponent<ITriggerable>().Trigger();
		}
		isTriggered = true;
	}
}
