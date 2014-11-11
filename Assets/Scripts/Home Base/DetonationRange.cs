using UnityEngine;
using System.Collections;


public class DetonationRange : MonoBehaviour {

	public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//ExplosionRange (transform.position, 3);
	}

	void ExplosionRange(Vector3 center, float radius) {
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		int i = 0;
		while (i < hitColliders.Length) {
			if(hitColliders[i].tag == "enemy"){
				GameObject explosion = (GameObject) Instantiate(explosionPrefab, transform.position, transform.rotation);
				Destroy(gameObject);
			}
			i++;
		}
	}
}
