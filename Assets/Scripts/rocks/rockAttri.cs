using UnityEngine;
using System.Collections;

public class rockAttri : MonoBehaviour {
	public float health;
	public int resources;
	public GameController gc;
	public GameObject PlayerWorld;

	// Use this for initialization
	void Start () {
		PlayerWorld = GameObject.Find("Player2/PlayerWorld");
		gc = PlayerWorld.GetComponent<GameController>();

		health = Random.Range (5, 10);
		resources = Random.Range (5, 50);
	}

	public void ApplyDamage(float DamageAmount)
	{
		health -= DamageAmount;
		Vector3 position = transform.position;

		if(health < 0f)
		{
			gc.SpawnRemoved(gameObject); //call function in GameController.cs
		}
	}

	public int getResource()
	{
		return resources;
	}

}
