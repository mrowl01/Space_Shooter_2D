using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

	Text myText;
	public static int mylives ;
	// Use this for initialization
	void Start () 
	{
		myText= GetComponent <Text> ();
		resetMyLives (); 
	}
	public void myLives  (int theseLives)
	{
		mylives = theseLives;
		myText.text =mylives.ToString (); 
	}
	public void resetMyLives ()
	{
		mylives = 3; 
		myText.text = mylives.ToString (); 
	}

}
