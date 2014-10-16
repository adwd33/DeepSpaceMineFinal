using UnityEngine;
using System.Collections;
// Reese 9/26/2014 Created this class to do all the "UIey" stuff
public class MainMenuUI : MonoBehaviour
{
		/**This variable will control the Ui displaying so that it does not dissapear after the user releases the "escape" key*/
		bool isInGameUIEnabled = false;
		/**This is the screen width*/
		int screenWidth = Screen.width;
		/**This is the screen height*/
		int screenHeight = Screen.height;
		/**This is the default button width*/
		int defaultButtonWidth = 80;
		/**This is the default button width*/
		int defaultButtonHeight = 20;
		/**This is the default side window width*/
		float defaultSideWindowWidth = Screen.width / 4;
		/**This is the default side window height*/
		float defaultSideWindowHeight = Screen.height;
		/**This is the default space for ui item buffer*/
		int defaultUIItemBuffer = 10;
		/**This is the styling for the game title on the main screen*/
		GUIStyle gameTitleStyle;
		Texture2D titleLogo;
	
		// This will draw the in game menu
		void drawInGameUI ()
		{
		//This draws the title logo for Deep Space Mine
		if (titleLogo) {
			GUI.DrawTexture (new Rect ((screenWidth / 2) - (titleLogo.width / 2), 0 + titleLogo.height , titleLogo.width, titleLogo.height), titleLogo, ScaleMode.ScaleToFit, true, 0.0f);
		}
		//GUI.Label (new Rect ((screenWidth / 2) - titleWidth, (screenHeight / 4), defaultButtonWidth, defaultButtonHeight), titleLogo, gameTitleStyle);
				// Make a background box for the container "Player Menu"
				//GUI.Box (new Rect (0, 0, screenWidth, screenHeight), "Deep Space Mine");
				// Make the first button. If it is pressed, this will display the players inventory
		if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 2) + 40, defaultButtonWidth, defaultButtonHeight), "New Game")) {
						//This loads the main scene, or in our case the core of the game.
						Application.LoadLevel ("main");
				}
				// Make the fourth button. If it is pressed, this will display available save files to load for the player
		if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 2) + 70, defaultButtonWidth, defaultButtonHeight), "Load")) {
						// Make a background box
						GUI.Box (new Rect ((defaultUIItemBuffer * 2), (defaultUIItemBuffer * 2), defaultSideWindowWidth, defaultSideWindowHeight), "Load");
				}
				// Make the sixth button.If it is pressed, this will exit the game
		if (GUI.Button (new Rect ((screenWidth / 2) - 40, (screenHeight / 2) + 100, defaultButtonWidth, defaultButtonHeight), "Exit")) {
						Application.Quit ();
				}
		}
	
		// This updates the UI, similar to Update
		void OnGUI ()
		{
				//GUI.backgroundColor = Color.black;
				//if (isInGameUIEnabled) {
				//	drawInGameUI ();
				//}
				drawInGameUI ();
			
		}
		// Use this for initialization
		void Start ()
		{
		titleLogo = Resources.Load ("UITextures/deepspaceminelogo1", typeof(Texture2D)) as Texture2D;

				//The style for the main title
				gameTitleStyle = new GUIStyle();
				//gameTitleStyle.fontSize = 48;
				//gameTitleStyle.normal.textColor = Color.white;
				gameTitleStyle.alignment = TextAnchor.MiddleCenter;
				//titleWidth = GUI.skin.label.CalcSize(titleLogo).x;
		//gameTitleStyle.CalcSize
		}
	
		// Update is called once per frame
		void Update ()
		{
			camera.backgroundColor = Color.black;
		}
}

