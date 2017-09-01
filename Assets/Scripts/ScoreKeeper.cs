using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int Points=0;
	Text theText ; 

	// Use this for initialization
	void Start () 
	{
		theText = GetComponent<Text> ();
		reSetScore ();

	}
	
	// Update is called once per frame
	void Update () 
	{

		
	}

	public void theScore (int points)
	{
		Points += points;
		theText.text = Points.ToString ();
	
	}
	public void reSetScore ()
	{
		Points = 0; 
		theText.text = Points.ToString ();
	}
}
