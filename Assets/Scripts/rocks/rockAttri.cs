using UnityEngine;
using System.Collections;

public class rockAttri : MonoBehaviour {
	public float health = 0f;
	public int resources;
	public string type;
	public GameObject package;

	// Use this for initialization
	void Start () {
		health = Random.Range (5, 10);
		resources = Random.Range (5, 50);
		type = this.name;
	
	}

	public void ApplyDamage(float DamageAmount)
	{
		health -= DamageAmount;
		Vector3 position = transform.position;

		if(health < 0f)
		{
			Destroy (gameObject);
			Instantiate (package, positionl, Quaternion.identity);
		}
	}


}
