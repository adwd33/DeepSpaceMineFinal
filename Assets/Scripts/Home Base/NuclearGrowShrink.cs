using UnityEngine;
using System.Collections;

public class NuclearGrowShrink : MonoBehaviour {

	private Vector3 max = new Vector3(8.5F, 8.5F, 8.5F);
	private bool reach = false;
	private float min = 8.5F;

	void Update() {
		if (transform.localScale.sqrMagnitude < max.sqrMagnitude && !reach) {
				transform.localScale += new Vector3 (0.025F, 0.025F, 0.025F);
		} else if (min > 0) {
				reach = true;
				transform.localScale -= new Vector3 (0.02F, 0.02F, 0.02F);
			min -= 0.02F;
		} else {
			Destroy(gameObject);
		}

	}
}
