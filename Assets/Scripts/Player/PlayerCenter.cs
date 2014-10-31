using UnityEngine;
using System.Collections;

public class PlayerCenter : MonoBehaviour {

	//for switch between two control
	public GameObject cameraRod;
	public GameObject MainCamera;

	//resources record
	public int[] resources = new int[11];


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<PlayerControler>().enabled = false;
		gameObject.GetComponent<PlayerControllerTest>().enabled = true;

		cameraRod = GameObject.Find ("Player2/cameraRod");
		MainCamera = GameObject.Find("Player2/MainCamera");

		cameraRod.SetActive (false);
		MainCamera.SetActive (true);

		//Initialize the resource record
		resources = new int[11] {0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0};
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Switch")) {
			gameObject.GetComponent<PlayerControler>().enabled = !gameObject.GetComponent<PlayerControler>().enabled;
			gameObject.GetComponent<PlayerControllerTest>().enabled = !gameObject.GetComponent<PlayerControllerTest>().enabled;
			cameraRod.SetActive (!cameraRod.activeSelf);
			MainCamera.SetActive (!MainCamera.activeSelf);
		}
	}

	public void resourceCollector(int type, int amount)
	{
		//Debug.Log ("Be Called");
		Debug.Log (type + " " + amount);
		resources [type] += amount;
	}
	
	public int[] getResourceList()
	{
		return resources;
	}
}
