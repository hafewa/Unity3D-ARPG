using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
	public GameObject[] doors;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.GetComponent<PlayerController>().Damage(damage);
			foreach (var item in doors)
			{
				item.GetComponent<ITriggerable>().Trigger();
			}
        }
    }
}
