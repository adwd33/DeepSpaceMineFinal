	using UnityEngine;
	using System.Collections;
	using AssemblyCSharp;
	
// Reese 9/26/2014 Created this class to do all the "UIey" stuff
public class UI : MonoBehaviour
{
		PlayerSaveObject playerSave;
		/**This list holds a list of upgrade obnjects*/
		public ArrayList listOfBaseUpgradeObjects;
		public int listSize;
		/**This enables*/
		PlayerCenter playerController;
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
		static int defaultButtonWidth = 160;
		/**This is the default button width*/
		static int defaultButtonHeight = 40;
		/**This is the default side window width*/
		int defaultSideWindowWidth = Screen.width / 4;
		/**This is the default side window height*/
		int defaultSideWindowHeight = Screen.height;
		/**This is the styling for the game title on the main screen*/
		GUIStyle boxGUIStyle;
		/**This is the player gameobject*/
		GameObject player;
		/**This is the playertest gameobject*/
		GameObject playerTest;
		/**This is a helpful buffer size*/
		static int bufferSize = 30;
		/**These are the textures for the resource menu*/
		Texture2D asteroidIcon;
		Texture2D ironIcon;
		Texture2D copperIcon;
		Texture2D alumIcon;
		Texture2D diamondIcon;
		Texture2D uranIcon;
		Texture2D hydrogenIcon;
		Texture2D platIcon;
		Texture2D leadIcon;
		Texture2D goldIcon;
		Texture2D unobtainIcon;
		/**This is the texture for the player health bar*/
		Texture2D playerHealthbar;
		float tierOneColumnXPos;
		float tierTwoColumnXPos;
		float tierThreeColumnXPos;
		float tierFourColumnXPos;	
		float tierOneRightColumnXPos;
		float tierTwoRightColumnXPos;
		float tierThreeRightColumnXPos;
		float tierFourRightColumnXPos;
		float buttonCenterPosX;
		float rightBoxPosX;
		/**This contains the array of resources that the player collects.*/
		int[] resources;
		/**This is the players health.*/
		public float health;
		/**default health of player*/
		public float defaultHealth;
		/**this is the player health bar width*/
		public float playerHealthbarWidth = 128f;
		static float defaultPlayerHealthbarWidth = 128f;
		/**this is the player health bar height*/
		static int playerHealthbarHeight = 32;
		public float healthScaleRemovalValue;
		bool isHealthScaleRemovalValueSet;
		public bool isPlayerHealthDifferent;
		
		public float previousHealth = 0;
		static int costScale = 1;
		
			
		// Use this for initialization
		void Start ()
		{
				
				listOfBaseUpgradeObjects = new ArrayList();
				//Load the icons for the resource layout
				ironIcon = Resources.Load ("UITextures/ironIcon", typeof(Texture2D)) as Texture2D;
				copperIcon = Resources.Load ("UITextures/copperIcon", typeof(Texture2D)) as Texture2D;
				alumIcon = Resources.Load ("UITextures/alumIcon", typeof(Texture2D)) as Texture2D;
				diamondIcon = Resources.Load ("UITextures/diamondIcon", typeof(Texture2D)) as Texture2D;
				uranIcon = Resources.Load ("UITextures/uranIcon", typeof(Texture2D)) as Texture2D;
				hydrogenIcon = Resources.Load ("UITextures/hydrogenIcon", typeof(Texture2D)) as Texture2D;
				platIcon = Resources.Load ("UITextures/platIcon", typeof(Texture2D)) as Texture2D;
				leadIcon = Resources.Load ("UITextures/leadIcon", typeof(Texture2D)) as Texture2D;
				goldIcon = Resources.Load ("UITextures/goldIcon", typeof(Texture2D)) as Texture2D;
				unobtainIcon = Resources.Load ("UITextures/unobtainIcon", typeof(Texture2D)) as Texture2D;
				asteroidIcon = Resources.Load ("UITextures/asteroidIcon", typeof(Texture2D)) as Texture2D;
				
				//Load the player health bar texture
				playerHealthbar = Resources.Load ("UITextures/playerHealthBar", typeof(Texture2D)) as Texture2D;
				
				player = GameObject.Find ("Player");
				playerTest = GameObject.Find ("PlayerTest");
				//The style for the main title
				boxGUIStyle = new GUIStyle ();
				boxGUIStyle.fontSize = 14;
				boxGUIStyle.normal.textColor = Color.white;
		
				tierOneColumnXPos = (40 * 1);
				tierTwoColumnXPos = (40 * 4);
				tierThreeColumnXPos = (40 * 7);
				tierFourColumnXPos = (40 * 10);
		
		
				tierOneRightColumnXPos = screenWidth - (defaultButtonWidth * 1);
				tierTwoRightColumnXPos = screenWidth - (defaultButtonWidth * 2);
				tierThreeRightColumnXPos = screenWidth - (defaultButtonWidth * 3);
				tierFourRightColumnXPos = screenWidth - (defaultButtonWidth * 4);
		
		
				buttonCenterPosX = (screenWidth / 2) - (defaultButtonWidth / 2);
				rightBoxPosX = screenWidth - (defaultButtonWidth * 3);
				isHealthScaleRemovalValueSet = false;
				//Add the upgrades
				//Tier 1
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(1, "Auto Turret",(costScale * 8),0,0,0,0,(costScale * 2),0,0,0,0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(1, "Shell",(costScale * 8),0,0,0,0,(costScale * 2),0,0,0,0));
				//Tier 2
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(2, "Auto Turret",(costScale * 4),0,0,0,0,(costScale * 2),(costScale * 2),(costScale * 2),0,0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(2, "Shell",0,0,0,0,0,(costScale * 4),0,(costScale * 3),(costScale * 2),0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(2, "Shield",0,(costScale * 5),(costScale * 1),0,0,0,0,0,(costScale * 4),0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(2, "Missile Battery",(costScale * 2),0,(costScale * 3),0,0,(costScale * 3),0,(costScale * 1),(costScale * 1),0));
				//Tier 3
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(3, "Auto Turret",(costScale * 1),0,0,(costScale * 3),0,(costScale * 2),(costScale * 3),(costScale * 1),0,0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(3, "Shell",0,0,0,(costScale * 6),0,0,0,(costScale * 2),(costScale * 2),0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(3, "Shield",0,(costScale * 1),(costScale * 1),(costScale * 4),(costScale * 1),0,0,(costScale * 2),(costScale * 1),0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(3, "Missile Battery",(costScale * 1),(costScale * 1),0,(costScale * 2),(costScale * 1),(costScale * 2),(costScale * 2),(costScale * 1),0,0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(3, "Nuclear Weapons",0,0,0,(costScale * 4),(costScale * 3),(costScale * 1),0,(costScale * 1),0,0));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(3, "Mine Field",0,(costScale * 1),(costScale * 2),(costScale * 3),(costScale * 1),0,(costScale * 2),(costScale * 1),0,0));
				//Tier 4
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(4, "Auto Turret",0,0,0,(costScale * 2),0,(costScale * 1),(costScale * 2),(costScale * 1),0,(costScale * 4)));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(4, "Shell",0,0,0,(costScale * 1),0,0,0,(costScale * 1),(costScale * 1),(costScale * 7)));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(4, "Shield",0,0,0,(costScale * 3),(costScale * 1),0,0,(costScale * 2),0,(costScale * 4)));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(4, "Missile Battery",0,0,0,(costScale * 2),(costScale * 1),(costScale * 2),0,(costScale * 1),0,(costScale * 3)));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(4, "Nuclear Weapons",0,0,0,(costScale * 3),(costScale * 3),(costScale * 1),0,(costScale * 1),0,(costScale * 2)));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(4, "Mine Field",0,0,0,(costScale * 3),(costScale * 1),0,0,(costScale * 1),0,(costScale * 5)));
				listOfBaseUpgradeObjects.Add(new BaseUpgradeObject(4, "Orbiting Platform",0,(costScale * 2),(costScale * 1),0,0,0,0,(costScale * 1),0,(costScale * 5)));
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Application.loadedLevelName.Equals ("HomeBase")) {
						isLevelHomeBase = true;
				} else {
						isLevelHomeBase = false;
				}
				playerController = (PlayerCenter)FindObjectOfType (typeof(PlayerCenter));
				if (playerController != null) {
						
						if (previousHealth != health && previousHealth != 0) {
								isPlayerHealthDifferent = true;
								previousHealth = health;
						} else {
								isPlayerHealthDifferent = false;
								previousHealth = health;
						}
						
						resources = playerController.getResourceList ();
						health = playerController.GetPlayerHealth ();
						
						defaultHealth = playerController.GetDefaultPlayerHealth ();
						if (!isHealthScaleRemovalValueSet) {
								healthScaleRemovalValue = playerHealthbarWidth / defaultHealth;
								isHealthScaleRemovalValueSet = true;
						}
						
				}
		
				//Reese 9/26/2014 This will trigger the menu for the player
				if (Input.GetKeyDown (KeyCode.Escape)) {
						isInGameUIEnabled = !isInGameUIEnabled;
				}
		}
			
		// This will draw the in game menu
		void drawInGameUI ()
		{	
				//draw the resource readout
				drawResourcesReadout ();
					
				// Make the second button. If it is pressed, this will display available upgrades for the player
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight), "Upgrades")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Upgrades";
				}
				
				// Make the second button. If it is pressed, this will display available upgrades for the player
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 2), defaultButtonWidth, defaultButtonHeight), "Home Base Upgrades")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Home Base Upgrades";
				}
				
				// Make the thrid button. If it is pressed, this will display levels to warp to
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 3), defaultButtonWidth, defaultButtonHeight), "Warp")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Warp";
				}
				// Make the fourth button.If it is pressed, this will save the players game
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 4), defaultButtonWidth, defaultButtonHeight), "Save")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Save";
	
						playerSave = new PlayerSaveObject(Time.time.ToString (), (int)health, playerController.GetPurchasedShipUpgradeList (), resources, playerController.GetPurchasedHomeBaseUpgradeList ());
						bool isSucessful = playerSave.writeSaveObjectToFile(playerSave);
						if(isSucessful){
							//TODO: tell the user the game was saved
						}
		}
				// Make the fifth button. If it is pressed, this will display available save files to load for the player
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 5), defaultButtonWidth, defaultButtonHeight), "Load")) {
						isDrawingGUIBox = !isDrawingGUIBox;
						boxTitle = "Load";
				}
				// Make the six button.If it is pressed, this will exit the game
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 6), defaultButtonWidth, defaultButtonHeight), "Exit")) {
						Application.LoadLevel ("startMenuUI");
				}
	
	
				if (isDrawingGUIBox) {
						if (boxTitle.Equals ("Warp")) {
								drawWarpMenu(new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 3), defaultButtonWidth, defaultButtonHeight));
						} else if (boxTitle.Equals ("Upgrades")) {
								drawUpgradeMenu (new Rect (buttonCenterPosX, (screenHeight / 4) + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight));
						} else if (boxTitle.Equals ("Home Base Upgrades")) {
								drawHomeBaseUpgradeMenu (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 2), defaultButtonWidth, defaultButtonHeight));
						}else if(boxTitle.Equals ("Load")){
								drawLoadMenu(new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 5), defaultButtonWidth, defaultButtonHeight));
						}
				}
		}
		
		// This updates the UI, similar to Update
		void OnGUI ()
		{
		
					drawPlayerHealthReadout ();
		
				
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
		
	//This will draw the load menu of current save files
	void drawLoadMenu(Rect originPosition){
		//originPosition.
		//TODO: load in the current saves
		originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
		// This will warp the player to the home base scene
		//how many saves determine how many buttons there are
		if (GUI.Button (originPosition, "Save 1")) {
			//Application.LoadLevel ("HomeBase");
			
		}
	}
		
		//This will draw the warp menus
		void drawWarpMenu(Rect originPosition){
			originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
			// This will warp the player to the home base scene
			if (GUI.Button (originPosition, "Home Base")) {
				Application.LoadLevel ("HomeBase");
				
			}
		}
		/**
		 * This method drawHomeBaseUpgradeMenu will draw the upgrade menu if the scene is "HomeBase"
		 * 
		 * */
	void drawHomeBaseUpgradeMenu (Rect originPosition)
		{
		Rect previousOriginPosition = new Rect (originPosition.x, originPosition.y, originPosition.width, originPosition.height);
		
		originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
		
		//GUI.Label (new Rect (tierOneRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Offense", boxGUIStyle);
		if (GUI.Button (originPosition, "Blaster Power")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
		if (GUI.Button (originPosition, "More Blasters")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
		if (GUI.Button (originPosition, "Homing Missiles")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		
		originPosition = new Rect (previousOriginPosition.x + (defaultButtonWidth * 2), previousOriginPosition.y, previousOriginPosition.width, previousOriginPosition.height);
		//GUI.Label (new Rect (tierTwoRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Defense", boxGUIStyle);
		if (GUI.Button (originPosition, "Hull Strength")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
		if (GUI.Button (originPosition, "Shields")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
		if (GUI.Button (originPosition, "Regen")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		
		originPosition = new Rect (previousOriginPosition.x + (defaultButtonWidth * 2), previousOriginPosition.y, previousOriginPosition.width, previousOriginPosition.height);	
		originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
		//GUI.Label (new Rect (tierThreeRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Utility", boxGUIStyle);
		if (GUI.Button (originPosition, "Speed Turning")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
		if (GUI.Button (originPosition, "Radar")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
		if (GUI.Button (originPosition, "Resource Magnet")) {
			//TODO: allow the player to buy this upgrade if they have correct amount of resources
		}
		}
		/**
		 * This method drawPlayerHealthReadout will draw a life bar on the screen for the user to see.
		 * 
		 * */
		void drawPlayerHealthReadout ()
		{
				if (isPlayerHealthDifferent) {
					playerHealthbarWidth = playerHealthbarWidth - healthScaleRemovalValue;
					Rect healthBarRect = new Rect (screenWidth - playerHealthbarWidth, screenHeight - playerHealthbarHeight, playerHealthbarWidth, playerHealthbarHeight);
					Rect healthBarLabelRect = new Rect (screenWidth - defaultPlayerHealthbarWidth, screenHeight - playerHealthbarHeight, defaultPlayerHealthbarWidth, playerHealthbarHeight);
					
					
					GUI.DrawTexture (healthBarRect, playerHealthbar, ScaleMode.StretchToFill, true, 0.0f);
					healthBarRect.Set (healthBarRect.x, healthBarRect.y, healthBarRect.width, healthBarRect.height);
					GUI.Label (healthBarLabelRect, "Health", boxGUIStyle);
					isPlayerHealthDifferent = false;
				} else {
					Rect healthBarRect = new Rect (screenWidth - playerHealthbarWidth, screenHeight - playerHealthbarHeight, playerHealthbarWidth, playerHealthbarHeight);
					Rect healthBarLabelRect = new Rect (screenWidth - defaultPlayerHealthbarWidth, screenHeight - playerHealthbarHeight, defaultPlayerHealthbarWidth, playerHealthbarHeight);
					GUI.DrawTexture (healthBarRect, playerHealthbar, ScaleMode.StretchToFill, true, 0.0f);
					healthBarRect.Set (healthBarRect.x, healthBarRect.y, healthBarRect.width, healthBarRect.height);
					GUI.Label (healthBarLabelRect, "Health", boxGUIStyle);
				}
		}
		/**
		 * This method drawResourcesReadout draws the ui screen for the read out of resources the player has gathered.
		 * 
		 * */
		void drawResourcesReadout ()
		{
				// Make a background box for the container "Resources", this displays stats, resources, thats about it
				//This will display the read out of current resources collected by the player
				drawAGUIBox (new Rect (tierOneColumnXPos, 10, (defaultButtonWidth * 3), screenHeight), "Resources");
				//asteroid, Iron, copper, Aluminum, Hydrogen tier 1
				GUI.Label (new Rect (tierOneColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Tier 1", boxGUIStyle);
					
				GUI.Label (new Rect (tierOneColumnXPos, (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "Asteroid", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierOneColumnXPos, (bufferSize * 3) + (asteroidIcon.height / 2), (asteroidIcon.width / 2), (asteroidIcon.height / 2)), asteroidIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierOneColumnXPos + (asteroidIcon.width / 2), (bufferSize * 3) + (asteroidIcon.height / 2), (asteroidIcon.width / 2), (asteroidIcon.height / 2)), resources [0].ToString ());
			
				GUI.Label (new Rect (tierOneColumnXPos, (bufferSize * 4) + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight), "Iron", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierOneColumnXPos, (bufferSize * 4) + (ironIcon.height / 2) + (asteroidIcon.height / 2), (ironIcon.width / 2), (ironIcon.height / 2)), ironIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierOneColumnXPos + (ironIcon.width / 2), (bufferSize * 4) + (ironIcon.height / 2) + (asteroidIcon.height / 2), (ironIcon.width / 2), (ironIcon.height / 2)), resources [1].ToString ());
			
				GUI.Label (new Rect (tierOneColumnXPos, (bufferSize * 5) + (ironIcon.height / 2) + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight), "Copper", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierOneColumnXPos, (bufferSize * 5) + (ironIcon.height / 2) + (copperIcon.height / 2) + (asteroidIcon.height / 2), (copperIcon.width / 2), (copperIcon.height / 2)), copperIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierOneColumnXPos + (copperIcon.width / 2), (bufferSize * 5) + (ironIcon.height / 2) + (copperIcon.height / 2) + (asteroidIcon.height / 2), (copperIcon.width / 2), (copperIcon.height / 2)), resources [2].ToString ());
			
				GUI.Label (new Rect (tierOneColumnXPos, (bufferSize * 6) + (ironIcon.height / 2) + (copperIcon.height / 2) + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight), "Aluminum", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierOneColumnXPos, (bufferSize * 6) + (ironIcon.height / 2) + (copperIcon.height / 2) + (asteroidIcon.height / 2) + (alumIcon.height / 2), (alumIcon.width / 2), (alumIcon.height / 2)), alumIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierOneColumnXPos + (alumIcon.width / 2), (bufferSize * 6) + (ironIcon.height / 2) + (copperIcon.height / 2) + (asteroidIcon.height / 2) + (alumIcon.height / 2), (alumIcon.width / 2), (alumIcon.height / 2)), resources [3].ToString ());
				
				GUI.Label (new Rect (tierOneColumnXPos, (bufferSize * 7) + (ironIcon.height / 2) + (copperIcon.height / 2) + (asteroidIcon.height / 2) + (alumIcon.height / 2), defaultButtonWidth, defaultButtonHeight), "Hydrogen", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierOneColumnXPos, (bufferSize * 7) + (ironIcon.height / 2) + (copperIcon.height / 2) + (asteroidIcon.height / 2) + (alumIcon.height / 2) + (hydrogenIcon.height / 3), (hydrogenIcon.width / 2), (hydrogenIcon.height / 2)), hydrogenIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierOneColumnXPos + (hydrogenIcon.width / 2), (bufferSize * 7) + (ironIcon.height / 2) + (copperIcon.height / 2) + (asteroidIcon.height / 2) + (alumIcon.height / 2) + (hydrogenIcon.height / 3), (hydrogenIcon.width / 2), (hydrogenIcon.height / 2)), resources [4].ToString ());
	
				//Platinum, gold, lead tier 2
				GUI.Label (new Rect (tierTwoColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Tier 2", boxGUIStyle);
				GUI.Label (new Rect (tierTwoColumnXPos, (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "Platinum", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierTwoColumnXPos, (bufferSize * 3) + (platIcon.height / 2), (platIcon.width / 2), (platIcon.height / 2)), platIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierTwoColumnXPos + (platIcon.width / 2), (bufferSize * 3) + (platIcon.height / 2), (platIcon.width / 2), (platIcon.height / 2)), resources [5].ToString ());
			
				GUI.Label (new Rect (tierTwoColumnXPos, (bufferSize * 4) + (platIcon.height / 2), defaultButtonWidth, defaultButtonHeight), "Gold", boxGUIStyle);		
				GUI.DrawTexture (new Rect (tierTwoColumnXPos, (bufferSize * 4) + (goldIcon.height / 2) + (platIcon.height / 2), (goldIcon.width / 2), (goldIcon.height / 2)), goldIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierTwoColumnXPos + (goldIcon.width / 2), (bufferSize * 4) + (goldIcon.height / 2) + (platIcon.height / 2), (goldIcon.width / 2), (goldIcon.height / 2)), resources [6].ToString ());
				
				GUI.Label (new Rect (tierTwoColumnXPos, (bufferSize * 5) + (goldIcon.height / 2) + (platIcon.height / 2), defaultButtonWidth, defaultButtonHeight), "Lead", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierTwoColumnXPos, (bufferSize * 5) + (leadIcon.height / 2) + (goldIcon.height / 2) + (platIcon.height / 2), (leadIcon.width / 2), (leadIcon.height / 2)), leadIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierTwoColumnXPos + (leadIcon.width / 2), (bufferSize * 5) + (leadIcon.height / 2) + (goldIcon.height / 2) + (platIcon.height / 2), (leadIcon.width / 2), (leadIcon.height / 2)), resources [7].ToString ());
			
				//Uranium, carbon(diamond), tier 3
				GUI.Label (new Rect (tierThreeColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Tier 3", boxGUIStyle);
					
				GUI.Label (new Rect (tierThreeColumnXPos, (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "Uranium", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierThreeColumnXPos, (bufferSize * 3) + (uranIcon.height / 2), (uranIcon.width / 2), (uranIcon.height / 2)), uranIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierThreeColumnXPos + (uranIcon.width / 2), (bufferSize * 3) + (uranIcon.height / 2), (uranIcon.width / 2), (uranIcon.height / 2)), resources [8].ToString ());
		
				GUI.Label (new Rect (tierThreeColumnXPos, (bufferSize * 4) + (uranIcon.height / 2), defaultButtonWidth, defaultButtonHeight), "Carbon", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierThreeColumnXPos, (bufferSize * 4) + (diamondIcon.height / 2) + (uranIcon.height / 2), (diamondIcon.width / 2), (diamondIcon.height / 2)), diamondIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierThreeColumnXPos + (diamondIcon.width / 2), (bufferSize * 4) + (diamondIcon.height / 2) + (uranIcon.height / 2), (diamondIcon.width / 2), (diamondIcon.height / 2)), resources [9].ToString ());
				
				//Unobtanium tier 4
				GUI.Label (new Rect (tierFourColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Tier 4", boxGUIStyle);
				GUI.Label (new Rect (tierFourColumnXPos, (bufferSize * 3), defaultButtonWidth, defaultButtonHeight), "Unobtanium", boxGUIStyle);
				GUI.DrawTexture (new Rect (tierFourColumnXPos, (bufferSize * 3) + (unobtainIcon.height / 3), (unobtainIcon.width / 2), (unobtainIcon.height / 2)), unobtainIcon, ScaleMode.ScaleToFit, true, 0.0f);
				GUI.Label (new Rect (tierFourColumnXPos + (unobtainIcon.width / 2), (bufferSize * 3) + (unobtainIcon.height / 3), (unobtainIcon.width / 2), (unobtainIcon.height / 2)), resources [10].ToString ());
		}	
		
		//this is going to be called when you click a button and it will draw the 
		void drawAGUIBox (Rect rect, string boxTitle)
		{
				GUI.Box (rect, boxTitle);
		}
		
			
		/**
		 * This method will draw the labels and buttons for the upgrade box.
		 * 
		 * */
		void drawUpgradeMenu (Rect originPosition)
		{
				Rect previousOriginPosition = new Rect (originPosition.x, originPosition.y, originPosition.width, originPosition.height);
			
				originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
		
				//GUI.Label (new Rect (tierOneRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Offense", boxGUIStyle);
				if (GUI.Button (originPosition, "Blaster Power")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (GUI.Button (originPosition, "More Blasters")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (GUI.Button (originPosition, "Homing Missiles")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
					
				originPosition = new Rect (previousOriginPosition.x + (defaultButtonWidth * 2), previousOriginPosition.y, previousOriginPosition.width, previousOriginPosition.height);
				//GUI.Label (new Rect (tierTwoRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Defense", boxGUIStyle);
				if (GUI.Button (originPosition, "Hull Strength")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (GUI.Button (originPosition, "Shields")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (GUI.Button (originPosition, "Regen")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				
				originPosition = new Rect (previousOriginPosition.x + (defaultButtonWidth * 2), previousOriginPosition.y, previousOriginPosition.width, previousOriginPosition.height);	
				originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
				//GUI.Label (new Rect (tierThreeRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Utility", boxGUIStyle);
				if (GUI.Button (originPosition, "Speed Turning")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (GUI.Button (originPosition, "Radar")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (GUI.Button (originPosition, "Resource Magnet")) {
						//TODO: allow the player to buy this upgrade if they have correct amount of resources
				}
		}
	
}
	
