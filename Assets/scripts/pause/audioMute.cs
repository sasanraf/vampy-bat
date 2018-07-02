using UnityEngine;
using System.Collections;

public class audioMute : MonoBehaviour {

	bool audioIsMute = false;

	// the button has been replaced with refresh button
	Animator anim;
	GameObject cameraAudioListener;
	pauseGame pauseGameScript;

	void Start () 
	{
		anim = this.GetComponent<Animator>();
		pauseGameScript = GameObject.Find ("pauseButton").GetComponent<pauseGame>();
	}

	void OnMouseDown  () 
	{
		Time.timeScale=1;

		audioIsMute = !audioIsMute;
		if (audioIsMute == false)
		{
			this.collider2D.enabled = true;
			AudioListener.volume = 1;
			pauseGameScript.pauseTheGame();
		}
		else if (audioIsMute == true)
		{
			this.collider2D.enabled = true;
			AudioListener.volume = 0;
			pauseGameScript.pauseTheGame();
		}
	}

	public void audioMuteButton(bool TorF)
	{
		Time.timeScale=1;
		anim.SetBool("refreshButton", TorF);
		this.collider2D.enabled = TorF;
	}

}





