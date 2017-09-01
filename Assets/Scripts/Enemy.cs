using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	Ammo theAmmo;
	float health= 200; 
	public GameObject EnemyAmmo;
	public float shotsPerSecond= 0.5f;
	GameObject scorekeeper;
	ScoreKeeper myScore;
	static int PointValue = 75; 
	public AudioClip fireSounds;
	public AudioClip DeathSound;
	// Use this for initialization
	void Start () 
	{
		
		scorekeeper = GameObject.FindGameObjectWithTag ("ScoreText"); 
		myScore = scorekeeper.GetComponent<ScoreKeeper> ();
		
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		Ammo missile = coll.gameObject.GetComponent<Ammo> ();

		if (missile)
		{
			
			health -= missile.GetDamage ();
			if (health <= 0) 
			{
				AudioSource.PlayClipAtPoint (DeathSound, transform.position);
				myScore.theScore (PointValue);
				Destroy (gameObject);

			}

		}

	}

	void EnemyFiring ()
	{
		

		Vector3 ammoPos = new Vector3 (0, -1, 0);
		GameObject theAmmo = Instantiate (EnemyAmmo, transform.position+ ammoPos, Quaternion.identity) ;
		theAmmo.transform.Rotate (0, 0, 90);
		AudioSource.PlayClipAtPoint (fireSounds, transform.position);

		Rigidbody2D EnemyAmmoBody = theAmmo.gameObject.GetComponent<Rigidbody2D> ();
		EnemyAmmoBody.velocity = new Vector2 (0, -2f);
	}

	void FiringRestricted ()
	{
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability)
		{
			EnemyFiring ();
		}
	}
	void Update()
	{
		FiringRestricted ();
	}
}
