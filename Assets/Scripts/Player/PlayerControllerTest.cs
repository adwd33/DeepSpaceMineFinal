﻿using UnityEngine;
using System.Collections;

public class PlayerControllerTest : MonoBehaviour
{
	//speed stuff
	public static float speed;
	public int cruiseSpeed;
	float deltaSpeed;//(speed - cruisespeed)
	public int minSpeed;
	public int maxSpeed;
	float accel, decel;
	
	//turning stuff
	Vector3 angVel;
	Vector3 shipRot;
	public int sensitivity;
	
	public Vector3 cameraOffset; //I use (0,1,-3)

	//camera stuff
	private GameObject mainCamera;
	private GameObject ship;
	private GameObject spaceDust;
	private GameObject PlayerWorld;

	//fire stuff
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

//	//test
	
	void Start()
	{
		speed = cruiseSpeed;
		mainCamera = GameObject.Find ("Player2/MainCamera");
		ship = GameObject.Find ("Player2/Ship");
		spaceDust = GameObject.Find ("Player2/SpaceDust");
		PlayerWorld = GameObject.Find ("Player2/PlayerWorld");
	}
	
	void FixedUpdate()
	{
		//ANGULAR DYNAMICS//
		
		shipRot = ship.transform.localEulerAngles; //make sure getting the ship.
		
		//since angles are only stored (0,360), convert to +- 180
		if (shipRot.x > 180) shipRot.x -= 360;
		if (shipRot.y > 180) shipRot.y -= 360;
		if (shipRot.z > 180) shipRot.z -= 360;
		
		//vertical stick adds to the pitch velocity
		angVel.x += Input.GetAxis("Vertical") * Mathf.Abs(Input.GetAxis("Vertical")) * sensitivity * Time.fixedDeltaTime;
		
		//horizontal stick adds to the roll and yaw velocity
		float turn = Input.GetAxis("Horizontal") * Mathf.Abs(Input.GetAxis("Horizontal")) * sensitivity * Time.fixedDeltaTime;
		angVel.y += turn * .5f;
		angVel.z -= turn * .5f;
		
		
		//shoulder buttons add to the roll and yaw.  No deltatime here for a quick response
		//comment out the .y parts if don't want to turn when hit them
		if (Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.I))
		{
			angVel.y -= 20;
			angVel.z += 50;
			speed -= 5 * Time.fixedDeltaTime;
		}
		
		if (Input.GetKey(KeyCode.Joystick1Button5) || Input.GetKey(KeyCode.O))
		{
			angVel.y += 20;
			angVel.z -= 50;
			speed -= 5 * Time.fixedDeltaTime;
		}
		
		
		//the angular velocity is higher when going slower, and vice versa.
		angVel /= 1 + deltaSpeed * .001f;
		
		//this is what limits your angular velocity.  Basically hard limits it at some value due to the square magnitude, can
		//tweak where that value is based on the coefficient
		angVel -= angVel.normalized * angVel.sqrMagnitude * .08f * Time.fixedDeltaTime;
		
		
		//and finally rotate.  
		ship.transform.Rotate(angVel * Time.fixedDeltaTime);
		
		//this limits your rotation, as well as gradually realigns you.  It's a little convoluted, but it's
		//got the same square magnitude functionality as the angular velocity, plus a constant since x^2
		//is very small when x is small.  Also realigns faster based on speed.  feel free to tweak
		ship.transform.Rotate(-shipRot.normalized * .015f * (shipRot.sqrMagnitude + 500) * (1 + speed / maxSpeed) * Time.fixedDeltaTime);
		
		
		//LINEAR DYNAMICS//
		
		deltaSpeed = speed - cruiseSpeed;
		
		//This, I think, is a nice way of limiting your speed.  Your acceleration goes to zero as you approach the min/max speeds, and you initially
		//brake and accelerate a lot faster.  Could potentially do the same thing with the angular stuff.
		decel = speed - minSpeed;
		accel = maxSpeed - speed;
		
		//simple accelerations
		if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.LeftShift))
			speed += accel * Time.fixedDeltaTime;
		else if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Space))
			speed -= decel * Time.fixedDeltaTime;
		
		//if not accelerating or decelerating, tend toward cruise, using a similar principle to the accelerations above
		//(added clamping since it's more of a gradual slowdown/speedup)
		else if (Mathf.Abs(deltaSpeed) > .1f)
			speed -= Mathf.Clamp(deltaSpeed * Mathf.Abs(deltaSpeed), -30, 100) * Time.fixedDeltaTime;
		
		
		//moves camera (make sure you're GetChild()ing the camera's index)
		//I don't mind directly connecting this to the speed of the ship, because that always changes smoothly
		mainCamera.transform.localPosition = cameraOffset + new Vector3(0, 0, -deltaSpeed * .02f);

		
		float sqrOffset = ship.transform.localPosition.sqrMagnitude;
		Vector3 offsetDir = ship.transform.localPosition.normalized;
		
		
		//this takes care of realigning after collisions, where the ship gets displaced due to its rigidbody.
		//I'm pretty sure this is the best way to do it (have the ship and the rig move toward their mutual center)
		ship.transform.Translate(-offsetDir * sqrOffset * 20 * Time.fixedDeltaTime);
		//(**************** this ***************) is what actually makes the whole ship move through the world!
		transform.Translate((offsetDir * sqrOffset * 50 + ship.transform.forward * speed) * Time.fixedDeltaTime, Space.World);
		
		//comment this out for starfox, remove the x and z components for shadows of the empire, and leave the whole thing for free roam
		transform.Rotate(shipRot.x * Time.fixedDeltaTime, (shipRot.y * Mathf.Abs(shipRot.y) * .02f) * Time.fixedDeltaTime, shipRot.z * Time.fixedDeltaTime);

		//fire thing
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, ship.rigidbody.rotation);
		}
	}

	void Update()
	{
	}
}