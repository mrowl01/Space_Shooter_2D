using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
	public float damage = 50f;

	void OnTriggerEnter2D (Collider2D imHit)
	{
		
		Destroy (this.gameObject);
	}

	public float GetDamage ()
	{
		return damage; 
	}

}
