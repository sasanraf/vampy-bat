using UnityEngine;
using System.Collections;

public class batFailTapDetection : MonoBehaviour {

	string currentLevelName;
	GameObject pauseButtonLimit;
	
	void Start () 
	{
		currentLevelName = Application.loadedLevelName;	
		pauseButtonLimit = GameObject.Find ("pauseButtonLimit");
	}
	
	void OnMouseDown  () 
	{
		Vector3 tapCoordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		if (tapCoordinate.x > pauseButtonLimit.transform.position.x && tapCoordinate.y < pauseButtonLimit.transform.position.y)
		{
			StartCoroutine("soundFinishDelay");
		}
	}

	IEnumerator soundFinishDelay()
	{
		yield return new WaitForSeconds(0.2f);
		Application.LoadLevel(currentLevelName);
	}

}

