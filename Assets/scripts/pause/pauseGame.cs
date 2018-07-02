using UnityEngine;
using System.Collections;

public class pauseGame : MonoBehaviour 
{
	exitGame exitGameScript;
	mainMenu mainMenuScript;
	audioMute audioMuteScript;
	pauseBarHorizontal pauseBarScript;
	public bool pauseEnable = false;

	void Start () 
	{
		mainMenuScript = GameObject.Find ("homeButton").GetComponent<mainMenu>();
		audioMuteScript = GameObject.Find ("audioMuteButton").GetComponent<audioMute>();
		exitGameScript = GameObject.Find ("exitButton").GetComponent<exitGame>();
		pauseBarScript = GameObject.Find ("bar").GetComponent<pauseBarHorizontal>();
	}

	void OnMouseDown  () 
	{
		pauseTheGame();
	}
		
	public void pauseTheGame () 
	{
		pauseEnable = !pauseEnable;

		if (pauseEnable == true)
		{
			mainMenuScript.homeButton(true);
			audioMuteScript.audioMuteButton(true);
			exitGameScript.exitButton(true);
			pauseBarScript.pauseBar(true);

			StartCoroutine("delay");
		}
		else if (pauseEnable == false)
		{
			Time.timeScale=1;
			mainMenuScript.homeButton(false);
			audioMuteScript.audioMuteButton(false);
			exitGameScript.exitButton(false);
			pauseBarScript.pauseBar(false);
		}
	}

	IEnumerator delay() 
	{
		yield return new WaitForSeconds(.5f);
		Time.timeScale=0;
	}

 

}