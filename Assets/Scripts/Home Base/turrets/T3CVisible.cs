using UnityEngine;
using System.Collections;

public class T3CVisible : MonoBehaviour {

	public GameObject menu;
	// Use this for initialization
	void Start () {
		renderer.enabled = !renderer.enabled;
	}
	
	// Update is called once per frame
	void Update () {
		//Commented out by Reese, this script no longer exists, replaced with UI script
		//if (menu.GetComponent<HomeBaseMenu> ().turret3 == true) {
		//	renderer.enabled = true;
		//}
	}
}