using UnityEngine;
using System.Collections;

public class T3SVisible : MonoBehaviour {

	public GameObject menu;
	// Use this for initialization
	void Start () {
		renderer.enabled = !renderer.enabled;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (menu.GetComponent<HomeBaseMenu> ().turret3 == true) {
			renderer.enabled = true;
		}
	}
}