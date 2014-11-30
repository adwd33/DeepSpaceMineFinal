using UnityEngine;
using System.Collections;

public class NuclearGrowShrink : MonoBehaviour {

	private Vector3 max = new Vector3(8.5F, 8.5F, 8.5F);

	void Update() {
		if(transform.localScale.sqrMagnitude < max.sqrMagnitude)
			transform.localScale += new Vector3(0.025F, 0.025F, 0.025F);
	}
}
