using UnityEngine;
using System.Collections;

public class PlayerCounter : MonoBehaviour {
	public static int packageCounter;
	// Use this for initialization
	void Start () {
		Debug.Log ("Counter Detected!");
		packageCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		Debug.Log ("Collision Detected!");
		if (other.transform.tag == "package") {
			packageCounter++;
			Destroy(other.gameObject);
		}
	}
}
