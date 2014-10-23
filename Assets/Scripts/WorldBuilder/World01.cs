using UnityEngine;
using System.Collections;

public class World01 : MonoBehaviour {

	public static int cubeEdgeLength = 10000;

	//public static ArrayList units = new ArrayList();
	//public static ArrayList positions  = new ArrayList();
	public static int cubeNum = 8;
	//public static ArrayList rotations  = new ArrayList();
	public GameObject player;
	private Bounds initialBound = new Bounds(Vector3.zero, new Vector3 (cubeEdgeLength,cubeEdgeLength,cubeEdgeLength));
	private Bounds currentBound;
	public static ArrayList boundsList = new ArrayList();

	//for test or detection in the future
	public float distanceToBound;
	//public Vector3 position;

	// Use this for initialization
	void Start () {
		//try initiate the elements
		GameObject sun1 = (GameObject) Instantiate (Resources.Load ("Prefabs/sun", typeof(GameObject)),new Vector3(0, 0, 2000), Quaternion.identity);
		sun1.name = "realSUN";
		Vector3 newPosition = randomPosition("Prefabs/sun", new Vector3(0, 0, 0));
		Debug.Log("Position1: " + newPosition.ToString("F4"));
		Vector3[] cubePosition = getCubePosition ();

		for(int i = 1; i < cubePosition.Length; i++){
			Instantiate (Resources.Load ("Prefabs/sun", typeof(GameObject)),randomPosition("Prefabs/sun", cubePosition[i]), Quaternion.identity);
		}

		//add initial bound to the bounds arrayList
		boundsList.Add (initialBound);
		currentBound = initialBound;
		distanceToBound = closestBoundaryDistance (player,currentBound);

	}

	void FixedUpdate(){
		if (!boundsList.Contains (increaseBound (player, currentBound))) 
		{
			boundsList.Add (increaseBound (player, currentBound));
			for (int i = 0; i<boundsList.Count; i++) 
			{
				Debug.Log ("Bounds:" + boundsList [i]);
			}
		} 

		distanceToBound = closestBoundaryDistance (player,currentBound);;

	}

	public Bounds increaseBound(GameObject player,Bounds currentBound){
		if (closestBoundaryDistance(player,currentBound) <= 1000) {
			Bounds bound = new Bounds (new Vector3 (10000, 0, 0), new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
			return bound;
		} else {
			Bounds bound = new Bounds (new Vector3 (0, 0, 0), new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
			return bound;		
		}
	}

	public float closestBoundaryDistance(GameObject player, Bounds bound){
		float closestDistanceX = Mathf.Abs(bound.center.x + cubeEdgeLength / 2 - player.transform.position.x); 
		float closestDistanceY = Mathf.Abs(bound.center.y + cubeEdgeLength / 2 - player.transform.position.y); 
		float closestDistanceZ = Mathf.Abs(bound.center.z + cubeEdgeLength / 2 - player.transform.position.z); 
		float closestDistanceNX = Mathf.Abs(bound.center.x - cubeEdgeLength / 2 - player.transform.position.x); 
		float closestDistanceNY = Mathf.Abs(bound.center.y - cubeEdgeLength / 2 - player.transform.position.y); 
		float closestDistanceNZ = Mathf.Abs(bound.center.z - cubeEdgeLength / 2 - player.transform.position.z); 


		float closest = Mathf.Min (closestDistanceX,closestDistanceY);
		closest = Mathf.Min (closest,closestDistanceZ);
		closest = Mathf.Min (closest,closestDistanceNX);
		closest = Mathf.Min (closest,closestDistanceNY);
		closest = Mathf.Min (closest,closestDistanceNZ);
		return closest;
	}

	public Vector3[] getCubePosition(){
		Vector3[] cubePosition = new Vector3[4];
		cubePosition [0] = new Vector3 (0, 0, 0);
		//int worldEdge = (int) Mathf.Ceil ( Mathf.Pow (num + 1, (float)1 / 3));

		//for(int i = 1; i <= worldEdge){
		//
		//	for(int j = 1; j<=worldEdge; j++){
		//		for(int k = 0; k <= worldEdge; k++){
		//			
		//		}
		//	}
		//}

		cubePosition [1] = new Vector3 (7000,0,0);
		cubePosition [2] = new Vector3 (-7000,0,0);
		cubePosition [3] = new Vector3 (0,7000,0);
		//cubePosition [4] = new Vector3 (0,-7000,0);
		//cubePosition [5] = new Vector3 (0,0,7000);

		return cubePosition;





	}
	
	public Vector3 randomPosition(string resource, Vector3 centerOfCube){
		Vector3 randomLocalPosition;
		Vector3 randomGlobalPosition;

		GameObject unit = (GameObject) Resources.Load (resource, typeof(GameObject));
		float positionRange = cubeEdgeLength - unit.transform.localScale.x;           //as all the units in the world will be sphere and localScale.x, localScale.y, localScale.z will be always the same, just need x
		//Debug.Log("LocalScale: " + unit.transform.localScale.ToString("F4"));
		//Debug.Log("Seed: " + Random.seed);
		randomLocalPosition.x = Random.Range (0, positionRange);
		Random.seed = (int) randomLocalPosition.x;
		//Debug.Log("Seed: " + Random.seed);
		randomLocalPosition.y = Random.Range (0, positionRange);
		Random.seed = (int) randomLocalPosition.y;
		//Debug.Log("Seed: " + Random.seed);
		randomLocalPosition.z = Random.Range (0, positionRange);

		randomGlobalPosition.x = randomLocalPosition.x + centerOfCube.x;
		randomGlobalPosition.y = randomLocalPosition.y + centerOfCube.y;
		randomGlobalPosition.z = randomLocalPosition.z + centerOfCube.z;
		Debug.Log ("Cube:" + centerOfCube.ToString("F4"));
		Debug.Log ("Cube Field:" + (centerOfCube.x - 3500).ToString("F1") + " " + (centerOfCube.x + 3500).ToString("F1") + ";" + (centerOfCube.y - 3500).ToString("F1") + " " + (centerOfCube.y + 3500).ToString("F1") + ";" + (centerOfCube.z - 3500).ToString("F1") + " " + (centerOfCube.z + 3500).ToString("F1") + ";");
		Debug.Log("Position: " + randomGlobalPosition.ToString("F4"));
		return randomGlobalPosition;
	}
}
