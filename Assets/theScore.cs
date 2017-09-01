using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class theScore : MonoBehaviour
{
	Text myText ; 
	// Use this for initialization
	void Start ()
	{
		myText = GetComponent<Text> ();
		myText.text = ScoreKeeper.Points.ToString(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
