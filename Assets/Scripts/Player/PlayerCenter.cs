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
		resources = new int[11] {0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0};

		//Initialize the player health
		PlayerHealth = 10f;
		
		//A value representing the static unchanging amount of health, needed to ui purposes
		defaultPlayerHealth = 10f;
		listShipUpgradesPurchased = new ArrayList();
		listHomeBaseUpgrades = new ArrayList();
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
