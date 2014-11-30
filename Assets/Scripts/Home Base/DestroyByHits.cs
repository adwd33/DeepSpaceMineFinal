using UnityEngine;
using System.Collections;

public class DestroyByHits : MonoBehaviour
{
	public int health = 10;
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "boundary" || other.tag == "nuclearshot" || other.tag == "TurretShot" || other.tag == "missile")
		{
			return;
		}
		if (health > 0) {
			health--;
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