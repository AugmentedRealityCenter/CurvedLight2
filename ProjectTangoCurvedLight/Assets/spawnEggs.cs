using UnityEngine;
using System.Collections;

public class spawnEggs : MonoBehaviour {

	public GameObject egg;
	public GameObject[] spawnPoints;

	private int pointIndex = -1;
	private int lastPoint = -1;

	void Start() {
			spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

		spawnEgg ();
	}

	void spawnEgg()
	{
		if (spawnPoints.Length > 1) {
			while (pointIndex == lastPoint) {
				pointIndex = Random.Range (0, (spawnPoints.Length - 1));
			}
			lastPoint = pointIndex;
			Instantiate (egg, spawnPoints [pointIndex].transform.position, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
