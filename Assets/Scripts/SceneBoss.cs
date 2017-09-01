using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class SceneBoss : MonoBehaviour 
{


	public void ChangeScene (string theScene)
	{
		SceneManager.LoadScene(theScene); 


	}

	public void QuitGame ()
	{
		Application.Quit (); 
	}

	public static void LoadNextLevel()
	{
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); 


	}


}
