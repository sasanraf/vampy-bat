using UnityEngine;
using System.Collections;

public class pauseBarHorizontal : MonoBehaviour {

	Animator anim;
	
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	public void pauseBar(bool TorF)
	{
		anim.SetBool("barScale", TorF);
	}
}
