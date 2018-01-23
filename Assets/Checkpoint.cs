using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			print(gameObject.name);
			GameManager.currentCheckpoint = gameObject.name;
		}
	}
}
