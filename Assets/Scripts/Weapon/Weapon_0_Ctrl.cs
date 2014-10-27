﻿using UnityEngine;
using System.Collections;

public class Weapon_0_Ctrl : MonoBehaviour {

	public float Damage = 0f;
	private GameObject shotSpawn;
	public float speed;
	public GameObject boom;
	public float lifetime;

//	void Awake()
//	{
//		Destroy (gameObject, lifetime);
//	}

	// Use this for initialization
	void Start () {
		shotSpawn = GameObject.Find("Player2/Ship/ShotSpawn");

		rigidbody.velocity = transform.forward * (speed + PlayerControllerTest.speed);
		Destroy (gameObject, lifetime);
//		RaycastHit hit;
//		Vector3 fwd = transform.TransformDirection(Vector3.forward);
//		if (Physics.Raycast(transform.position, fwd, out hit))
//		{
//			hit.transform.SendMessage("ApplyDamage",Damage,SendMessageOptions.DontRequireReceiver);
//		}
//		Debug.DrawRay (transform.position,fwd * 20, Color.green);

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag != "ShipBody" && other.gameObject.tag != "Player" && other.gameObject.tag != "package")
		{
			Debug.Log (other.name);
			other.rigidbody.AddForce(transform.forward * 200);
			other.transform.SendMessage("ApplyDamage",Damage,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
			Instantiate(boom,gameObject.transform.position-gameObject.transform.forward * 1,Quaternion.identity);
		}

	}
}
