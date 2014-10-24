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

	private ArrayList spawns = new ArrayList ();
	public Vector3 spawnValues;
	public int SpawnMax;
	public int spawnCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float innersphere;
	public float outersphere;
	public int[] distance = new int[5] {0, 0, 0, 0, 0};


	void Start ()
	{
		StartCoroutine (SpawnWaves ());
		spawnCount = 0;
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

	void FixedUpdate()
	{
		spawnCount = spawns.Count;
		for(int i = 0; i < spawns.Count; i++) {
			if(Vector3.Distance(((GameObject)spawns[i]).transform.position, transform.position) > outersphere)
			{
				Destroy((GameObject)spawns[i]);
				spawns.RemoveAt(i);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (spawns.Count <= SpawnMax)
		{
			Vector3 spawnPosition;
			GameObject prepareSpawn = randomRock ();

			spawnPosition = Random.onUnitSphere * Random.Range(innersphere, outersphere);
			spawnPosition += transform.position; // Makes the spawn locations always center on this game object (and thus, the player)

			Quaternion spawnRotation = Quaternion.identity;
			Collider[] hitColliders = Physics.OverlapSphere(prepareSpawn.renderer.bounds.center, prepareSpawn.renderer.bounds.extents.x);
			Debug.Log(hitColliders.Length);
			if(hitColliders.Length == 0)
			{
				Instantiate (prepareSpawn, spawnPosition, spawnRotation);
				spawns.Add(prepareSpawn);
			}

			for(int i = 0; i < spawns.Count; i++){
				//Debug.Log("Distance:" + Vector3.Distance(((GameObject)spawns[i]).transform.position, player.transform.position));

				if(Vector3.Distance(((GameObject)spawns[i]).transform.position, transform.position) > outersphere)
				{
					Destroy((GameObject)spawns[i]);
					spawns.RemoveAt(i);
				}
			}

			yield return new WaitForSeconds (spawnWait);

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