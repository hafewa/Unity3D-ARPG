using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionButton : MonoBehaviour
{
    public GameObject[] objects;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.GetComponent<PlayerController>().Damage(damage);
            foreach (var item in objects)
            {
                item.GetComponent<ITriggerable>().Trigger();
            }
        }
    }
}
