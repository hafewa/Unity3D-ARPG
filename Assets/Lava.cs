using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

	public float damage;
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<IDamageable>().Damage(damage *Time.deltaTime );
		}
	}
}
