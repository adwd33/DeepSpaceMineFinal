using UnityEngine;
using System.Collections;

[System.Serializable]

public class PlayerControler : MonoBehaviour
{
	private GameObject ship;
	public float speed;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	public GameObject cameraRod;

	// Stuff having to do with upgrades
	public float movementLevel;
	// End stuff having to do with upgrades

	void Start ()
	{
		cameraRod = GameObject.Find ("Player2/cameraRod");
		ship = GameObject.Find ("Player2/Ship");
	}
	
	void Update ()
	{
		// Set the turning speed of the ship based on the ship's movement level
		float turnSpeed;
		if (movementLevel == 0) {
			turnSpeed = 100F;
		} else if (movementLevel == 1) {
			turnSpeed = 200F;
		} else if (movementLevel == 2) {
			turnSpeed = 300F;		
		} else {
			turnSpeed = 700F;
		}

		// Rotate the ship towards the camera's angle based on the turning speed
		ship.transform.rotation = Quaternion.RotateTowards(ship.transform.rotation, cameraRod.transform.rotation, turnSpeed * Time.deltaTime);
	}
	
	void FixedUpdate ()
	{
		// Shoot and control the rate of fire
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			Instantiate(shot, shotSpawn.position, ship.rigidbody.rotation);
		}

		// Set the movement speed based on the ship's movement level
		float moveSpeed;
		if (movementLevel == 0) {
			moveSpeed = 8;
		} else if (movementLevel == 1) {
			moveSpeed = 10;
		} else if (movementLevel == 2) {
			moveSpeed = 12;		
		} else {
			moveSpeed = 15;
		}

		// Reduce the movement speed for more controlled movement if the button is being held down
		if (Input.GetButton ("Slow"))
			moveSpeed /= 2;

		// Move the player in the direction of any buttons being pressed
		if (Input.GetButton ("Forward")) {
			Debug.Log("Forward");

						ship.rigidbody.AddRelativeForce (Vector3.forward * moveSpeed);
				}
		if (Input.GetButton("Back"))
			ship.rigidbody.AddRelativeForce(Vector3.back * moveSpeed);
		if (Input.GetButton("Left"))
			ship.rigidbody.AddRelativeForce(Vector3.left * moveSpeed);
		if (Input.GetButton("Right"))
			ship.rigidbody.AddRelativeForce(Vector3.right * moveSpeed);
		if (Input.GetButton("Up"))
			ship.rigidbody.AddRelativeForce(Vector3.up * moveSpeed);
		if (Input.GetButton("Down"))
			ship.rigidbody.AddRelativeForce(Vector3.down * moveSpeed);

	}
}