using UnityEngine;
using System.Collections;


public class DetonationRange : MonoBehaviour {

	public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "HomeBaseShield" || other.tag == "HomeBase")
			return;
		Destroy (other.gameObject);
		GameObject explosion = (GameObject)Instantiate (explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
