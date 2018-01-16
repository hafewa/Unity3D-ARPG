using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	PlayerController playerController;
	public Slider healthBar;

	void Start () 
	{
		playerController = GetComponent<PlayerController>();
	}

	//Set health ui
	public void UpdateHealthBar()
	{
		healthBar.value = playerController.health / playerController.maxHealth;
	}

}
