using UnityEngine;
using System.Collections;

public class HomeBaseMenu : MonoBehaviour {
	
	private bool menu = false;
	public bool turret1 = false;
	public bool turret2 = false;
	public bool turret3 = false;
	public bool turret4 = false;
	public bool turret5 = false;
	public bool turret6 = false;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//check if pause button (escape key) is pressed
		if(Input.GetKeyDown("escape")){
			
			//check if game is already paused		
			if(menu == true){
				//unpause the game
				menu = false;
			}
			
			//else if game isn't paused, then pause it
			else if(menu == false){
				menu = true;
			}
		}
	}
	
	private bool slot1 = false;
	private bool slot2 = false;
	private bool slot3 = false;
	private bool slot4 = false;
	private bool slot5 = false;
	private bool slot6 = false;
	
	// Called whenever the user clicks on the sphere
	void OnMouseDown(){
		
	}
	
	void OnGUI(){
		
		if (menu == true) {
			//make the background box
			GUI.Box (new UnityEngine.Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 200), "Upgrade Menu");
			
			//make the slot 1 button
			if (GUI.Button (new UnityEngine.Rect (Screen.width / 2 - 100, Screen.height / 2 - 33, 250, 33), "Slot 1")) {
				turret1 = true;
			}
			
			//make the tier 2 button
			if (GUI.Button (new UnityEngine.Rect (Screen.width / 2 - 100, Screen.height / 2, 250, 33), "Slot 2")) {
				turret2 = true;
			}
			
			//make the tier 3 button
			if (GUI.Button (new UnityEngine.Rect (Screen.width / 2 - 100, Screen.height / 2 + 33, 250, 33), "Slot 3")) {
				turret3 = true;
			}
			
			//make the tier 4 button
			if (GUI.Button (new UnityEngine.Rect (Screen.width / 2 - 100, Screen.height / 2 + 66, 250, 33), "Slot 4")) {
				turret4 = true;
			}

			//make the tier 5 button
			if (GUI.Button (new UnityEngine.Rect (Screen.width / 2 - 100, Screen.height / 2 + 99, 250, 33), "Slot 5")) {
				turret5 = true;
			}

			//make the tier 6 button
			if (GUI.Button (new UnityEngine.Rect (Screen.width / 2 - 100, Screen.height / 2 + 132, 250, 33), "Slot 6")) {
				turret6 = true;
			}
		}
	}
}
