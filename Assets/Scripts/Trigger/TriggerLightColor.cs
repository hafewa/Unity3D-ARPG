using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightColor : MonoBehaviour, ITriggerable
{
    private Light _light;
    public Color one;
    public Color two;

    public bool oneTime;
    private bool _hasBeenTriggered;

    void Start()
    {
        _light = GetComponent<Light>();
		_light.color = one;
    }

    public bool Trigger()
    {
        if (oneTime)
        {
            if (!_hasBeenTriggered)
            {
                _light.color = two;
                return true;
            }

            return false;
        }
        else
        {
            if (_light.color == two)
            {
                _light.color = one;
            }
            else
            {
                _light.color = two;
            }
        }
        return true;
    }
}
