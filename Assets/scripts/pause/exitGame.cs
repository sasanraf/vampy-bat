﻿using UnityEngine;
using System.Collections;

public class exitGame : MonoBehaviour 
{
	Animator anim;
	
	void Start ()
	{ 
		anim = this.GetComponent<Animator>();

	}	
	
	void OnMouseDown  () 
	{
		Time.timeScale=1;
		Application.Quit();
	}
	
	public void exitButton(bool TorF)
	{
		anim.SetBool("exitButton", TorF);
		this.collider2D.enabled = TorF;
	}
}