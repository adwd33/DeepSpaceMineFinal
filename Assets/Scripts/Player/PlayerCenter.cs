﻿using UnityEngine;
using System.Collections;

public class PlayerCenter : MonoBehaviour {

	//for switch between two control
	public GameObject cameraRod;
	public GameObject MainCamera;
	public float PlayerHealth;
	public float defaultPlayerHealth;

	//resources record
	public int[] resources = new int[11];


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<PlayerControler>().enabled = false;
		gameObject.GetComponent<PlayerControllerTest>().enabled = true;

		cameraRod = GameObject.Find ("Player2/cameraRod");
		MainCamera = GameObject.Find("Player2/MainCamera");

		cameraRod.SetActive (false);
		MainCamera.SetActive (true);

		//Initialize the resource record
		resources = new int[11] {0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0};

		//Initialize the player health
		PlayerHealth = 10f;
		
		//A value representing the static unchanging amount of health, needed to ui purposes
		defaultPlayerHealth = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Switch")) {
			gameObject.GetComponent<PlayerControler>().enabled = !gameObject.GetComponent<PlayerControler>().enabled;
			gameObject.GetComponent<PlayerControllerTest>().enabled = !gameObject.GetComponent<PlayerControllerTest>().enabled;
			cameraRod.SetActive (!cameraRod.activeSelf);
			MainCamera.SetActive (!MainCamera.activeSelf);
		}
	}

	public void resourceCollector(int type, int amount)
	{
		//Debug.Log ("Be Called");
		Debug.Log (type + " " + amount);
		resources [type] += amount;
	}
	
	public int[] getResourceList()
	{
		return resources;
	}

	public void ApplyDamage(float DamageAmount)
	{
		PlayerHealth -= DamageAmount;
		//Vector3 position = transform.position;
		
		if(PlayerHealth < 0f)
		{
			Application.LoadLevel("Main"); //call function in GameController.cs
		}
	}

	public float GetPlayerHealth()
	{
		return PlayerHealth;
	}
	
	public float GetDefaultPlayerHealth()
	{
		return defaultPlayerHealth;
	}
}
