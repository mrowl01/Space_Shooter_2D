using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour 
{
	public float speed =20f ;
	float maxX;
	float minX;
	public float buffer = 1f; 
	public float health = 300f;
	public static int myLives = 3 ; 
	GameObject aLife; 
	Animator myAnimator;
	Lives theLives1 ;

	// Use this for initialization
	void Start () 
	{
		aLife = GameObject.FindGameObjectWithTag ("LivesText");
		theLives1 = aLife.GetComponent<Lives> ();

		float Dist = transform.position.z - Camera.main.transform.position.z;
		Vector3 rightmost= Camera.main.ViewportToWorldPoint(new Vector3 (1,0,Dist)) ;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,Dist)) ;
		maxX = rightmost.x - buffer;
		minX = leftmost.x + buffer;
		myLives = 3; 
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerMovement ();
	}
	void PlayerMovement ()
	{
		if (Input.GetKey (KeyCode.D)) 
		{
			//right
			transform.position+= new Vector3 (speed*Time.deltaTime,0,0);
		}
		else if (Input.GetKey (KeyCode.A))
		{
			//left
			transform.position -= new Vector3 (speed*Time.deltaTime,0,0);
		}
		float newX = Mathf.Clamp (transform.position.x, minX, maxX);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D (Collider2D coll)
	{

		Ammo missile = coll.gameObject.GetComponent<Ammo> ();

		if (missile)
		{
			health -= missile.GetDamage ();
			if (health <= 0) 
			{
				myLives--; 
				theLives1.myLives (myLives);
				myAnimator.Play ("Playing");
				if (myLives >=0) 
				{  myAnimator.Play ("Death");
					health = 300f;

				}

				else
				{
					Destroy (gameObject);
					SceneBoss.LoadNextLevel ();
				}

			}

		}

	}


}
