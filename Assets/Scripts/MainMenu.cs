using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string firstLevel;
	public string LevelSelect;

	public int startingLives;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame()
	{
		SceneManager.LoadScene (firstLevel);
		PlayerPrefs.SetInt ("CoinCount", 0);
		PlayerPrefs.SetInt ("PlayerLives", startingLives);
		PlayerPrefs.SetFloat ("PlayerX", 0);
		PlayerPrefs.SetFloat ("PlayerY", 0);
		PlayerPrefs.SetFloat ("PlayerZ", 0);
	}

	public void Continue()
	{
		SceneManager.LoadScene (firstLevel);
	}

	public void Quit()
	{
		Application.Quit ();
	}


}
