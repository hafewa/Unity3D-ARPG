using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITriggerable
{
	bool Trigger();
}

interface IDamageable
{
	bool Damage(float damage);
}