using UnityEngine;
using System.Collections;
using System;

public class bat : MonoBehaviour {

	public AudioSource batFlap;
	public AudioSource batFood;
	public AudioSource monsterSwallow;

	GameObject batObject;
	GameObject monster;
	GameObject batFoodPopping;
	GameObject batFoodPosition;

	GameObject lightBatFood;

	GameObject batFailTapDetection;	

	GameObject lowerLimit;
	GameObject upperLimit;
	GameObject restart;


	GameObject energyCell01;
	GameObject energyCell02;
	GameObject energyCell03;

	float timer;
	public bool gameFailbool = false;

	int batFails = 0;
	GameObject batFailsObject; 
	
	public int batEnergy = 1300;
	int batEnergyIncreased = 80;

	DateTime currentDate;
	DateTime oldDate;

	timer timerScript;

	float waitTime = 1.0f;

	// Use this for initialization
	void Start () 
	{		
		AudioSource[] audios = GetComponents<AudioSource>();
		monsterSwallow = audios[0];
		batFlap = audios[1];
		batFood = audios[2];

		int currentTimeHour = System.DateTime.Now.Hour;
		int currentTimeMinute = System.DateTime.Now.Minute;
		int currentDateDay = System.DateTime.Now.Day;
		int hourAtFail = PlayerPrefs.GetInt("hourAtFail");
		int minuteAtFail = PlayerPrefs.GetInt("minuteAtFail");
		int dayAtFail = PlayerPrefs.GetInt("dayAtFail");

		if ((currentDateDay - dayAtFail) != 0)
		{
			PlayerPrefs.SetInt("Wait",0);
			PlayerPrefs.SetInt("batFails", 0);
		}
		else if((currentTimeHour - hourAtFail) != 0)
		{
			PlayerPrefs.SetInt("Wait",0);
			PlayerPrefs.SetInt("batFails", 0);
		}	
		else if ((currentTimeMinute - minuteAtFail ) >= waitTime)
		{
			PlayerPrefs.SetInt("Wait",0);
			PlayerPrefs.SetInt("batFails", 0);
		}

		if (PlayerPrefs.GetInt("Wait") == 1)
		{
			Application.LoadLevel("Wait");
		}

		timerScript = GameObject.Find ("timerGUIText").GetComponent<timer>();

		batFails = PlayerPrefs.GetInt("batFails");
		batFailsObject = GameObject.Find ("batfail1");

		if (batFails > 0 && batFails < 27)
		{
			batFailsObject.renderer.enabled = false;
			GameObject batFailsObjectNo = GameObject.Find ("batfail"+batFails);
			batFailsObjectNo.renderer.enabled = true;
		}
		//Debug.Log("batfail"+batFails);

		batObject = GameObject.Find ("bat");
		batFoodPopping = GameObject.Find ("batFoodPopping");
		batFoodPosition = GameObject.Find ("batFoodPosition");

		batFailTapDetection = GameObject.Find ("batFailTapDetection");

		lowerLimit = GameObject.Find ("lowerLimit");
		upperLimit = GameObject.Find ("upperLimit");
		restart = GameObject.Find ("restart");

		lightBatFood = GameObject.Find ("lightBatFood");

		energyCell01 = GameObject.Find ("energyCell01");
		energyCell02 = GameObject.Find ("energyCell02");
		energyCell03 = GameObject.Find ("energyCell03");

	}
	
	void Update () 
	{

		//back button android quit
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Application.Quit(); 
		}

		timer = timer + Time.deltaTime;

		if (timer >= 1 && this.rigidbody2D.mass != 1.5f)
		{
			this.rigidbody2D.mass = 1.5f;
			this.rigidbody2D.gravityScale = 1;
		}

		this.rigidbody2D.AddForce(new Vector2(0, -30));

		if(Input.GetMouseButtonDown(0))
		{
			this.batFlap.Play();
			this.rigidbody2D.velocity = new Vector2(0,0);
			this.rigidbody2D.AddForce(Vector2.up*batEnergy);

			if (batEnergy > 500)
			{
				batEnergy = batEnergy - 100;
			}	
		}

		//Debug.Log (batEnergy);
		int currentTimeHour = System.DateTime.Now.Hour;
		int currentTimeMinute = System.DateTime.Now.Minute;
		int currentDateDay = System.DateTime.Now.Day;
		PlayerPrefs.SetInt("hourAtFail",currentTimeHour);
		PlayerPrefs.SetInt("minuteAtFail",currentTimeMinute);
		PlayerPrefs.SetInt("dayAtFail",currentDateDay);
		///*
		if (gameFailbool == false && ((this.transform.position.y < lowerLimit.transform.position.y) || (this.transform.position.y > upperLimit.transform.position.y)))
		{
			this.monsterSwallow.Play();
			batFails = batFails + 1;
			if (batFails > 26)
			{
				batFails = 0;
				PlayerPrefs.SetInt("Wait",1);
			}
			PlayerPrefs.SetInt("batFails", batFails);
			gameFail();
		}
		//Energy UI
		if (batEnergy >= 900)
		{
			energyCell03.renderer.enabled = true;
			energyCell02.renderer.enabled = true;
			energyCell01.renderer.enabled = true;
		}
		else if (batEnergy >= 700) 
		{
			energyCell03.renderer.enabled = false;
			energyCell02.renderer.enabled = true;
			energyCell01.renderer.enabled = true;
		}
		else if (batEnergy >= 500)
		{
			energyCell03.renderer.enabled = false;
			energyCell02.renderer.enabled = false;
			energyCell01.renderer.enabled = true;
		}
		else 
		{
			energyCell03.renderer.enabled = false;
			energyCell02.renderer.enabled = false;
			energyCell01.renderer.enabled = false;
		}
		//*/
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.tag == "batFood")
		{	
			this.batFood.Play();
			lightBatFood.light.intensity = 3f;
			StartCoroutine("lightDelay");
			Vector3 batFoodPoppingPosition = new Vector3(batFoodPosition.transform.position.x,batFoodPosition.transform.position.y,0);
			GameObject batFoodPoppingClone = (GameObject)Instantiate (batFoodPopping, batFoodPoppingPosition, transform.rotation);
			other.renderer.enabled = false;
			Destroy (batFoodPoppingClone, .01f);

			if (batEnergy <=1200)
			{
				if (timerScript.timerTime > 30)
				{
					batEnergyIncreased = 60;
				}
				batEnergy = batEnergy + batEnergyIncreased;
			}
		}
		else if(other.tag == "monster")
		{
			this.monsterSwallow.Play();

			batFails = batFails + 1;
			if (batFails > 26)
			{
				batFails = 0;
				int currentTimeHour = System.DateTime.Now.Hour;
				int currentTimeminute = System.DateTime.Now.Minute;
				PlayerPrefs.SetInt("hourAtFail",currentTimeHour);
				PlayerPrefs.SetInt("minuteAtFail",currentTimeminute);
				PlayerPrefs.SetInt("Wait",1);
			}
			PlayerPrefs.SetInt("batFails", batFails);
			gameFail();
		}
	}

	void gameFail()
	{
		restart.renderer.enabled = true;
		gameFailbool = true;
		batEnergy = 0;
		this.rigidbody2D.isKinematic = true;
		this.collider2D.enabled = false;
		this.transform.position = new Vector3 (0,0,0);
		batObject.renderer.enabled = false;
		batFailTapDetection.collider2D.enabled = true;
		this.rigidbody2D.isKinematic = false;
	}

	IEnumerator lightDelay()
	{
		yield return new WaitForSeconds(0.2f);
		lightBatFood.light.intensity = 0f;
	}


}
