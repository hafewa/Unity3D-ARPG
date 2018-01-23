using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
	public string tagToDamage;
	public float damageToDo;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == tagToDamage)
		{
			other.GetComponent<IDamageable>().Damage(damageToDo);
		}
	}
}
