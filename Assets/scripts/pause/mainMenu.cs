﻿using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour 
{
	Animator anim;
	
	void Start ()
	{ 
		anim = this.GetComponent<Animator>();
	}	
	
	void OnMouseDown  () 
	{
		Time.timeScale=1;
		Application.LoadLevel("mainPage");
	}
	
	public void homeButton(bool TorF)
	{
		anim.SetBool("homeButton", TorF);
		this.collider2D.enabled = TorF;
	}
}
