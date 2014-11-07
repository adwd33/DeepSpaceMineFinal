using UnityEngine;
using System.Collections;

public class ShieldLogic : MonoBehaviour {

	public int shieldStrength = 10;
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "boundary" || other.tag == "TurretShot")
		{
			return;
		}
		if (shieldStrength > 0) {
			shieldStrength--;
			Destroy(other.gameObject);
			return;
		}
		Destroy(gameObject);
	}
}
