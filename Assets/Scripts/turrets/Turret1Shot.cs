using UnityEngine;
using System.Collections;

public class Turret1Shot : MonoBehaviour {

	public GameObject shot;
	public Transform turret1Shot;
	public float fireRate;
	
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, turret1Shot.position, turret1Shot.rotation);
			audio.Play ();
		}
	}

}
