using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIfAllInactive : MonoBehaviour {

	public GameObject[] objects;
	public GameObject[] triggerObjects;
	
	// Update is called once per frame
	void Update () 
	{
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
	}
}
