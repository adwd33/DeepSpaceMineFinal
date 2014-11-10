using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public int baseHealth = 10;
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "boundary")
		{
			return;
		}
		if (baseHealth > 0) {
			baseHealth--;
			Destroy(other.gameObject);
			return;
		}
		Destroy(gameObject);
		Destroy(GameObject.Find("turret1"));
		Destroy(GameObject.Find("turret2"));
		Destroy(GameObject.Find("turret3"));
		Destroy(GameObject.Find("turret4"));
		Destroy(GameObject.Find("turret5"));
		Destroy(GameObject.Find("turret6"));
	}
}