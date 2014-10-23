﻿using UnityEngine;
using System.Collections;

public class World01 : MonoBehaviour {

	public struct boundDet
	{
		public float closest;
		public int direction; //direction can only be -1, 1, -2, 2, -3, 3 represents -x, x, -y, y, -z, z
	}

	public static int cubeEdgeLength = 10000;
	public GameObject player;
	private Bounds initialBound = new Bounds(Vector3.zero, new Vector3 (cubeEdgeLength,cubeEdgeLength,cubeEdgeLength));
	public Bounds currentBound;
	public static ArrayList boundsList = new ArrayList();
	public GameObject basicElement;
	private int basicElementNum = 1;

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

		//add initial bound to the bounds arrayList
		boundsList.Add (initialBound);
		currentBound = initialBound;
		distanceToBound = closestBoundaryDistance (player,currentBound).closest;
		direction = closestBoundaryDistance (player,currentBound).direction;

		//initialize the world with 27 cubes space
		increaseBound (player, currentBound);

	}

	void FixedUpdate(){

		if(currentBound != inCube (player, boundsList, currentBound, detectionRange))
		{
			currentBound = inCube (player, boundsList, currentBound, detectionRange);
			increaseBound (player, currentBound);
		}

		detectionRange = (int) (PlayerControllerTest.speed * 0.03) + 1;
		distanceToBound = closestBoundaryDistance (player,currentBound).closest;
		direction = closestBoundaryDistance (player,currentBound).direction;

	}

	/*used in FixedUpdate
	 * according the player's position to determine the expended bound
	 * of the world (which means every 26 of surrounded
	 * cube of current cube will be created)
	*/
	public void increaseBound(GameObject player,Bounds currentBound){
		float x = currentBound.center.x;
		float y = currentBound.center.y;
		float z = currentBound.center.z;
		Vector3 newCubeCenter = Vector3.zero;
		Bounds bound = currentBound;

		for(int i = -1; i <= 1; i++)
		{
			for(int j = -1; j <= 1; j++)
			{
				for(int k = -1; k <= 1; k++)
				{
					newCubeCenter.x = x + i * cubeEdgeLength;
					newCubeCenter.y = y + j * cubeEdgeLength;
					newCubeCenter.z = z + k * cubeEdgeLength;

					bound = new Bounds (newCubeCenter, new Vector3 (cubeEdgeLength, cubeEdgeLength, cubeEdgeLength));
					if (!boundsList.Contains (bound)) 
					{
						boundsList.Add (bound);
						randomInstantiate("Prefabs/sun", bound);
						Debug.Log ("Bounds NUM: " + boundsList.Count);
						Debug.Log ("New Bound Position: " + boundsList[boundsList.Count - 1]);
					}

				}
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

	/*
	 * monitor which cube field is player in currently  
	 */
	public Bounds inCube(GameObject player, ArrayList cubes, Bounds currentBound, int detectionRange)
	{
		if(closestBoundaryDistance(player, currentBound).closest < detectionRange && closestBoundaryDistance(player, currentBound).closest > 0)
		{
			Debug.Log ("Possibly change the current bound.");

			foreach (Bounds cube in cubes) {
				if(cube.Contains(player.transform.position))
				{
					currentBound = cube;
					break;
				}
			}

			Debug.Log ("Current Bound:" + currentBound.center.ToString());

			return currentBound;
		}
		else
		{
			return currentBound;
		}


	}


	/*
	 * according to the resource's size instantiate the object in the currentCube
	 */
	public Vector3 randomInstantiate(string resource, Bounds currentBound){
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

		randomGlobalPosition.x = randomLocalPosition.x + currentBound.center.x;
		randomGlobalPosition.y = randomLocalPosition.y + currentBound.center.y;
		randomGlobalPosition.z = randomLocalPosition.z + currentBound.center.z;
		Debug.Log ("Cube:" + currentBound.center.ToString("F4"));
		Debug.Log("Position: " + randomGlobalPosition.ToString("F4"));

		Instantiate (Resources.Load (resource, typeof(GameObject)), randomGlobalPosition, Quaternion.identity);

		return randomGlobalPosition;
	}


}
