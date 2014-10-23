using UnityEngine;
using System.Collections;

// Reese 9/26/2014 Created this class to do all the "UIey" stuff
public class UI : MonoBehaviour
{
		/**This variable will control the Ui displaying so that it does not dissapear after the user releases the "escape" key*/
		bool isInGameUIEnabled = false;
		/**This variable will control when a menu box is being drawn*/
		bool isDrawingGUIBox = false;
		/**this variable will be true if the player in at the home base*/
		bool isLevelHomeBase = false;
		/**this is the title for the currrent box being drawn*/
		string boxTitle = "";
		/**This is the screen width*/
		int screenWidth = Screen.width;
		/**This is the screen height*/
		int screenHeight = Screen.height;
		/**This is the default button width*/
		static int defaultButtonWidth = 80;
		/**This is the default button width*/
		static int defaultButtonHeight = 20;
		/**This is the default side window width*/
		int defaultSideWindowWidth = Screen.width / 4;
		/**This is the default side window height*/
		int defaultSideWindowHeight = Screen.height;
		/**This is the default space for ui item buffer*/
		static int defaultUIItemBuffer = 10;
		/**This is the styling for the game title on the main screen*/
		GUIStyle boxGUIStyle;
		/**This is the player gameobject*/
		GameObject player;
		/**This is the playertest gameobject*/
		GameObject playerTest;
		/**This is a helpful buffer size*/
		static int bufferSize = 30;
		
		// This will draw the in game menu
		void drawInGameUI ()
		{
				drawResourcesReadout ();

				// Make the first button. If it is pressed, this will display the players inventory
				//if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 4) + 40, defaultButtonWidth, defaultButtonHeight), "Inventory")) {
				//		isDrawingGUIBox = !isDrawingGUIBox;
				//		boxTitle = "Inventory";		
				//}
				
				// Make the second button. If it is pressed, this will display available upgrades for the player
				if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 4) + 70, defaultButtonWidth, defaultButtonHeight), "Upgrades")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Upgrades";
				}
				// Make the thrid button. If it is pressed, this will display levels to warp to
				if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 4) + 100, defaultButtonWidth, defaultButtonHeight), "Warp")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Warp";
				}
				// Make the fourth button.If it is pressed, this will save the players game
				if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 4) + 130, defaultButtonWidth, defaultButtonHeight), "Save")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Save";
				}
				// Make the fifth button. If it is pressed, this will display available save files to load for the player
				if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 4) + 160, defaultButtonWidth, defaultButtonHeight), "Load")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Load";
				}
				// Make the six button.If it is pressed, this will exit the game
				if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 4) + 190, defaultButtonWidth, defaultButtonHeight), "Exit")) {
						Application.LoadLevel ("startMenuUI");
				}


				if (isDrawingGUIBox) {
						drawAGUIBox (new Rect ((screenWidth / 2) + (40 * 2), defaultUIItemBuffer, (defaultButtonWidth * 6), screenHeight), boxTitle);
						if (boxTitle.Equals ("Warp")) {
								drawWarpMenu ();
						} else if (boxTitle.Equals ("Upgrades")) {
								drawUpgradeMenu ();
						}
				}
		}

		void drawResourcesReadout ()
		{
				// Make a background box for the container "Resources", this displays stats, resources, thats about it
				//This will display the read out of current resources collected by the player
				drawAGUIBox (new Rect (defaultUIItemBuffer + (40 * 1), defaultUIItemBuffer, (defaultButtonWidth * 6), screenHeight), "Resources");
				//Iron, copper, Aluminum, Hydrogen tier 1
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 1), defaultUIItemBuffer + (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Tier 1", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 1), defaultUIItemBuffer + (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "Iron", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 1), defaultUIItemBuffer + (bufferSize * 4), defaultButtonWidth, defaultButtonHeight), "Copper", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 1), defaultUIItemBuffer + (bufferSize * 5), defaultButtonWidth, defaultButtonHeight), "Aluminum", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 1), defaultUIItemBuffer + (bufferSize * 6), defaultButtonWidth, defaultButtonHeight), "Hydrogen", boxGUIStyle);
				//Platinum, gold, lead tier 2
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 4), defaultUIItemBuffer + (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Tier 2", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 4), defaultUIItemBuffer + (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "Platinum", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 4), defaultUIItemBuffer + (bufferSize * 4), defaultButtonWidth, defaultButtonHeight), "Gold", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 4), defaultUIItemBuffer + (bufferSize * 5), defaultButtonWidth, defaultButtonHeight), "Lead", boxGUIStyle);
				//Uranium, carbon(diamond), tier 3
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 7), defaultUIItemBuffer + (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Tier 3", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 7), defaultUIItemBuffer + (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "Uranium", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 7), defaultUIItemBuffer + (bufferSize * 4), defaultButtonWidth, defaultButtonHeight), "Carbon", boxGUIStyle);
				//Unobtanium tier 4
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 10), defaultUIItemBuffer + (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Tier 4", boxGUIStyle);
				GUI.Label (new Rect (defaultUIItemBuffer + (40 * 10), defaultUIItemBuffer + (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "Unobtanium", boxGUIStyle);
		}
	
		//this is going to be called when you click a button and it will draw the 
		void drawAGUIBox (Rect rect, string boxTitle)
		{
				GUI.Box (rect, boxTitle);
		}
		// This updates the UI, similar to Update
		void OnGUI ()
		{
				if (isInGameUIEnabled) {
						drawInGameUI ();
						//this disables the player object
						if (player != null) {
								//player.SetActive (false);
						}
						if (playerTest != null) {
							//playerTest.SetActive (false);
						}
							
							
				} else {
						//this enables the player object
						if (player != null) {
								//player.SetActive (true);
						}
						if (playerTest != null) {
							//playerTest.SetActive (true);
						}					
				}
		}
		
		/**
		 *This method will draw the labels and buttons for the upgrade box.
		 */
		void drawUpgradeMenu ()
		{
				GUI.Label (new Rect ((screenWidth / 2) + (40 * 3), defaultUIItemBuffer + (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Offense", boxGUIStyle);
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 3), defaultUIItemBuffer + (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "OffenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 3), defaultUIItemBuffer + (bufferSize * 4), defaultButtonWidth, defaultButtonHeight), "OffenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 3), defaultUIItemBuffer + (bufferSize * 5), defaultButtonWidth, defaultButtonHeight), "OffenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 3), defaultUIItemBuffer + (bufferSize * 6), defaultButtonWidth, defaultButtonHeight), "OffenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 3), defaultUIItemBuffer + (bufferSize * 7), defaultButtonWidth, defaultButtonHeight), "OffenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				GUI.Label (new Rect ((screenWidth / 2) + (40 * 6), defaultUIItemBuffer + (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Defense", boxGUIStyle);
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 6), defaultUIItemBuffer + (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 6), defaultUIItemBuffer + (bufferSize * 4), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 6), defaultUIItemBuffer + (bufferSize * 5), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 6), defaultUIItemBuffer + (bufferSize * 6), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 6), defaultUIItemBuffer + (bufferSize * 7), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				GUI.Label (new Rect ((screenWidth / 2) + (40 * 9), defaultUIItemBuffer + (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Utility", boxGUIStyle);
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 9), defaultUIItemBuffer + (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 9), defaultUIItemBuffer + (bufferSize * 4), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 9), defaultUIItemBuffer + (bufferSize * 5), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 9), defaultUIItemBuffer + (bufferSize * 6), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				if(GUI.Button(new Rect ((screenWidth / 2) + (40 * 9), defaultUIItemBuffer + (bufferSize * 7), defaultButtonWidth, defaultButtonHeight), "DefenseUpgrade1")){
					//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
		}
		
		
		/**
		 *This method draws the warp buttons
		 */
		void drawWarpMenu ()
		{
				// This will warp the player into the "default" tier one scene
				if (GUI.Button (new Rect ((screenWidth / 2) + (40 * 4), defaultUIItemBuffer + 30, defaultButtonWidth, defaultButtonHeight), "Tier 1")) {
						Application.LoadLevel ("main");
				
				}
				// this will set the main scene "difficulty" to tier 2
				if (GUI.Button (new Rect ((screenWidth / 2) + (40 * 4), defaultUIItemBuffer + 60, defaultButtonWidth, defaultButtonHeight), "Tier 2")) {
						//TODO: need to set the difficulty to tier 2
						Application.LoadLevel ("main");
				
				}
				// this will set the main scene "difficulty" to tier 3
				if (GUI.Button (new Rect ((screenWidth / 2) + (40 * 4), defaultUIItemBuffer + 90, defaultButtonWidth, defaultButtonHeight), "Tier 3")) {
						//TODO: need to set the difficulty to tier 3
						Application.LoadLevel ("main");

				}
				// this will set the main scene "difficulty" to tier 4
				if (GUI.Button (new Rect ((screenWidth / 2) + (40 * 4), defaultUIItemBuffer + 120, defaultButtonWidth, defaultButtonHeight), "Tier 4")) {
						//TODO: need to set the difficulty to tier 4
						Application.LoadLevel ("main");

				}
				// This will warp the player to the home base scene
				if (GUI.Button (new Rect ((screenWidth / 2) + (40 * 4), defaultUIItemBuffer + 150, defaultButtonWidth, defaultButtonHeight), "Home Base")) {
						Application.LoadLevel ("HomeBase");

				}
		}

		// Use this for initialization
		void Start ()
		{
				player = GameObject.Find ("Player");
				playerTest = GameObject.Find("PlayerTest");
				//The style for the main title
				boxGUIStyle = new GUIStyle ();
				boxGUIStyle.fontSize = 14;
				boxGUIStyle.normal.textColor = Color.white;
				//boxGUIStyle.alignment = TextAnchor.UpperRight;
		}

		// Update is called once per frame
		void Update ()
		{
				//Reese 9/26/2014 This will trigger the menu for the player
				if (Input.GetKeyDown (KeyCode.Escape)) {
						isInGameUIEnabled = !isInGameUIEnabled;
				}
		}
}

