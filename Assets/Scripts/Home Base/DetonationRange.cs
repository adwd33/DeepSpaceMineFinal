using UnityEngine;
using System.Collections;


public class DetonationRange : MonoBehaviour {

	public Transform explosionPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		Instantiate (explosionPrefab, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
