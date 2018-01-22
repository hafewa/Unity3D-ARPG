using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemover : MonoBehaviour {

	public ParticleSystem particleSystem;
	void Start()
	{
		particleSystem.loop = false;
	}

	void Update () 
	{
		if(particleSystem.isStopped)
		{
			//gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
}
