using UnityEngine;
using System.Collections;

public class World01 : MonoBehaviour {

	public struct boundDet
	{
		public float closest;
		public int direction; //direction can only be -1, 1, -2, 2, -3, 3 represents -x, x, -y, y, -z, z
	}

	public static int cubeEdgeLength = 10000;
	public static int cubeNum = 8;
	public GameObject player;
	private Bounds initialBound = new Bounds(Vector3.zero, new Vector3 (cubeEdgeLength,cubeEdgeLength,cubeEdgeLength));
	private Bounds currentBound;
	public static ArrayList boundsList = new ArrayList();

	//for test or detection in the future
	public int direction;
	public float distanceToBound;
	public int detectionRange = 0;
	//public Vector3 position;

	// Use this for initialization
	void Start () {
		//try initiate the elements
		GameObject sun1 = (GameObject) Instantiate (Resources.Load ("Prefabs/sun", typeof(GameObject)),new Vector3(0, 0, 2000), Quaternion.identity);
		sun1.name = "realSUN";
		//Vector3 newPosition = randomPosition("Prefabs/sun", new Vector3(0, 0, 0));
		//Debug.Log("Position1: " + newPosition.ToString("F4"));
		//Vector3[] cubePosition = getCubePosition ();

		//for(int i = 1; i < cubePosition.Length; i++){
		//	Instantiate (Resources.Load ("Prefabs/sun", typeof(GameObject)),randomPosition("Prefabs/sun", cubePosition[i]), Quaternion.identity);
		//}

		//add initial bound to the bounds arrayList
		boundsList.Add (initialBound);
		currentBound = initialBound;
		distanceToBound = closestBoundaryDistance (player,currentBound).closest;
		direction = closestBoundaryDistance (player,currentBound).direction;

	}

	void FixedUpdate(){

		increaseBound (player,currentBound, detectionRange);

		detectionRange = (int) (PlayerControllerTest.speed * 0.03) + 1;
		distanceToBound = closestBoundaryDistance (player,currentBound).closest;
		direction = closestBoundaryDistance (player,currentBound).direction;

	}

	/*used in FixedUpdate
	 * according the player's position to determine the expended bound
	 * of the world (yet not be able to deal with the 8 vertex of cube, but
	 * guess no user will be able to be that accurate)
	*/
	public void increaseBound(GameObject player,Bounds currentBound, int detectionRange){
		boundDet detect = closestBoundaryDistance (player,currentBound);
		float x = currentBound.center.x;
		float y = currentBound.center.y;
		float z = currentBound.center.z;

		if (detect.closest <= 1000 + detectionRange && detect.closest > 1000) {
			Debug.Log ("Ship trigger the increase method!");
			Bounds bound;
			switch(detect.direction)
			{
			case 1:
				bound = new Bounds (new Vector3 (x + 10000, y, z), new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
				break;
			case 2:
				bound = new Bounds (new Vector3 (x, y + 10000, z), new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
				break;
			case 3:
				bound = new Bounds (new Vector3 (x, y, z + 10000), new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
				break;
			case -1:
				bound = new Bounds (new Vector3 (x - 10000, y, z), new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
				break;
			case -2:
				bound = new Bounds (new Vector3 (x, y - 10000, z), new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
				break;
			case -3:
				bound = new Bounds (new Vector3 (x, y, z - 10000), new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
				break;
			default:
				bound = new Bounds (Vector3.zero, new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
				break;
			}

			if (!boundsList.Contains (bound)) 
			{
				boundsList.Add (bound);
				Debug.Log ("Bounds NUM: " + boundsList.Count);
				Debug.Log ("New Bound Position: " + boundsList[boundsList.Count - 1]);
			}
			else
			{
				Debug.Log("Bounds already exist!");
			}
		} 


	}

	/*
	 * used in FixedUpdate working with increaseBound
	 * continusely calculate the closest distance between every side of
	 * current cube and player's position
	 * output: closest distance & increased direction
	 */
	public boundDet closestBoundaryDistance(GameObject player, Bounds currentBound){
		boundDet bounddet;
		float closest;
		int direction;

		float closestDistanceX = Mathf.Abs(currentBound.center.x + cubeEdgeLength / 2 - player.transform.position.x); 
		float closestDistanceY = Mathf.Abs(currentBound.center.y + cubeEdgeLength / 2 - player.transform.position.y); 
		float closestDistanceZ = Mathf.Abs(currentBound.center.z + cubeEdgeLength / 2 - player.transform.position.z); 
		float closestDistanceNX = Mathf.Abs(currentBound.center.x - cubeEdgeLength / 2 - player.transform.position.x); 
		float closestDistanceNY = Mathf.Abs(currentBound.center.y - cubeEdgeLength / 2 - player.transform.position.y); 
		float closestDistanceNZ = Mathf.Abs(currentBound.center.z - cubeEdgeLength / 2 - player.transform.position.z); 


		closest = Mathf.Min (closestDistanceX,closestDistanceY);
		closest = Mathf.Min (closest,closestDistanceZ);
		closest = Mathf.Min (closest,closestDistanceNX);
		closest = Mathf.Min (closest,closestDistanceNY);
		closest = Mathf.Min (closest,closestDistanceNZ);

		if(closestDistanceY >= closestDistanceX){
			closest = closestDistanceX;
			direction = 1;
		}
		else
		{
			closest = closestDistanceY;
			direction = 2;
		}

		if(closest >= closestDistanceZ){
			closest = closestDistanceZ;
			direction = 3;
		}

		if(closest >= closestDistanceNX){
			closest = closestDistanceNX;
			direction = -1;
		}

		if(closest >= closestDistanceNY){
			closest = closestDistanceNY;
			direction = -2;
		}

		if(closest >= closestDistanceNZ){
			closest = closestDistanceNZ;
			direction = -3;
		}

		bounddet.direction = direction;
		bounddet.closest = closest;
		return bounddet;
	}


	//according to the resource's size output random position of a cube base on the centerOfCube
	public Vector3 randomPositionInCube(string resource, Vector3 centerOfCube){
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
