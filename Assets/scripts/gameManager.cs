using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour 
{
	public AudioSource ambiant;
	
	GameObject monster;
	GameObject monster1;
	GameObject batFood;
	GameObject batFood1;
	GameObject batFood2;

	GameObject envRock01_01;
	GameObject envRock01_02;
	GameObject envRock01_03;
	GameObject envRock01;
	Vector3 envRock01Position;

	GameObject envRock02_01;
	GameObject envRock02_02;
	GameObject envRock02_03;
	GameObject envRock02_04;
	GameObject envRock02_05;
	GameObject envRock02_06;
	GameObject envRock02;
	Vector3 envRock02Position;

	GameObject envRock03_01;
	GameObject envRock03_02;
	GameObject envRock03_03;
	GameObject envRock03;
	Vector3 envRock03Position;

	Vector3 monsterPosition;
	Vector3 barFoodPostion;

	timer timerScript;

	int lastRandomEnvRock01 = 1;
	int lastRandomEnvRock02 = 1;
	int lastRandomEnvRock03 = 1;

	// Use this for initialization
	void Start () 
	{
		this.audio.Play();

		monster = GameObject.Find ("monster");
		monster1 = GameObject.Find ("monster1");
		batFood = GameObject.Find ("batFood");
		batFood1 = GameObject.Find ("batFood1");
		batFood2 = GameObject.Find ("batFood2");

		envRock01_01 = GameObject.Find ("envRock01_01");
		envRock01_02 = GameObject.Find ("envRock01_02");
		envRock01_03 = GameObject.Find ("envRock01_03");
		envRock01Position = new Vector3(envRock01_01.transform.position.x,envRock01_01.transform.position.y,0);

		envRock02_01 = GameObject.Find ("envRock02_01");
		envRock02_02 = GameObject.Find ("envRock02_02");
		envRock02_03 = GameObject.Find ("envRock02_03");
		envRock02_04 = GameObject.Find ("envRock02_04");
		envRock02_05 = GameObject.Find ("envRock02_05");
		envRock02_06 = GameObject.Find ("envRock02_06");
		envRock02Position = new Vector3(envRock02_01.transform.position.x,envRock02_01.transform.position.y,0);

		envRock03_01 = GameObject.Find ("envRock03_01");
		envRock03_02 = GameObject.Find ("envRock03_02");
		envRock03_03 = GameObject.Find ("envRock03_03");
		envRock03Position = new Vector3(envRock03_01.transform.position.x,envRock03_01.transform.position.y,0);

		timerScript = GameObject.Find ("timerGUIText").GetComponent<timer>();

		monsterPosition = new Vector3(monster.transform.position.x,monster.transform.position.y,0);
		barFoodPostion = new Vector3(batFood.transform.position.x,batFood.transform.position.y+Random.Range(-2,2),0);



		InvokeRepeating("monsterInstantiation", 1, .5f);
		InvokeRepeating("batFoodInstantiation", 1, 1f);
		InvokeRepeating("envRock1Instantiation", 1, 5f);
		InvokeRepeating("envRock2Instantiation", 1, 3f);
		InvokeRepeating("envRock3Instantiation", 1, 1f);

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void monsterInstantiation()
	{
		if (timerScript.timerTime < 90)
		{
			int randumNoBar = Random.Range (0,10);
			if (randumNoBar >= 7 )
			{
				float RandomScale = Random.Range (.5f,1.5f);
				GameObject monsterClone = (GameObject)Instantiate (monster, monsterPosition, transform.rotation);
				monsterClone.transform.localScale =  new Vector3(RandomScale,RandomScale,1);
				monsterClone.renderer.enabled = true;
				monsterClone.gameObject.tag = "monster";
				monsterClone.collider2D.enabled = true;
				Destroy (monsterClone, 2.5f);
			}
		}
		else
		{
			int randumMonsterNo = Random.Range (0,20);
			if (randumMonsterNo > 5)
			{
				int randumNoBar = Random.Range (0,10);
				if (randumNoBar >= 7 )
				{
					float RandomScale = Random.Range (.5f,1.5f);
					GameObject monsterClone = (GameObject)Instantiate (monster, monsterPosition, transform.rotation);
					monsterClone.transform.localScale =  new Vector3(RandomScale,RandomScale,1);
					monsterClone.renderer.enabled = true;
					monsterClone.gameObject.tag = "monster";
					monsterClone.collider2D.enabled = true;
					Destroy (monsterClone, 3f);
				}
			}
			else
			{
				int randumNoBar = Random.Range (0,10);
				if (randumNoBar >= 7 )
				{
					float RandomScale = Random.Range (.5f,1.5f);
					GameObject monsterClone = (GameObject)Instantiate (monster1, monsterPosition, transform.rotation);
					monsterClone.transform.localScale =  new Vector3(RandomScale,-RandomScale,1);
					monsterClone.renderer.enabled = true;
					monsterClone.gameObject.tag = "monster";
					monsterClone.collider2D.enabled = true;
					Destroy (monsterClone, 3f);
				}
			}
		}
	}
	
	void batFoodInstantiation()
	{
		if (timerScript.timerTime >60)
		{
			int randumBatFood = Random.Range (0,40);
			if (randumBatFood > 20)
			{
				int randumNo = Random.Range (0,20);
				if (randumNo >= 10 )
				{
					GameObject batFoodClone = (GameObject)Instantiate (batFood, barFoodPostion, transform.rotation);
					batFoodClone.renderer.enabled = true;
					batFoodClone.gameObject.tag = "batFood";
					Destroy (batFoodClone, 2.3f);
				}
			}
			else if (randumBatFood < 10)
			{
				int randumNo = Random.Range (0,20);
				if (randumNo >= 10)
				{
					GameObject batFoodClone = (GameObject)Instantiate (batFood1, barFoodPostion, transform.rotation);
					batFoodClone.renderer.enabled = true;
					batFoodClone.gameObject.tag = "batFood";
					Destroy (batFoodClone, 2.3f);
				}
			}
			else
			{
				int randumNo = Random.Range (0,20);
				if (randumNo >= 10 )
				{
					GameObject batFoodClone = (GameObject)Instantiate (batFood2, barFoodPostion, transform.rotation);
					batFoodClone.renderer.enabled = true;
					batFoodClone.gameObject.tag = "batFood";
					Destroy (batFoodClone, 2.3f);
				}
			}
		}
		else
		{
			int randumNo = Random.Range (0,20);
			if (randumNo >= 10 )
			{
				GameObject batFoodClone = (GameObject)Instantiate (batFood, barFoodPostion, transform.rotation);
				batFoodClone.renderer.enabled = true;
				batFoodClone.gameObject.tag = "batFood";
				Destroy (batFoodClone, 2.3f);
			}
		}
	}

	void envRock1Instantiation()
	{
		int randomEnvRock01 = Random.Range (1,4);
		while(randomEnvRock01 == lastRandomEnvRock01)
		{
			randomEnvRock01 = Random.Range (1,4);
		}
		lastRandomEnvRock01 = randomEnvRock01;

		if (randomEnvRock01 == 1)
		{
			envRock01 = envRock01_01;
		}
		if (randomEnvRock01 == 2)
		{
			envRock01 = envRock01_02;
		}
		if (randomEnvRock01 == 3)
		{
			envRock01 = envRock01_03;
		}
		GameObject envRock01Clone = (GameObject)Instantiate (envRock01, envRock01Position, transform.rotation);
		envRock01Clone.renderer.enabled = true;
		envRock01Clone.gameObject.tag = "rock";
		Destroy (envRock01Clone, 35f);
	}

	void envRock2Instantiation()
	{
		int randomEnvRock02 = Random.Range (1,6);
		while(randomEnvRock02 == lastRandomEnvRock02)
		{
			randomEnvRock02 = Random.Range (1,6);
		}
		lastRandomEnvRock02 = randomEnvRock02;

		if (randomEnvRock02 == 1)
		{
			envRock02 = envRock02_01;
		}
		if (randomEnvRock02 == 2)
		{
			envRock02 = envRock02_02;
		}
		if (randomEnvRock02 == 3)
		{
			envRock02 = envRock02_03;
		}
		if (randomEnvRock02 == 4)
		{
			envRock02 = envRock02_04;
		}
		if (randomEnvRock02 == 5)
		{
			envRock02 = envRock02_05;
		}
		if (randomEnvRock02 == 5)
		{
			envRock02 = envRock02_06;
		}
		GameObject envRock02Clone = (GameObject)Instantiate (envRock02, envRock02Position, transform.rotation);
		envRock02Clone.renderer.enabled = true;
		envRock02Clone.gameObject.tag = "rock";
		Destroy (envRock02Clone, 15f);
	}

	void envRock3Instantiation()
	{
		int randomEnvRock03 = Random.Range (1,4);
		while(randomEnvRock03 == lastRandomEnvRock03)
		{
			randomEnvRock03 = Random.Range (1,4);
		}
		lastRandomEnvRock03 = randomEnvRock03;

		if (randomEnvRock03 == 1)
		{
			envRock03 = envRock03_01;
		}
		if (randomEnvRock03 == 2)
		{
			envRock03 = envRock03_02;
		}
		if (randomEnvRock03 == 3)
		{
			envRock03 = envRock03_03;
		}
		GameObject envRock03Clone = (GameObject)Instantiate (envRock03, envRock03Position, transform.rotation);
		envRock03Clone.renderer.enabled = true;
		envRock03Clone.gameObject.tag = "rock";
		Destroy (envRock03Clone, 5f);
	}
}
