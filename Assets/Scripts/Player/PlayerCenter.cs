using UnityEngine;
using System.Collections;

public class PlayerCenter : MonoBehaviour {

	//for switch between two control
	public GameObject cameraRod;
	public GameObject MainCamera;
	public float PlayerHealth;
	public float defaultPlayerHealth;

	//resources record
	public int[] resources = new int[11];

	// Upgrade list
	public int numBlasters;
	public int blasterPower;
	public int missilePower;
	public int hullStrength;
	public int hullRegen;
	public int shieldPower;
	public int movementLevel;
	public int radarLevel; // Not sure how much this is going to get implemented
	public int resourceMagnet; // Or this

	//purchased ship upgrades purchased, format should be "1 Regen" where 1 is the tier level and Regen is the name of the upgrade
	public ArrayList listShipUpgradesPurchased;
	//purchased home base upgrades, format should be "1 Missile Battery" where 1 is the tier level and Missile Battery is the name of the upgrade
	public ArrayList listHomeBaseUpgrades;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<PlayerControler>().enabled = false;
		gameObject.GetComponent<PlayerControllerTest>().enabled = true;

		cameraRod = GameObject.Find ("Player2/cameraRod");
		MainCamera = GameObject.Find("Player2/MainCamera");

		cameraRod.SetActive (false);
		MainCamera.SetActive (true);

		//Initialize the resource record
		//Index – ResouceName
		//1 – Aluminum
		//2 – Copper
		//3 – Diamond
		//4 – Gold
//		5 – Hydrogen
//		6 – Iron
//		7 – Lead
//		8 – Platinum
//		9 – Unobtanium
//		10- Uranium
//		0 – Asteroid
		resources = new int[11] {0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0};

		//Initialize the player health
		PlayerHealth = 10f;
		
		//A value representing the static unchanging amount of health, needed to ui purposes
		defaultPlayerHealth = 10f;
		listShipUpgradesPurchased = new ArrayList();
		listHomeBaseUpgrades = new ArrayList();

		// Initialize upgrades
		numBlasters = 0;
		blasterPower = 0;
		missilePower = 0;
		hullStrength = 0;
		hullRegen = 0;
		shieldPower = 0;
		movementLevel = 0;
		radarLevel = 0;
		resourceMagnet = 0;
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

	public bool incNumBlasters() {
		if (numBlasters < 3/* and if they have enough resources */) {
			// Take away resources
			numBlasters++;
			return true;
		} else {return false;}
	}
	public bool incBlasterPower() {
		if (blasterPower < 3/* and if they have enough resources */) {
			// Take away resources
			blasterPower++;
			return true;
		} else {return false;}
	}
	public bool incMissilePower() {
		if (missilePower < 3/* and if they have enough resources */) {
			// Take away resources
			missilePower++;
			return true;
		} else {return false;}
	}
	public bool incHullStrength() {
		if (hullStrength < 3/* and if they have enough resources */) {
			// Take away resources
			hullStrength++;
			return true;
		} else {return false;}
	}
	public bool incHullRegen() {
		if (hullRegen < 3/* and if they have enough resources */) {
			// Take away resources
			hullRegen++;
			return true;
		} else {return false;}
	}
	public bool incShieldPower() {
		if (shieldPower < 3/* and if they have enough resources */) {
			// Take away resources
			shieldPower++;
			return true;
		} else {return false;}
	}
	public bool incMovementLevel() {
		if (movementLevel < 3/* and if they have enough resources */) {
			// Take away resources
			movementLevel++;
			return true;
		} else {return false;}
	}
	public bool incRadarLevel() {
		if (radarLevel < 3/* and if they have enough resources */) {
			// Take away resources
			radarLevel++;
			return true;
		} else {return false;}
	}
	public bool incResourceMagnet() {
		if (resourceMagnet < 3/* and if they have enough resources */) {
			// Take away resources
			resourceMagnet++;
			return true;
		} else {return false;}
	}

	public int getNumBlasters() {return numBlasters;}
	public int getBlasterPower() {return blasterPower;}
	public int getMissilePower() {return missilePower;}
	public int getHullStrength() {return hullStrength;}
	public int getHullRegen() {return hullRegen;}
	public int getShieldPower() {return shieldPower;}
	public int getMovementLevel() {return movementLevel;}
	public int getRadarLevel() {return radarLevel;}
	public int getResourceMagnet() {return resourceMagnet;}

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
	public void setResourceList(int[] resources){
		this.resources = resources;
	}

	public void ApplyDamage(float DamageAmount)
	{
		PlayerHealth -= DamageAmount;
		//Vector3 position = transform.position;
		
		if(PlayerHealth < 0f)
		{
			Application.LoadLevel("Main"); //call function in GameController.cs
		}
	}

	public float GetPlayerHealth()
	{
		return PlayerHealth;
	}
	public void SetPlayerHealth(float newHealth){
		this.PlayerHealth = newHealth;
	}
	
	public float GetDefaultPlayerHealth()
	{
		return defaultPlayerHealth;
	}
	/// <summary>
	/// Adds the purchased ship upgrade.
	/// </summary>
	/// <param name="value">Value.</param>
	public void AddPurchasedShipUpgrade(string value){
		this.listShipUpgradesPurchased.Add(value);
	}
	
	/// <summary>
	/// Adds the purchased homebase upgrade.
	/// </summary>
	/// <param name="value">Value.</param>
	public void AddPurchasedHomebaseUpgrade(string value){
		this.listHomeBaseUpgrades.Add(value);
	}
	
	public ArrayList GetPurchasedShipUpgradeList(){
			return this.listShipUpgradesPurchased;
	}
	
	public ArrayList GetPurchasedHomeBaseUpgradeList(){
			return this.listHomeBaseUpgrades;
	}
}
