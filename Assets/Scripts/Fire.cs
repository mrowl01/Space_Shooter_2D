using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
	public GameObject ammo; 
	Rigidbody2D ammoBody;
	public int speed = 5; 	
	public float projectileRepeatRate = 0.2f;
	public AudioClip fireSound;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		FireRestrictions ();

	}

	void Firing ()
	{
		GameObject theAmmo= Instantiate (ammo, transform.position, Quaternion.identity);
			theAmmo.transform.Rotate (0, 0, -90);
			AudioSource.PlayClipAtPoint (fireSound, transform.position);
			ammoBody = theAmmo.gameObject.GetComponent<Rigidbody2D> ();
			ammoBody.velocity = new Vector2 (0, speed); 
	}

	void FireRestrictions()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			
			InvokeRepeating ("Firing",0.000001f, projectileRepeatRate); 
		}
		if (Input.GetKeyUp (KeyCode.Space))
		{
			CancelInvoke ("Firing");
		}
		
	}
}
