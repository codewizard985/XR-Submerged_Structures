/// <summary>
/// Sub controller script
/// /2017 Dylan Papp dylanpapp.daportfolio.com
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subController : MonoBehaviour  
{  
	 
	private Transform selfTransform;  

	float throttle;
	float yaw;
	float pitch;
	float roll;
	public float throttleMax = 5f;
	public float yawMax = 1f;
	public float pitchMax= 1f;
	public float rollMax = 1f;
	public float throttleRate = 1f;
	public float turnRate = 1f;
	public float decreaseRate = 1f;
	public GameObject propeller;
	public ParticleSystem bubbleFX;

	private Transform propellerTransform; 

	void Start ()  
	{  
		
		selfTransform = transform;
		propellerTransform = propeller.transform;
	} 


	void Update ()  
	{  
		var bblFX = bubbleFX.main;

		propellerTransform.rotation *= Quaternion.AngleAxis((throttle * 160f)*Time.deltaTime, Vector3.forward);

		//Throttle------------------------------------------------
		if (Input.GetAxis ("Throttle") >= 1) {
			throttle += Input.GetAxis ("Throttle") * throttleRate * Time.deltaTime;
			throttle = Mathf.Clamp (throttle, 0, throttleMax);
		}
		else if (Input.GetAxis ("Throttle") <= -1) {
			throttle += Input.GetAxis ("Throttle") * throttleRate * Time.deltaTime;
			throttle = Mathf.Clamp (throttle, -throttleMax, 0);
		}
		else
		{
			if (throttle < 0 ) {
				throttle += decreaseRate;
				throttle = Mathf.Clamp (throttle, -throttleMax, 0);
			}
			else if (throttle > 0) {
				throttle -= decreaseRate;
				throttle = Mathf.Clamp (throttle, 0, throttleMax);
			}

		}

		//Yaw---------------------------------------
		if (Input.GetAxis ("Yaw") >= 1) {
			yaw += Input.GetAxis ("Yaw")  * turnRate * Time.deltaTime;
			yaw = Mathf.Clamp (yaw, 0, yawMax);
		}
		else if (Input.GetAxis ("Yaw") <= -1) {
			yaw += Input.GetAxis ("Yaw")  * turnRate * Time.deltaTime;
			yaw = Mathf.Clamp (yaw, -yawMax, 0);
		}
		else
		{
			if (yaw < 0 ) {
				yaw += decreaseRate;
				yaw = Mathf.Clamp (yaw, -yawMax, 0);
			}
			else if (yaw > 0) {
				yaw -= decreaseRate;
				yaw = Mathf.Clamp (yaw, 0, yawMax);
			}
	
		}

		//Pitch-----------------------------------------
		if (Input.GetAxis ("Pitch") >= 1) {
			pitch += Input.GetAxis ("Pitch") * turnRate * Time.deltaTime;
			pitch = Mathf.Clamp (pitch, 0, pitchMax);
		}
		else if (Input.GetAxis ("Pitch") <= -1) {
			pitch += Input.GetAxis ("Pitch") * turnRate* Time.deltaTime;
			pitch = Mathf.Clamp (pitch, -pitchMax, 0);
		}
		else
		{
			if (pitch < 0 ) {
				pitch += decreaseRate;
				pitch = Mathf.Clamp (pitch, -pitchMax, 0);
			}
			else if (pitch > 0) {
				pitch -= decreaseRate;
				pitch = Mathf.Clamp (pitch, 0, pitchMax);
			}
		}

		//Roll-----------------------------------------
		if (Input.GetAxis ("Roll") >= 1) {
			roll += Input.GetAxis ("Roll") * turnRate * Time.deltaTime;
			roll = Mathf.Clamp (roll, 0, rollMax);
		}
		else if (Input.GetAxis ("Roll") <= -1) {
			roll += Input.GetAxis ("Roll") * turnRate* Time.deltaTime;
			roll = Mathf.Clamp (roll, -rollMax, 0);
		}
		else
		{
			if (roll < 0 ) {
				roll += decreaseRate;
				roll = Mathf.Clamp (roll, -rollMax, 0);
			}
			else if (roll > 0) {
				roll -= decreaseRate;
				roll = Mathf.Clamp (roll, 0, rollMax);
			}
		}
			
		bblFX.startSize  = 0.05f * throttle; 
		bblFX.startSpeed  = -4f * throttle; 

		selfTransform.Translate(throttle * Vector3.forward);
		selfTransform.Rotate(yaw * Vector3.up);
		selfTransform.Rotate(pitch * Vector3.right);
		selfTransform.Rotate(roll * Vector3.forward);

		  
	}  
}
