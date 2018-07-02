using UnityEngine;
using System.Collections;

public class bgMonsterAudio : MonoBehaviour {

	public AudioSource monsterGroan;
	public AudioSource monsterGroanFar;
	public AudioSource monsterGroanNear;
	public AudioSource psycho;

	// Use this for initialization
	void Start () 
	{
		AudioSource[] audios = GetComponents<AudioSource>();
		monsterGroan = audios[0];
		monsterGroanFar = audios[1];
		monsterGroanNear = audios[2];	
		psycho = audios[3];
	}
	
	// Update is called once per frame
	void Update () 
	{
		int randomMonsterAudio = Random.Range (1,1000);
		switch (randomMonsterAudio)
		{
			case 10:
			if (!this.monsterGroan.isPlaying)
			{
				this.monsterGroan.Play();
			}
			break;

			case 20:
			if (!this.monsterGroanFar.isPlaying)
			{
				this.monsterGroanFar.Play();
			}
			break;

			case 30:
			if (!this.monsterGroanNear.isPlaying)
			{
				this.monsterGroanNear.Play();
			}
			break;

			case 40:
			if (Random.Range(1,10) > 7)
			{
				if (!this.psycho.isPlaying)
				{
					this.psycho.Play();
				}
			}
			break;
		}

	}
}
