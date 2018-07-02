using UnityEngine;
using System.Collections;

public class wait : MonoBehaviour {
	
	int minuteAtFail;

	public float waitTime = 1.0f;

	// Use this for initialization
	void Start () 
	{
		minuteAtFail = PlayerPrefs.GetInt("minuteAtFail");
		guiText.fontSize = (int) (Screen.width * 0.05f);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		int currentTimeMinute = System.DateTime.Now.Minute;
	
		if ((currentTimeMinute - minuteAtFail) >= waitTime)
		{
			PlayerPrefs.SetInt("Wait",0);
			PlayerPrefs.SetInt("batFails", 0);
			Application.LoadLevel("VampyBat");
		}
		float timeLeft = waitTime - (currentTimeMinute - minuteAtFail);
		guiText.text = ("Please wait "+ timeLeft.ToString("f0")+" minute(s)");
	}
}
