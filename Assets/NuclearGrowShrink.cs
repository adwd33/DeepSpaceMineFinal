using UnityEngine;
using System.Collections;

public class NuclearGrowShrink : MonoBehaviour {

	private float growthrate = 5/72;
	private float shrinkrate = 3 / 72;
	private int frames = 0;
	private int hold = 0;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (0.01F, 0.01F, 0.01F);
	}
	
	// Update is called once per frame
	void Update () {
		if(frames < 72){
			transform.localScale += new Vector3 (growthrate, growthrate, growthrate);
			frames++;
		}
		if(frames > 71)
			hold++;
		if(hold > 48){
			transform.localScale -= new Vector3(shrinkrate, shrinkrate, shrinkrate);
		}
		if(hold > 167)
			Destroy(gameObject);

	}
}
