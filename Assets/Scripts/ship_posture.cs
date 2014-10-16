using UnityEngine;
using System.Collections;

public class ship_posture : MonoBehaviour {

	public float lr_Rotate_MaxAngle = -90.0f;
	public float ht_Rotate_MaxAngle = 40.0f;
	public float lr_m_Angle = 0.0f;
	public float ht_m_Angle = 0.0f;
	public float m_SmoothValue = 3.0f;
	
	void Awake()
	{
		lr_m_Angle = transform.rotation.eulerAngles.z;
		ht_m_Angle = transform.rotation.eulerAngles.x;
		lr_Rotate_MaxAngle += lr_m_Angle;
		ht_Rotate_MaxAngle += ht_m_Angle;
	}
	
	void FixedUpdate()
	{
		float lr_Input = Input.GetAxis("Horizontal");
		lr_m_Angle = Mathf.Lerp(lr_m_Angle, lr_Rotate_MaxAngle * lr_Input, Time.deltaTime * m_SmoothValue);
		Vector3 euler = transform.rotation.eulerAngles;
		euler.z = lr_m_Angle;
		transform.rotation = Quaternion.Euler(euler);

		float ht_Input = Input.GetAxis("Vertical");
		ht_m_Angle = Mathf.Lerp(ht_m_Angle, ht_Rotate_MaxAngle * ht_Input, Time.deltaTime * m_SmoothValue);
		euler = transform.rotation.eulerAngles;
		euler.x = ht_m_Angle;
		transform.rotation = Quaternion.Euler(euler); 
	}
}
