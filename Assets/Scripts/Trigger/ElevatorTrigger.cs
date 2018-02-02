using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public Door elevator;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.GetComponent<PlayerController>().Damage(damage);
            elevator.isMovingDown = true;
        }
    }

}
