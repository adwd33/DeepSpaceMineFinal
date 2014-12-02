using UnityEngine;
using System.Collections;

public class NuclearGrowShrink : MonoBehaviour {

	private Vector3 max = new Vector3(13F, 13F, 13F);
	private bool reach = false;
	private float min = 8.5F;

	void Update() {
		if (transform.localScale.sqrMagnitude < max.sqrMagnitude && !reach) {
				transform.localScale += new Vector3 (0.04F, 0.04F, 0.04F);
		} else if (min > 0) {
				reach = true;
				transform.localScale -= new Vector3 (0.02F, 0.02F, 0.02F);
			min -= 0.03F;
		} else {
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "enemy")
			Destroy (other.gameObject);
	}
}
