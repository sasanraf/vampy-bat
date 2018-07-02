using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	public float timerTime = 0f;
	GameObject timerPositionDummy;
	// Use this for initialization

	bat batScript;

	void Start () 
	{
		guiText.text = (timerTime.ToString("f0"));
		timerPositionDummy = GameObject.Find ("timerPositionDummy");

		batScript = GameObject.Find ("batDummy").GetComponent<bat>(); 

		int screenWidthX =  Screen.width;
		int screenHeightY =  Screen.height;
		Vector3 timerScoreGUIPos = Camera.main.WorldToScreenPoint (timerPositionDummy.transform.position);
		float timerScoreGUIPos_x = (timerScoreGUIPos.x/screenWidthX);
		float timerScoreGUIPos_y = (timerScoreGUIPos.y/screenHeightY);

		this.transform.position = new Vector3(timerScoreGUIPos_x,timerScoreGUIPos_y-0.01f,0);

		guiText.fontSize = (int) (Screen.width * 0.04f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(batScript.gameFailbool == false)
		{
			timerTime = timerTime + Time.deltaTime;
			guiText.text = (timerTime.ToString("f0"));
		}
	}
}
