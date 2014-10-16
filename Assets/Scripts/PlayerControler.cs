using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControler : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	public GameObject cameraRod;

	// Stuff having to do with mouselook
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX;
	public float sensitivityY;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -360F;
	public float maximumY = 360F;

	float rotationX = 0F;
	float rotationY = 0F;
	// End stuff having to do with mouselook
	
	//Ship posture
	//public float lr_Rotate_MaxAngle = -90.0f;
	//public float lr_m_Angle = 0.0f;
	//public float m_SmoothValue = 3.0f;
	
	void Awake()
	{
		//lr_m_Angle = transform.rotation.eulerAngles.z;
		//ht_m_Angle = transform.rotation.eulerAngles.x;
		//lr_Rotate_MaxAngle += lr_m_Angle;
		//ht_Rotate_MaxAngle += ht_m_Angle;
	}

	void Start ()
	{
		// Make the rigid body not change rotation
//		if (rigidbody)
//			rigidbody.freezeRotation = true;
		//originalRotation = transform.localRotation;
	}
	
	void Update ()
	{
		// Create a vector of the difference between this transform's rotation and the cameraRod's transform's rotation
		Vector3 vChange = new Vector3(cameraRod.transform.eulerAngles.x - transform.eulerAngles.x,
		                           cameraRod.transform.eulerAngles.y - transform.eulerAngles.y,
		                           cameraRod.transform.eulerAngles.z - transform.eulerAngles.z);

		// Add the difference to this transform
		Vector3 newDir = new Vector3 (transform.eulerAngles.x + vChange.x,
		                              transform.eulerAngles.y + vChange.y,
		                              transform.eulerAngles.z + vChange.z);
		transform.eulerAngles = newDir;

		// Subtract the different from cameraRod's transform
		newDir = new Vector3 (cameraRod.transform.eulerAngles.x - vChange.x,
		                      cameraRod.transform.eulerAngles.y - vChange.y,
		                      cameraRod.transform.eulerAngles.z - vChange.z);
		cameraRod.transform.eulerAngles = newDir;

		/*
		Vector3 swap = cameraRod.transform.eulerAngles - transform.eulerAngles;
		transform.forward = cameraRod.transform.forward;
		cameraRod.transform.Rotate (-swap);
		*/
		/*
		rotationX = sensitivityX * Input.GetAxis ("Mouse X");
		rotationY = sensitivityY * Input.GetAxis ("Mouse Y");
		transform.Rotate (-rotationY, rotationX, 0, Space.Self);
		Debug.Log("X = " + rotationX);
		Debug.Log("Y = " + rotationY);
		Debug.Log ("Math: " + rotationX + " * " + sensitivityX + " = " + (rotationX * sensitivityX));*/
		/*
		// Stuff having to do with mouselook
		if (axes == RotationAxes.MouseXAndY)
		{
			//ship posture adjust
			//float lr_Input = Input.GetAxis("Horizontal");
			//lr_m_Angle = Mathf.Lerp(lr_m_Angle, lr_Rotate_MaxAngle * lr_Input, Time.deltaTime * m_SmoothValue);
			//Vector3 euler = transform.rotation.eulerAngles;
			//euler.z = lr_m_Angle;
			//transform.localRotation = Quaternion.Euler(euler);
			
			//float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			//float rotationX = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * sensitivityX;
			rotationX = Input.GetAxis("Mouse X") * sensitivityX;
			rotationY = Input.GetAxis("Mouse Y") * sensitivityY;

			//rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
			//rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			//transform.localEulerAngles = new Vector3(-rotationY, rotationX, lr_m_Angle);

			//Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			//Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
			
			//transform.localRotation = originalRotation * xQuaternion * yQuaternion;
			transform.Rotate (-rotationY, rotationX, 0, Space.Self);
			Debug.Log("X = " + rotationX);
			Debug.Log("Y = " + rotationY);
		}
		else if (axes == RotationAxes.MouseX)
		{
			rotationX = Input.GetAxis("Mouse X") * sensitivityX;
			//rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
			
			//Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			//transform.localRotation = originalRotation * xQuaternion;
			transform.Rotate (0, rotationX, 0, Space.Self);
			Debug.Log("X = " + rotationX);
		}
		else
		{
			rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
			//rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			//Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			//transform.localRotation = originalRotation * yQuaternion;
			transform.Rotate (-rotationY, 0, 0, Space.Self);
			Debug.Log("Y = " + rotationY);
		}*/
		// End stuff having to do with mouselook
	}
	
	void FixedUpdate ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			Instantiate(shot, shotSpawn.position, rigidbody.rotation);
			audio.Play ();
		}
		
		float moveHorizontal = Input.GetAxis ("Speed");
		
		// Moves the ship according to its orientation when appropriate keys are pressed
		transform.Translate (0, 0, moveHorizontal/50 * speed, Space.Self);
	}
}