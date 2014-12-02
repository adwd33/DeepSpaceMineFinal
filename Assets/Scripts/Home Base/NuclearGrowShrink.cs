using UnityEngine;
using System.Collections;

public class NuclearGrowShrink : MonoBehaviour {

	private Vector3 max = new Vector3(20F, 20F, 20F);
	private bool reach = false;
	private float min = 20F;

	void Update() {
		if (transform.localScale.sqrMagnitude < max.sqrMagnitude && !reach) {
				transform.localScale += new Vector3 (0.1F, 0.1F, 0.1F);
		} else if (min > 0) {
				reach = true;
				transform.localScale -= new Vector3 (0.075F, 0.075F, 0.075F);
			min -= 0.075F;
		} else {
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "enemy")
			Destroy (other.gameObject);
	}
}
