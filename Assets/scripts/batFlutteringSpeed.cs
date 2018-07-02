using UnityEngine;
using System.Collections;

public class batFlutteringSpeed : MonoBehaviour 
{
	Animator anim;
	bat batScript;

	// Use this for initialization
	void Start () {
		
		anim = this.GetComponent<Animator>();
		batScript = GameObject.Find ("batDummy").GetComponent<bat>();
	}
	
	// Update is called once per frame
	void Update () 
	{		
		anim.speed = 2f - Mathf.Clamp(batScript.batEnergy/1000f,0f,1f);
		audio.pitch = Mathf.Clamp(anim.speed,1f,1.2f);
	}
}
