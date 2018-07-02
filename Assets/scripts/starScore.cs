using UnityEngine;
using System.Collections;

public class starScore : MonoBehaviour {

	GameObject starScorePositionDummy;
	timer timerScript;
	int starCounter = 0;

	// Use this for initialization
	void Start () {

		starScorePositionDummy = GameObject.Find ("starScorePositionDummy");
		timerScript = GameObject.Find ("timerGUIText").GetComponent<timer>();

		int highestStarRate = PlayerPrefs.GetInt("starCount");

		if (starCounter < highestStarRate)
		{
			starCounter = highestStarRate;
		}

		int screenWidthX =  Screen.width;
		int screenHeightY =  Screen.height;
		Vector3 starScoreGUIPos = Camera.main.WorldToScreenPoint (starScorePositionDummy.transform.position);
		float starScoreGUIPos_x = (starScoreGUIPos.x/screenWidthX);
		float starScoreGUIPos_y = (starScoreGUIPos.y/screenHeightY);
		
		this.transform.position = new Vector3(starScoreGUIPos_x,starScoreGUIPos_y-0.01f,0);
		
		guiText.fontSize = (int) (Screen.width * 0.04f);

	
	}
	
	// Update is called once per frame
	void Update () {
		if ((int)timerScript.timerTime%90 == 0)
		{
			int newStarCounter = (int)timerScript.timerTime/90;
			if (newStarCounter > starCounter)
			{
				starCounter = newStarCounter;
				PlayerPrefs.SetInt ("starCount", starCounter);
			}
		}
		string starText = (starCounter.ToString("f0")+" x");
		guiText.text = (starText);
	}
}
