using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

	public string mainMenu;

	private LevelManager theLevelManager;
	public GameObject thePauseScreen;

	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {

		theLevelManager = FindObjectOfType<LevelManager> ();
        StartCoroutine("FindPlayer");
	}

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.25f);
        thePlayer = FindObjectOfType<PlayerController> ();
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Cancel")) 
		{
			if (Time.timeScale == 0) 
			{
				ResumeGame ();
			} 
			else 
			{
				PauseGame ();
			}
	
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		thePauseScreen.SetActive (true);
		thePlayer.canMove = false;
		theLevelManager.levelMusic.Pause ();
	}


	public void ResumeGame ()
	{
		Time.timeScale = 1;
		thePauseScreen.SetActive (false);
		thePlayer.canMove = true;
		theLevelManager.levelMusic.Play ();
	}

	public void QuitToMainMenu ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (mainMenu);
	}
}
