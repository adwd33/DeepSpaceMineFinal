using UnityEngine;
using System.Collections;

public class rockSpawn : MonoBehaviour {

	public GameObject hazard;
	private bool colliding = false;
	private int wait = 5;

	void OnTriggerStay(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		// There's an asteroid here!
		colliding = true;
	}

	void FixedUpdate () {
		if (wait <= 0) {
						if (colliding == true)
								Destroy (gameObject);
						else
								Instantiate (hazard, transform.position, transform.rotation);
						Destroy (gameObject);
				} else
						wait--;
	}
}
