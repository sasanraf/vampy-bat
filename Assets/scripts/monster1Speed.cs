using UnityEngine;
using System.Collections;

public class monster1Speed : MonoBehaviour 
{
	Animator anim;
	timer timerScript;
	float speed = 1;

	// Use this for initialization
	void Start () {
		
		anim = this.GetComponent<Animator>();
		timerScript = GameObject.Find ("timerGUIText").GetComponent<timer>();
	}
	
	// Update is called once per frame
	void Update () 
	{		
		speed = 1 + timerScript.timerTime/360;
		anim.speed = speed;
	}
}
