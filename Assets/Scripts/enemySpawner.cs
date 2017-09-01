using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour 
{
	public GameObject Enemy;
	public float width = 5f;
	public float height = 5f; 

	public float speed = 5;
	Vector3 mostRight; 
	Vector3 mostLeft; 
	float maxX ;
	float minX ;
	bool moveRight; 
	public float buffer = 0.5f;
	public float spawnDelay = 0.5f;


	// Use this for initialization
	void Start () 
	{
		Spawner();

		float Dis = transform.position.z - Camera.main.transform.position.z; 
		Vector3 mostRight= Camera.main.ViewportToWorldPoint(new Vector3 ( 1,0,Dis)); 
		Vector3 mostLeft=  Camera.main.ViewportToWorldPoint(new Vector3 ( 0,0,Dis)); 
		maxX = mostRight.x - 0.5f; 
		minX = mostLeft.x + 0.5f;

	}

	void Update ()
	{
		EnemyMovement ();
		if (AllMembersDead())
		{
			SpawnUntilFull ();
		}
	}

	bool AllMembersDead ()
	{
		
		foreach (Transform position in transform)// position are the child of transform(enemyformation)
			// the childs will have a value of 1 or 0 (depending on which one) when they are all 0 they are all dead
		{
			float theChilds = position.childCount;
			if (theChilds>0) 
			{
				return false;	
			}
		}
		return true; 

	}

	Transform NextFreePosition ()
	{
		foreach (Transform position in transform)
		{
			float theChilds = position.childCount;
			if (theChilds == 0)
			{
				return position;
			}
		}
		return null;
	}

	void OnDrawGizmos ()
	{
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y + 2.5f, transform.position.z);
		Gizmos.DrawWireCube (pos, new Vector3 (width, height, 0)); 
	}

	void Spawner () 
	{
		SpawnUntilFull ();
	}

	public void EnemyMovement ()
	{
		float myMaxRightX = transform.position.x + (width * 0.5f)+buffer;
		float myMaxLeftX = transform.position.x -(width * 0.5f)-buffer;
		if (myMaxLeftX <= minX) { moveRight = true;}
		else if (myMaxRightX >= maxX) { moveRight = false;}


		if (moveRight)
			transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		else if (!moveRight)
			transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);

		float newX = Mathf.Clamp (transform.position.x,minX,maxX);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z); 
	}

	void SpawnUntilFull ()
	{
		Transform freeposition = NextFreePosition ();

		if (freeposition != null) 
		{
			GameObject enemy = Instantiate (Enemy, freeposition.position, Quaternion.identity);
			enemy.transform.parent = freeposition;

		}
		if (freeposition != null) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}

	}
			
	
	
}
