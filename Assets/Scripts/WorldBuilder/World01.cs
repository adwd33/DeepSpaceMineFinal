using UnityEngine;
using System.Collections;

public class World01 : MonoBehaviour {

	public static int cubeEdgeLength = 7000;

	public static ArrayList units = new ArrayList();
	public static ArrayList positions  = new ArrayList();
	public static int cubeNum = 8;
	public static ArrayList rotations  = new ArrayList();


	// Use this for initialization
	void Start () {
		GameObject sun1 = (GameObject) Instantiate (Resources.Load ("Prefabs/sun", typeof(GameObject)),new Vector3(0, 0, 2000), Quaternion.identity);
		sun1.name = "realSUN";
		Vector3 newPosition = randomPosition("Prefabs/sun", new Vector3(0, 0, 0));
		Debug.Log("Position: " + newPosition.ToString("F4"));
		Vector3[] cubePosition = getCubePosition ();

		for(int i = 1; i < cubePosition.Length; i++){
			Instantiate (Resources.Load ("Prefabs/sun", typeof(GameObject)),randomPosition("Prefabs/sun", cubePosition[i]), Quaternion.identity);
		}

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
		Debug.Log("LocalScale: " + unit.transform.localScale.ToString("F4"));
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

		return randomGlobalPosition;
	}
}
