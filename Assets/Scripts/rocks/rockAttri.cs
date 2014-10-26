using UnityEngine;
using System.Collections;

public class rockAttri : MonoBehaviour {
	public float health = 0f;
	public int resources;
	public string type;
	// Use this for initialization
	void Start () {
		health = Random.Range (5, 10);
		resources = Random.Range (5, 50);
		type = this.name;
	
	}

	public void ApplyDamage(float DamageAmount)
	{
		health -= DamageAmount;

		if(health < 0f)
		{
			Destroy (gameObject);
		}
	}


}
