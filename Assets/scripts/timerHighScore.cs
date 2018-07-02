using UnityEngine;
using System.Collections;

public class timerHighScore : MonoBehaviour {

	float timerTimeHighScore = 0f;
	GameObject timerPositionHighScoreDummy;

	timer timerScript;

	// Use this for initialization
	void Start () 
	{

		timerTimeHighScore = PlayerPrefs.GetFloat("highestTimeScore");
		guiText.text = (timerTimeHighScore.ToString("f0"));

		timerPositionHighScoreDummy = GameObject.Find ("timerPositionHighScoreDummy");
		
		int screenWidthX =  Screen.width;
		int screenHeightY =  Screen.height;
		Vector3 timerScoreGUIPos = Camera.main.WorldToScreenPoint (timerPositionHighScoreDummy.transform.position);
		float timerScoreGUIPos_x = (timerScoreGUIPos.x/screenWidthX);
		float timerScoreGUIPos_y = (timerScoreGUIPos.y/screenHeightY);
		
		this.transform.position = new Vector3(timerScoreGUIPos_x,timerScoreGUIPos_y-0.01f,0);
		
		guiText.fontSize = (int) (Screen.width * 0.04f);


		timerScript = GameObject.Find ("timerGUIText").GetComponent<timer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timerTimeHighScore < timerScript.timerTime)
		{
			timerTimeHighScore = timerScript.timerTime;
			guiText.text = (timerTimeHighScore.ToString("f0"));
			PlayerPrefs.SetFloat ("highestTimeScore", timerTimeHighScore);
			guiText.color = Color.Lerp (Color.white, Color.black, Mathf.PingPong (Time.time*2, 1f));
		}
		else
		{
			guiText.color = Color.white;
		}
	}

}
