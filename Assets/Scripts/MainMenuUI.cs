using UnityEngine;
using System.Collections;
// Reese 9/26/2014 Created this class to do all the "UIey" stuff
public class MainMenuUI : MonoBehaviour
{
		/**This variable will control the Ui displaying so that it does not dissapear after the user releases the "escape" key*/
		bool isInGameUIEnabled;
		/**This is the screen width*/
		int screenWidth;
		/**This is the screen height*/
		int screenHeight;
		/**This is the default button width*/
		int defaultButtonWidth;
		/**This is the default button width*/
		int defaultButtonHeight;
		/**This is the default side window width*/
		float defaultSideWindowWidth;
		/**This is the default side window height*/
		float defaultSideWindowHeight;
		/**This is the default space for ui item buffer*/
		int defaultUIItemBuffer;
		/**This is the styling for the game title on the main screen*/
		GUIStyle gameTitleStyle;
		/**This is the texture for the game logo*/
		Texture2D titleLogo;
		int defaultPlayerHealth;
		// Use this for initialization
		void Start ()
		{
				defaultPlayerHealth = 10;
				isInGameUIEnabled = false;
				screenWidth = Screen.width;
				screenHeight = Screen.height;
				defaultButtonWidth = 160;
				defaultButtonHeight = 40;
				defaultSideWindowWidth = Screen.width / 4;
				defaultSideWindowHeight = Screen.height;
				defaultUIItemBuffer = 10;
				titleLogo = Resources.Load ("UITextures/deepspaceminelogo1", typeof(Texture2D)) as Texture2D;
				//The style for the main title
				gameTitleStyle = new GUIStyle ();
				//gameTitleStyle.fontSize = 48;
				//gameTitleStyle.normal.textColor = Color.white;
				gameTitleStyle.alignment = TextAnchor.MiddleCenter;
				//titleWidth = GUI.skin.label.CalcSize(titleLogo).x;
				//gameTitleStyle.CalcSize
		}
		// This will draw the in game menu
		void drawInGameUI ()
		{
				//This draws the title logo for Deep Space Mine
				if (titleLogo) {
						GUI.DrawTexture (new Rect ((screenWidth / 2) - (titleLogo.width / 2), 0 + titleLogo.height, titleLogo.width, titleLogo.height), titleLogo, ScaleMode.ScaleToFit, true, 0.0f);
				}
				if (GUI.Button (new Rect ((screenWidth / 2) - (defaultButtonWidth / 2), (screenHeight / 2) + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight), "New Game")) {
						//This loads the main scene, or in our case the core of the game.
						PlayerPrefs.SetInt ("health", defaultPlayerHealth);
						PlayerPrefs.SetString ("shipUpgrades", "");
						PlayerPrefs.SetString ("homeBaseUpgrades", "");
						PlayerPrefs.SetString ("resourcesCollected", "");
						PlayerPrefs.Save ();
						Application.LoadLevel ("main");
				}
				// Make the fourth button. If it is pressed, this will display available save files to load for the player
				if (GUI.Button (new Rect ((screenWidth / 2) - (defaultButtonWidth / 2), (screenHeight / 2) + (defaultButtonHeight * 2), defaultButtonWidth, defaultButtonHeight), "Load")) {
						// Make a background box
						GUI.Box (new Rect ((defaultUIItemBuffer * 2), (defaultUIItemBuffer * 2), defaultSideWindowWidth, defaultSideWindowHeight), "Load");
				}
				// Make the sixth button.If it is pressed, this will exit the game
				if (GUI.Button (new Rect ((screenWidth / 2) - (defaultButtonWidth / 2), (screenHeight / 2) + (defaultButtonHeight * 3), defaultButtonWidth, defaultButtonHeight), "Exit")) {
						Application.Quit ();
				}
		}
	
		// This updates the UI, similar to Update
		void OnGUI ()
		{
				drawInGameUI ();
			
		}

	
		// Update is called once per frame
		void Update ()
		{
				camera.backgroundColor = Color.black;
		}
}

