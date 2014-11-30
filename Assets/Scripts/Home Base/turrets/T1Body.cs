using UnityEngine;
using System.Collections;

public class T1Body : MonoBehaviour {

	public GameObject menu;
	// Use this for initialization
	void Start () {
		renderer.enabled = !renderer.enabled;
	}
	
	// Update is called once per frame
	void Update () {
		//Commented out by Reese, this script no longer exists, replaced with UI script
		//if (menu.GetComponent<HomeBaseMenu> ().turret1 == true) {
		//	renderer.enabled = true;
		//}
	}
}