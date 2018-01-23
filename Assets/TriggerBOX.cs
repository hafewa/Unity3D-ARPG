using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBOX : MonoBehaviour,ITriggerable {

	public Animator animator;
	// Use this for initialization

	public bool _isOpen;

	public bool Trigger()
	{
		if(_isOpen)
		{
			animator.SetTrigger("Close");
		}
		else
		{
			animator.SetTrigger("Open");
		}
		return true;
	}
}
