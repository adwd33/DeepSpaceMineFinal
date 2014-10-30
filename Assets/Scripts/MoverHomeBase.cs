using UnityEngine;
using System.Collections;

public class MoverHomeBase : MonoBehaviour {

	public float speed;
	
	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}
}