using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject astroid;
	public GameObject aluminum;
	public GameObject copper;
	public GameObject diamond;
	public GameObject gold;
	public GameObject hydrogen;
	public GameObject iron;
	public GameObject lead;
	public GameObject platinum;
	public GameObject unobtanium;
	public GameObject uranium;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float innersphere;
	public float outersphere;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	private GameObject randomRock(){
		int rock = Random.Range (0, 11);

		switch (rock) {
		case 0:
			return astroid;
		case 1:
			return aluminum;
		case 2:
			return copper;
		case 3:
			return diamond;
		case 4:
			return gold;
		case 5:
			return hydrogen;
		case 6:
			return iron;
		case 7:
			return lead;
		case 8:
			return platinum;
		case 9:
			return unobtanium;
		case 10:
			return uranium;
		default:
			return astroid;
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition;

				spawnPosition = Random.onUnitSphere * Random.Range(innersphere, outersphere);
				spawnPosition += transform.position; // Makes the spawn locations always center on this game object (and thus, the player)

				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (randomRock (), spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void OnGUI ()
	{
		//GUI.backgroundColor = Color.black;
		//if (isInGameUIEnabled) {
		//	drawInGameUI ();
		//}
		GUI.Label(new Rect(0, 0, 0, 0),"Packages: " + PlayerCounter.packageCounter.ToString ());
		
	}
}