using UnityEngine;
using System.Collections;

public class createExplosion : MonoBehaviour {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "enemy") {
			Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (gameObject);
		}
	}
}
