using UnityEngine;
using System.Collections;

public class turret1shotdirection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public Transform transform;

	// Update is called once per frame
	void Update () {
	
		transform.LookAt (transform);
	}
}
