using UnityEngine;
using System.Collections;

public class playButtonMainMenu : MonoBehaviour {

	void OnMouseDown()
	{
		//audio.Play ();
		Application.LoadLevel("VampyBat");
	}
}
